using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Seeding;

public class CategorySeeding : ISeeder<Category>
{
    private static readonly List<Category> categories = new List<Category>()
    {
        new Category()
        {
            Id = 1,
            CategoryName = "Relax"
        },
        new Category()
        {
            Id = 2,
            CategoryName = "Focus"
        },
        new Category()
        {
            Id = 3,
            CategoryName = "Stress Relief"
        },
        new Category()
        {
            Id = 4,
            CategoryName = "Anxiety"
        },
        new Category()
        {
            Id = 5,
            CategoryName = "Mindfulness"
        },
        new Category()
        {
            Id = 6,
            CategoryName = "Self-Awareness"
        },
        new Category()
        {
            Id = 7,
            CategoryName = "Spiritual"
        },
        new Category()
        {
            Id = 8,
            CategoryName = "Compassion"
        },
        new Category()
        {
            Id = 9,
            CategoryName = "Breathwork"
        }
    };

    public void Seed(EntityTypeBuilder<Category> builder) => builder.HasData(categories);
}
