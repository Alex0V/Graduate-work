using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.DTO.Others;
using Application.Interfaces;
using Application.Interfaces.Services;
using Application.DTO.User.Requests;

namespace MeditAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ApiController
{
    private readonly IUserService _userService;
    private readonly IEmailService _emailService;

    public UserController(IUserService userService, IEmailService emailService)
    {
        _userService = userService;
        _emailService = emailService;
    }


    [AllowAnonymous]
    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] LoginRequestDto loginRequestDto)
    {
        var response = await _userService.LoginAsync(loginRequestDto);
        return response.Match(
            response => Ok(response),
            errors => Problem(errors));
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterRequestDto registerRequestDto)
    {
        await _userService.RegisterAsync(registerRequestDto);
        return Ok(new
        {
            StatusCode = 200,
            Message = "User Registered!"
        });
    }

    [AllowAnonymous]
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] TokenApiDto tokenApiDto)
    {
        var response = await _userService.RefreshToken(tokenApiDto);
        return response.Match(
            response => Ok(response),
            errors => Problem(errors));
    }

    [AllowAnonymous]
    [HttpPost("send-reset-email/{email}")]
    public async Task<IActionResult> SendEmail(string email)
    {
        await _emailService.SendEmail(email);
        return Ok(new {
            StatusCode = 200,
            Message = "Email Sent!"
        });
    }

    [AllowAnonymous]
    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
    {
        await _userService.ResetPassword(resetPasswordDto);
        return Ok(new
        {
            StatusCode = 200,
            Message = "Password Reset Successfully"
        });
    }
}
