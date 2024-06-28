using Domain.Primitives;

namespace Domain.Entities;

public sealed class User : Entity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Token { get; set; }
    public string? Role { get; set; }
    //public int? RoleId { get; set; }
    //public Role? Role {  get; set; }

    public string? RefreshToken { get; set; }

    public DateTime RefreshTokenExpiryTime { get; set; }

    public string? ResetPasswordToken { get; set; }

    public DateTime ResetPasswordExpiry { get; set; }

    public List<MeditationSession>? MeditationSessions { get; set; }
    public List<Music>? Musics { get; set; }
    public List<Rating>? Ratings { get; set; }
}
