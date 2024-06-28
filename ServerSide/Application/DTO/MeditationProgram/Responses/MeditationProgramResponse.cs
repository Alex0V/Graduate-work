namespace Application.DTO.MeditationProgram.Responses;

public sealed record MeditationProgramResponse(
    int Id,
    int MeditationId,
    string ProgramName,
    string? S3UrlFoto);
