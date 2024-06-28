namespace Application.DTO.ProgramContent.Responses;

public sealed record ProgramContentResponse(
    int Id,
    string ContentName,
    string Duration,
    int MeditationProgramId,
    string S3UrlAudio);
