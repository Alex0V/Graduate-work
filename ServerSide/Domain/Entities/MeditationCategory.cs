namespace Domain.Entities;

public sealed class MeditationCategory
{
    public int MeditationId { get; set; }
    public Meditation? Meditation { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
