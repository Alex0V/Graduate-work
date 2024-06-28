namespace Application.DTO.MeditationSession.Requests;

public sealed record MeditationSessionRequest(
    int ProgramContentId, 
    string? UserName);
