using Application.DTO.MeditationProgram.Requests;
using Application.DTO.MeditationProgram.Responses;
using ErrorOr;

namespace Application.Interfaces.Services;

public interface IMeditationProgramService
{
    Task<ErrorOr<List<MeditationProgramResponse>>> GetAllMeditationPrograms();
    Task<ErrorOr<MeditationProgramWithContentResponse>> GetMeditationProgramWithContenById(int id);
    Task<ErrorOr<List<MeditationProgramResponse>>> GetListMeditationProgramsByIds(List<int> ids);
    Task<ErrorOr<Deleted>> Delete(int id);
    Task<ErrorOr<Created>> Add(MeditationProgramRequest meditationRequest);
}
