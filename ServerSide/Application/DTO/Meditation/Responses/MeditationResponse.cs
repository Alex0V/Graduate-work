namespace Application.DTO.Meditation.Responses;

public sealed record MeditationResponse(
    string? Name, 
    string? Description, 
    DateTime? CreationDate, 
    string? S3UrlFoto,
    string? Duration
);

