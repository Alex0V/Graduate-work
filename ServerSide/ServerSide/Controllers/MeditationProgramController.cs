using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.DTO.MeditationProgram.Requests;
using Application.Interfaces;

namespace MeditAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MeditationProgramController : ApiController
{
    private readonly IMeditationProgramService _meditationProgramService;
    private readonly IRecommendationService _recommendationService;
    public MeditationProgramController(IMeditationProgramService meditationProgramService, IRecommendationService recommendationService)
    {
        _meditationProgramService = meditationProgramService;
        _recommendationService = recommendationService;
    }

    [Authorize]
    [HttpGet("all")]
    public async Task<IActionResult> GetAllMeditationPrograms()
    {
        var result = await _meditationProgramService.GetAllMeditationPrograms();
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [Authorize]
    [HttpGet("getbyid/{id:int}")]
    public async Task<IActionResult> GetMeditationWithContenById([FromRoute] int id)
    {
        var result = await _meditationProgramService.GetMeditationProgramWithContenById(id);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [Authorize]
    [HttpGet("getrecomendation")]
    public async Task<IActionResult> GetRecomendation([FromQuery] string userName, [FromQuery] int meditationProgramId)
    {
        var recomendations = await _recommendationService.GetRecomendationByNameAsync(userName, meditationProgramId);
        var result = await _meditationProgramService.GetListMeditationProgramsByIds(recomendations);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> DeleteMeditationProgram([FromRoute] int id)
    {
        var result = await _meditationProgramService.Delete(id);

        return result.Match(
            _ => NoContent(),
            errors => Problem(errors));
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("add")]
    public async Task<IActionResult> AddMeditationProgram([FromForm] MeditationProgramRequest meditationProgramRequest)
    {
        var result = await _meditationProgramService.Add(meditationProgramRequest);
        return result.Match(
            result => Ok(),
            errors => Problem(errors));
    }
}
