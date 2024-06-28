using Domain.Primitives;

namespace Domain.Entities;

public sealed class MeditationSession : Entity
{
    public int UserId { get; set; }
    public User? User { get; set; }

    public int ProgramContentId { get; set; }
    public ProgramContent? ProgramContent { get; set; }

    public DateTime AuditionDate { get; set; }
    //public string? StopTime { get; set;  }
}