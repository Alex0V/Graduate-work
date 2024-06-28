using Application.DTO.Music.Requests;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeditAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MusicController : ApiController
{
    private readonly IMusicService _musicService;

    public MusicController(IMusicService musicService)
    {
        _musicService = musicService;
    }

    [Authorize]
    [HttpGet("user")]
    public async Task<IActionResult> GetAllUserMusic([FromQuery] string userName)
    {
        var result = await _musicService.GetAllUserMusic(userName);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [Authorize]
    [HttpPost("add")]
    public async Task<IActionResult> AddMusic([FromForm] MusicRequest musicRequest)
    {
        var result = await _musicService.AddMusic(musicRequest);
        return result.Match(
            result => Ok(),
            errors => Problem(errors));
    }

    [Authorize]
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> DeleteMusic([FromRoute] int id)
    {
        var result = await _musicService.RemoveMusic(id);
        return result.Match(
             _ => NoContent(),
            errors => Problem(errors));
    }
}
