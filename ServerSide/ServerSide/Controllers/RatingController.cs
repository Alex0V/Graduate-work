using Application.DTO.Rating;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeditAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RatingController : ApiController
{
    private readonly IRatingService _ratingService;
    public RatingController(IRatingService ratingService)
    {
        _ratingService = ratingService;
    }

    [Authorize]
    [HttpGet("getrating")]
    public async Task<IActionResult> GetUserScoreByProgram([FromQuery] int programId, [FromQuery] string userName)
    {
        var result = await _ratingService.GetProgramScore(userName, programId);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [Authorize]
    [HttpPut("change")]
    public async Task<IActionResult> PutCourseRating([FromBody] RatingRequest ratingRequest)
    {
        var result = await _ratingService.AddOrUpdateScore(ratingRequest);
        return result.Match(
            result => Ok(),
            errors => Problem(errors));
    }
}
