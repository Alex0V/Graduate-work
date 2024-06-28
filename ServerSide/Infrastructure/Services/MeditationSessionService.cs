using Application.Interfaces.Services;
using Domain.Interfaces.Repositories;
using Application.DTO.MeditationSession.Requests;
using ErrorOr;
using Application.Mappers;

namespace Infrastructure.Services;

public class MeditationSessionService : IMeditationSessionService
{
    private readonly IMeditationSessionRepository _meditationSessionRepository;
    private readonly IUserRepository _userRepository;
    private readonly MeditationSessionMapper _mapper;
    public MeditationSessionService(IMeditationSessionRepository meditationSessionRepository, IUserRepository userRepository)
    {
        _meditationSessionRepository = meditationSessionRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Created>> Insert(MeditationSessionRequest request)
    {
        int userId = await _userRepository.GetIdByUserName(request.UserName);
        DateTime currentDate = DateTime.Now;

        var review = _mapper.MeditationSessionRequestToMeditationSession(request);
        review.UserId = userId;
        review.AuditionDate = currentDate;
        await _meditationSessionRepository.AddAsync(review);

        return Result.Created;
    }
}
