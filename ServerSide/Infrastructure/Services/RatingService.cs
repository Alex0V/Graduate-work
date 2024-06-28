using Application.DTO.Rating;
using Application.Interfaces.Services;
using Application.Mappers;
using Domain.Interfaces.Repositories;
using ErrorOr;

namespace Infrastructure.Services;

public class RatingService : IRatingService
{
    private readonly IRatingRepository _ratingRepository;
    private readonly IUserRepository _userRepository;
    private readonly RatingMapper _ratingMapper;

    public RatingService(IRatingRepository ratingRepository, RatingMapper ratingMapper, IUserRepository userRepository)
    {
        _ratingRepository = ratingRepository;
        _ratingMapper = ratingMapper;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<RatingResponse>> GetProgramScore(string userName, int MeditationProgramId)
    {
        var user = await _userRepository.GetUserByUsernameAsync(userName);
        if (user is null)
        {
            return Error.NotFound(description: "User not found");
        }
        var response = await _ratingRepository.GetScoreByUserIdAndProgramIdAsync(user.Id, MeditationProgramId);
        if (response is null)
        {
            return Error.NotFound(description: "Rating not found");
        }
        return _ratingMapper.RatingToRatingResponse(response);
    }

    public async Task<ErrorOr<Success>> AddOrUpdateScore(RatingRequest ratingRequest)
    {
        var user = await _userRepository.GetUserByUsernameAsync(ratingRequest.userName);
        if (user is null)
        {
            return Error.NotFound(description: "User not found");
        }
        var rating = _ratingMapper.RatingRequestToRating(ratingRequest);
        rating.UserId = user.Id;
        var getrating = await _ratingRepository.GetScoreByUserIdAndProgramIdAsync(user.Id, ratingRequest.MeditationProgramId);
        if (getrating is null)
        {
            await _ratingRepository.AddAsync(rating);
        }
        else 
        {
            getrating.Score = ratingRequest.Score;
            await _ratingRepository.UpdateAsync(getrating);
        }
        return Result.Success;
    }
}
