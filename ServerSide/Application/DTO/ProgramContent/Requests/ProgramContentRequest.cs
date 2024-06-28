using Microsoft.AspNetCore.Http;

namespace Application.DTO.ProgramContent.Requests;

public sealed record ProgramContentRequest(
    string ContentName,
    string Duration,
    int MeditationProgramId, 
    IFormFile File);
