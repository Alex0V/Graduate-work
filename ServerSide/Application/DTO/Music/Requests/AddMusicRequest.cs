using Microsoft.AspNetCore.Http;

namespace Application.DTO.Music.Requests;

public sealed record MusicRequest(string userName, string Name, IFormFile File);
