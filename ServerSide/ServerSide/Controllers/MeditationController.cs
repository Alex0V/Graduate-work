using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.DTO.Meditation.Requests;

namespace MeditAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MeditationController : ApiController
{
    private readonly IMeditationService _meditationService;
    public MeditationController(IMeditationService meditationService)
    {
        _meditationService = meditationService;
    }

    [Authorize]
    [HttpGet("all")]
    public async Task<IActionResult> GetAllMeditations()
    {
        var result = await _meditationService.GetAllMeditations();
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [Authorize]
    [HttpGet("getbyid/{id:int}")]
    public async Task<IActionResult> GetMeditation([FromRoute] int id)
    {
        var result = await _meditationService.GetMeditationById(id);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> DeleteMeditation([FromRoute] int id)
    {
        var result = await _meditationService.Delete(id);

        return result.Match(
            _ => NoContent(),
            errors => Problem(errors));
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("add")]
    public async Task<IActionResult> AddMeditation([FromForm] MeditationRequest meditationRequest)
    {
        var result = await _meditationService.Add(meditationRequest);
        return result.Match(
            result => Ok(),
            errors => Problem(errors));
    }
}
