using Application.DTO.ProgramContent.Requests;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeditAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgramContentController : ApiController
{
    private readonly IProgramContentService _programContentService;

    public ProgramContentController(IProgramContentService programContentService)
    {
        _programContentService = programContentService;
    }

    [Authorize]
    [HttpGet("all/{id:int}")]
    public async Task<IActionResult> GetAllByMeditationProgramId([FromQuery] int id)
    {
        var result = await _programContentService.GetAllProgramContentByProgramId(id);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [Authorize]
    [HttpPost("add")]
    public async Task<IActionResult> AddContent([FromForm] ProgramContentRequest programContentRequest)
    {
        var result = await _programContentService.Add(programContentRequest);
        return result.Match(
            result => Ok(),
            errors => Problem(errors));
    }

    [Authorize]
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> DeleteProgram(int id)
    {
        var result = await _programContentService.Delete(id);
        return result.Match(
             _ => NoContent(),
            errors => Problem(errors));
    }
}
