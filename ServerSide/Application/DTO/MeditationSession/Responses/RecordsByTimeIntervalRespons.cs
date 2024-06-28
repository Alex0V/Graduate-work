namespace Application.DTO.MeditationSession.Responses;

public sealed record RecordsByTimeIntervalRespons(
    DateTime CompletedDateTime, 
    string Meditation, 
    string SessionName);
