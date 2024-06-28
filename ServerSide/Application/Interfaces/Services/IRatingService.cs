using Application.DTO.Rating;
using ErrorOr;

namespace Application.Interfaces.Services;

public interface IRatingService
{
    Task<ErrorOr<RatingResponse>> GetProgramScore(string userName, int MeditationProgramId);
    Task<ErrorOr<Success>> AddOrUpdateScore(RatingRequest ratingRequest);
}
