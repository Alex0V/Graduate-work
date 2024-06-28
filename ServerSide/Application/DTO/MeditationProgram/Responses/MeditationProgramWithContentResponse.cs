using Application.DTO.ProgramContent.Responses;

namespace Application.DTO.MeditationProgram.Responses;

public sealed record MeditationProgramWithContentResponse(
    int Id,
    string ProgramName,
    string? S3UrlFoto,
    List<ProgramContentResponse> ProgramContents);
