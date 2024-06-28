using Microsoft.AspNetCore.Http;

namespace Application.DTO.MeditationProgram.Requests;

public sealed record MeditationProgramRequest(
    int MeditationId, 
    string ProgramName, 
    IFormFile File);
