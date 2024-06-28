namespace Application.DTO.Meditation.Responses;

public sealed record MeditationListItemResponse(
    int Id, 
    string? Name, 
    string? Description,
    DateTime CreationDate,
    string? S3UrlFoto,
    string? Duration
);
