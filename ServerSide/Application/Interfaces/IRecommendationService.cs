namespace Application.Interfaces;

public interface IRecommendationService
{
    Task<List<int>> GetRecomendationByNameAsync(string userName, int MeditationProgramId);
}
