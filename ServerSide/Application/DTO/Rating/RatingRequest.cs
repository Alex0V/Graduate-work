namespace Application.DTO.Rating;

public sealed record RatingRequest(string userName, int MeditationProgramId, int Score);
