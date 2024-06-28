using Application.DTO.MeditationSession.Requests;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeditAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MeditationSessionController : ApiController
{
    private readonly IMeditationSessionService _meditationSessionService;

    public MeditationSessionController(IMeditationSessionService meditationSessionService)
    {
        _meditationSessionService = meditationSessionService;
    }

    [Authorize]
    [HttpPost("add")]
    public async Task<IActionResult> AddCompletedSession([FromBody] MeditationSessionRequest meditationSessionRequest)
    {
        var result =  await _meditationSessionService.Insert(meditationSessionRequest);

        return result.Match(
            result => Ok(),
            errors => Problem(errors));
    }
}
