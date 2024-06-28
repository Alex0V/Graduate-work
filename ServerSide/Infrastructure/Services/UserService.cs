using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Application.DTO.Others;
using Application.DTO.User.Requests;
using Application.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using ErrorOr;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    #region Login
    public async Task<ErrorOr<TokenApiDto>> LoginAsync(LoginRequestDto loginRequestDto)
    {
        var user = await _userRepository.GetUserByUsernameAsync(loginRequestDto.UserName);
        if (user == null)
        {
            return Error.NotFound(description: "User not found");
        }
        if (!PasswordHasher.VerifyPassword(loginRequestDto.Password, user.Password))
        {
            return Error.Validation(description: "Password is Incorect");
        }

        user.Token = CreateJwt(user);
        var newAccessToken = user.Token;
        var newRefreshToken = await CreateRefreshToken();
        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(30);
        await _userRepository.UpdateAsync(user);

        return new TokenApiDto()
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken
        };
    }
    #endregion

    #region Register
    public async Task<ErrorOr<Success>> RegisterAsync(RegisterRequestDto registerRequestDto)
    {
        if (registerRequestDto == null)
        {
            return Error.Validation(description: "Data is empty");
        }
        if (await _userRepository.CheckUserNameExistAsync(registerRequestDto.UserName))
        {
            return Error.Failure(description: "Username already exists");
        }
        if (await _userRepository.CheckEmailExistAsync(registerRequestDto.Email))
        {
            return Error.Failure(description: "Email already exists");
        }
        var pass = CheckPasswordStrength(registerRequestDto.Password);
        if (!string.IsNullOrEmpty(pass))
        {
            return Error.Validation(description: "The password is not reliable");
        }
        var user = new User()
        {
            FirstName = registerRequestDto.FirstName,
            LastName = registerRequestDto.LastName,
            UserName = registerRequestDto.UserName,
            Email = registerRequestDto.Email,
            Password = PasswordHasher.HashPassword(registerRequestDto.Password),
            Role = "User",

        };
        await _userRepository.CreateAsync(user);
        return Result.Success;
    }

    private string CheckPasswordStrength(string password)
    {
        StringBuilder sb = new();
        if (password.Length < 8)
        {
            sb.Append("Minimun password length should be 8" + Environment.NewLine);
        }
        if (!(Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]") && Regex.IsMatch(password, "[0-9]")))
        {
            sb.Append("Password should be Alphanumeric" + Environment.NewLine);
        }
        if (!Regex.IsMatch(password, "[<,>,@,!,#,$,%,^,&,*,(,),_,+,\\[,\\],{,},?,:,;,|,',\\,.,/,~,`,\\-,= ]"))
        {
            sb.Append("Password should contain special chars" + Environment.NewLine);
        }
        return sb.ToString();
    }
    #endregion

    #region RefreshTokens
    public async Task<ErrorOr<TokenApiDto>> RefreshToken(TokenApiDto tokenApiDto)
    {
        if (tokenApiDto is null)
        {
            return Error.Validation(description: "Invalid Client Request");
        }
        string accessToken = tokenApiDto.AccessToken;
        string refreshToken = tokenApiDto.RefreshToken;

        var principal = GetPrincipalFromExpiredToken(accessToken);
        string username = principal.Identity.Name;
        var user = await _userRepository.GetUserByUsernameAsync(username);
        if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
        {
            return Error.Validation(description: "Invalid access token or refresh token");
        }
        var newAccessToken = CreateJwt(user);
        var newRefreshToken = await CreateRefreshToken();
        user.RefreshToken = newRefreshToken;
        await _userRepository.UpdateAsync(user);
        return new TokenApiDto()
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken,
        };
    }

    private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var key = Encoding.ASCII.GetBytes("veryverysecret.....");
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateLifetime = false
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }
        return principal;

    }
    #endregion

    #region ResetPassword
    public async Task<ErrorOr<Success>> ResetPassword(ResetPasswordDto resetPasswordDto)
    {
        var newToken = resetPasswordDto.EmailToken.Replace(" ", "+");
        var user = await _userRepository.GetUserByEmailAsync(resetPasswordDto.Email);
        if (user is null)
        {
            return Error.NotFound(description: "User Doesn't Exist");
        }
        var tokenCode = user.ResetPasswordToken;
        DateTime emailTokenExiry = user.ResetPasswordExpiry;
        if (tokenCode != resetPasswordDto.EmailToken || emailTokenExiry < DateTime.Now)
        {
            return Error.Validation(description: "Invalid Reset link");
        }
        user.Password = PasswordHasher.HashPassword(resetPasswordDto.NewPassword);
        await _userRepository.UpdateAsync(user);
        return Result.Success;
    }
    #endregion

    #region TokenGeneration
    private static string CreateJwt(User user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("veryverysecret.....");
        var identity = new ClaimsIdentity(new Claim[]
        {
            new(ClaimTypes.Role, user.Role),
            new(ClaimTypes.Name, $"{user.UserName}"),
        });

        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = identity,
            Expires = DateTime.Now.AddHours(7),
            SigningCredentials = credentials,
        };
        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        return jwtTokenHandler.WriteToken(token);
    }

    private async Task<string> CreateRefreshToken()
    {
        var tokenBytes = RandomNumberGenerator.GetBytes(64);
        var refreshToken = Convert.ToBase64String(tokenBytes);
        if (await _userRepository.IsRefreshTokenValid(refreshToken))
        {
            return await CreateRefreshToken();
        }
        return refreshToken;
    }
    #endregion
}
