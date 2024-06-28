using Microsoft.AspNetCore.Http;

namespace Application.DTO.Meditation.Requests;

public sealed record MeditationRequest(
    string? Name,
    string? Description,
    string? Duration,
    List<int> CategoriesId,
    IFormFile File
);
