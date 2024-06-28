using Domain.Primitives;

namespace Domain.Entities;

public sealed class Meditation : Entity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreationDate { get; set; }
    public string? Duration { get; set; }
    public string? FotoKey { get; set; }
    public string? S3UrlFoto { get; set; }
    public List<MeditationProgram>? MeditationPrograms { get; set; }
    public List<MeditationCategory>? MeditationCategories { get; set; }
}
