using Application.DTO.Meditation.Requests;
using Application.DTO.Meditation.Responses;
using ErrorOr;

namespace Application.Interfaces.Services;

public interface IMeditationService
{
    Task<ErrorOr<List<MeditationListItemResponse>>> GetAllMeditations();
    Task<ErrorOr<MeditationResponse>> GetMeditationById(int id);
    Task<ErrorOr<Deleted>> Delete(int id);
    Task<ErrorOr<Created>> Add(MeditationRequest meditationRequest);
}
