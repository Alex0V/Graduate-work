using Domain.Primitives;

namespace Domain.Entities;

public sealed class Music : Entity
{
    public int UserId { get; set; }
    public User? User { get; set; }

    public string? Name { get; set; }
    public string? S3UrlAudio { get; set; }
    public string? AudioKey { get; set; }
}
