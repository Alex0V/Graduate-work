from flask import Flask, request, jsonify
import pandas as pd
import nltk
from surprise.model_selection import train_test_split
from surprise import Dataset, Reader, SVD
from apscheduler.schedulers.background import BackgroundScheduler
import numpy as np
from gensim.models import Word2Vec
from sklearn.metrics.pairwise import cosine_similarity
import pyodbc
from datetime import datetime
import pickle
import shutil
import os
nltk.download('wordnet')

app = Flask(__name__)
DB_CONNECTION_STRING = "DRIVER={SQL Server};SERVER=DESKTOP-7S5VEFS\\SQLEXPRESS; DATABASE=NewMedit;Trusted_Connection=True;"

def data_for_content_based():
    conn = pyodbc.connect(DB_CONNECTION_STRING)
    cursor = conn.cursor()
    cursor.execute('''
    SELECT 
        MP.Id,
        MP.ProgramName AS MeditationProgram,
        M.Name AS Meditation,
        M.Duration AS Duration,
        STRING_AGG(C.CategoryName, ', ') AS Categories
    FROM 
        MeditationPrograms MP
        INNER JOIN Meditations M ON MP.MeditationId = M.Id
        LEFT JOIN MeditationCategories MC ON M.Id = MC.MeditationId
        LEFT JOIN Categories C ON MC.CategoryId = C.Id
    GROUP BY
        MP.Id, MP.ProgramName, M.Name, M.Duration
    ORDER BY
        MP.ProgramName, M.Name;''')
    rows = cursor.fetchall()
    df = pd.DataFrame([tuple(row) for row in rows], columns=[column[0] for column in cursor.description])
    cursor.close()
    conn.close()
    return df

def data_for_collaborative():
    conn = pyodbc.connect(DB_CONNECTION_STRING)
    cursor = conn.cursor()
    cursor.execute('''SELECT UserId, MeditationProgramId, Score FROM Ratings''')
    rows = cursor.fetchall()
    df = pd.DataFrame([tuple(row) for row in rows], columns=[column[0] for column in cursor.description])
    cursor.close()
    conn.close()
    return df

def train_and_save_word2vec_model():
    today_date = datetime.today().strftime('%Y-%m-%d')
    content_data = data_for_content_based()
    content_data['Content'] = content_data.apply(lambda row: ' '.join(row.dropna().astype(str)), axis=1)
    corpus = [content.split() for content in content_data['Content']]
    word2vec_model = Word2Vec(corpus, vector_size=100, window=5, min_count=1, workers=4)
    document_embeddings = []
    for content in corpus:
        content_vector = np.mean([word2vec_model.wv[word] for word in content if word in word2vec_model.wv], axis=0)
        document_embeddings.append(content_vector)
    content_similarity = cosine_similarity(document_embeddings, document_embeddings)
    np.save(f'./models/content_similarity_{today_date}.npy', content_similarity)
    #word2vec_model.save(f"models/word2vec_model_{today_date}.bin")
    content_data.to_pickle(f'./models/content_data_{today_date}.pkl')

def train_and_save_svd_model():
    today_date = datetime.today().strftime('%Y-%m-%d')
    collaborative_data = data_for_collaborative()
    reader = Reader(rating_scale=(1, 5))
    data = Dataset.load_from_df(collaborative_data[['UserId', 'MeditationProgramId', 'Score']], reader)
    # Розділення на тренувальний і тестовий набори
    trainset, testset = train_test_split(data, test_size=0.20)
    dataset = data.build_full_trainset()
    svd_model = SVD()
    svd_model.fit(dataset)
    with open(f'./models/svd_model_{today_date}.pkl', 'wb') as f:
        pickle.dump(svd_model, f)
    with open(f'./models/dataset_{today_date}.pkl', 'wb') as f:
        pickle.dump(dataset, f)
    with open(f'./models/testset_{today_date}.pkl', 'wb') as f:
        pickle.dump(testset, f)
    
@app.route('/update-models', methods=['POST'])
def update_model():
    files = os.listdir("./models")
    if files:
        for file_name in files:
            source_file = os.path.join("./models", file_name)
            print(source_file)
            destination_file = os.path.join("./old_models", file_name)
            shutil.move(source_file, destination_file)
    train_and_save_word2vec_model()
    train_and_save_svd_model()
    return 'Models updated sucessfull'

