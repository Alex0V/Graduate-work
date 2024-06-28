using Application.Interfaces;
using Domain.Interfaces.Repositories;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Infrastructure.Services;

public sealed record RecommendationRequestDto(int userId, int meditationProgramId, int count);
public class RecommendationService : IRecommendationService
{
    private readonly IUserRepository _userRepository;

    public RecommendationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<int>> GetRecomendationByNameAsync(string userName, int meditationProgramId)
    {
        var user = await _userRepository.GetUserByUsernameAsync(userName);
        const int count = 4;
        List<int> recomendMedits = new List<int>();
        var apiUrl = "http://127.0.0.1:5000/get_recommendations";
        var requestData = new RecommendationRequestDto(user.Id, meditationProgramId, count);
        using (var client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(apiUrl, requestData);
                if (response.IsSuccessStatusCode)
                {
                    var recommendations = await response.Content.ReadAsStringAsync();
                    var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, int[]>>(recommendations);
                    recomendMedits = jsonObject["recommendations"].ToList();
                }
                else
                {
                    Console.WriteLine("Failed to get recommendations!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
        return recomendMedits;
    }
}
