using Domain.Primitives;

namespace Domain.Entities;

public class ProgramContent : Entity
{
    public string? ContentName { get; set; }
    public int MeditationProgramId { get; set; }
    public MeditationProgram? MeditationProgram { get; set; }
    public string? Duration { get; set; }
    public string? AudioKey { get; set; }
    public string? S3UrlAudio { get; set; }

    public List<MeditationSession>? MeditationSessions { get; set; }
}
