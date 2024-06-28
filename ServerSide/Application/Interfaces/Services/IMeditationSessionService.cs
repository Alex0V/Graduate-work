using Application.DTO.MeditationSession.Requests;
using ErrorOr;

namespace Application.Interfaces.Services;

public interface IMeditationSessionService
{
    Task<ErrorOr<Created>> Insert(MeditationSessionRequest request);
}
