using Domain.Primitives;

namespace Domain.Entities;

public class Rating : Entity
{
    public int UserId { get; set; }
    public int MeditationProgramId { get; set; }
    public int Score { get; set; }

    public User? User { get; set; }
    public MeditationProgram? MeditationProgram { get; set; }
}
