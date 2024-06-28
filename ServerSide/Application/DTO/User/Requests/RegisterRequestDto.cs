namespace Application.DTO.User.Requests;

public sealed record RegisterRequestDto(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Password);
