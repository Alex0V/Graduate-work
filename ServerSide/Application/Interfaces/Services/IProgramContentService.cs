using Application.DTO.ProgramContent.Requests;
using Application.DTO.ProgramContent.Responses;
using ErrorOr;

namespace Application.Interfaces.Services;

public interface IProgramContentService
{
    Task<ErrorOr<List<ProgramContentResponse>>> GetAllProgramContentByProgramId(int id);
    Task<ErrorOr<Deleted>> Delete(int id);
    Task<ErrorOr<Created>> Add(ProgramContentRequest meditationRequest);
}