def scheduled_job():
    with app.app_context():
        update_model()

def get_content_based_recommendations(product_id, top_n):
    directory = "./models"
    content_similarity_to_load = None
    for file in os.listdir(directory):
        if file.startswith('content_similarity'):
            content_similarity_to_load = os.path.join(directory, file)
            break
    content_data_to_load = None
    for file in os.listdir(directory):
        if file.startswith('content_data'):
            content_data_to_load = os.path.join(directory, file)
            break
    content_similarity = np.load(content_similarity_to_load)
    content_data = pd.read_pickle(content_data_to_load)
    index = content_data[content_data['Id'] == product_id].index[0]
    similarity_scores = content_similarity[index]
    similar_indices = similarity_scores.argsort()[::-1][1:top_n + 1]
    recommendations = content_data.loc[similar_indices, 'Id'].values
    return recommendations.tolist()

def get_collaborative_filtering_recommendations(user_id, top_n):
    directory = "./models"
    dataset_to_load = None
    svd_model_to_load = None
    for file in os.listdir(directory):
        if file.startswith('dataset'):
            dataset_to_load = os.path.join(directory, file)
        elif file.startswith('svd_model'):
            svd_model_to_load = os.path.join(directory, file)
    if dataset_to_load is None or svd_model_to_load is None:
        raise FileNotFoundError("Model or trainset file not found in the specified directory.")
    dataset = np.load(dataset_to_load, allow_pickle=True)
    svd_model = pd.read_pickle(svd_model_to_load)
    unique_meditations = dataset.all_items()
    meditation_ids = [dataset.to_raw_iid(i) for i in unique_meditations]
    predset = [[user_id, meditation_id, 0] for meditation_id in meditation_ids]
    predictions = svd_model.test(predset)
    predictions.sort(key=lambda x: x.est, reverse=True)
    recommendations = [pred.iid for pred in predictions[:top_n]]
    return recommendations

def get_count_rated_by_user(user_id):
    conn = pyodbc.connect(DB_CONNECTION_STRING)
    cursor = conn.cursor()
    cursor.execute("SELECT MeditationProgramId FROM Ratings WHERE UserId = ?", (user_id))
    results = cursor.fetchall()
    actual_items = [row[0] for row in results]
    cursor.close()
    conn.close()
    return len(actual_items)

def get_hybrid_recommendations(user_id, product_id, top_n):
    content_based_recommendations = get_content_based_recommendations(product_id, top_n)
    collaborative_filtering_recommendations = get_collaborative_filtering_recommendations(user_id, top_n)
    if get_count_rated_by_user(user_id) <= 20:
        weight_content = 0.8
        weight_collaborative = 0.2
    else:
        weight_content = 0.2
        weight_collaborative = 0.8
    recommendations = {}
    for i, product in enumerate(content_based_recommendations):
        if product not in recommendations:
            recommendations[product] = 0
        recommendations[product] += weight_content * (top_n - i)
    for i, product in enumerate(collaborative_filtering_recommendations):
        if product not in recommendations:
            recommendations[product] = 0
        recommendations[product] += weight_collaborative * (top_n - i)
    sorted_recommendations = sorted(recommendations.items(), key=lambda x: x[1], reverse=True)
    return [product for product, score in sorted_recommendations[:top_n]]

@app.route('/get_recommendations', methods=['POST'])
def get_recommendations():
    data = request.json
    # Перевірка наявності id1, id2, id3 в даних
    if 'userId' in data and 'meditationProgramId' in data and 'count' in data:
        userId = data['userId']
        meditationProgramId = data['meditationProgramId']
        count = data['count']
    try:
        userId = int(userId)
        meditationProgramId = int(meditationProgramId) 
        count = int(count)
    except ValueError:
        return jsonify({'error': 'Invalid parameter type, expected integer'}), 400
        
    recommendations = get_hybrid_recommendations(userId, meditationProgramId, count)
    return jsonify({'recommendations': recommendations})


if __name__ == '__main__':
    scheduler = BackgroundScheduler()
    scheduler.add_job(scheduled_job, 'cron', hour=3, minute=0)
    scheduler.start()

    app.run(debug=True)