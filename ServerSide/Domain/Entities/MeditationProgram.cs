using Domain.Primitives;

namespace Domain.Entities;

public sealed class MeditationProgram : Entity
{
    public int MeditationId { get; set; }
    public Meditation? Meditation { get; set; }
    public string? ProgramName { get; set; }
    public string? FotoKey { get; set; }
    public string? S3UrlFoto { get; set; }

    public List<ProgramContent>? ProgramContents { get; set; }
    public List<Rating>? Ratings { get; set; }
}
