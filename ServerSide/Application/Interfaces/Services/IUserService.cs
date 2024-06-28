using Application.DTO.Others;
using Application.DTO.User.Requests;
using ErrorOr;

namespace Application.Interfaces.Services;

public interface IUserService
{
    Task<ErrorOr<TokenApiDto>> LoginAsync(LoginRequestDto loginRequestDto);
    Task<ErrorOr<Success>> RegisterAsync(RegisterRequestDto registerRequestDto);
    Task<ErrorOr<TokenApiDto>> RefreshToken(TokenApiDto tokenApiDto);
    Task<ErrorOr<Success>> ResetPassword(ResetPasswordDto resetPasswordDto);
}
