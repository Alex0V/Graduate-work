using Domain.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public sealed class Category : Entity
{
    [Required]
    public string CategoryName { get; set; } = string.Empty;

    public List<MeditationCategory>? MeditationCategories { get; set; }
}