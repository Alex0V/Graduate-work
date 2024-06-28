using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Seeding;

public class MeditationCategorySeeding : ISeeder<MeditationCategory>
{
    private static readonly List<MeditationCategory> meditationCategory = new List<MeditationCategory>()
    {
        new MeditationCategory()
        {
            MeditationId = 1,
            CategoryId = 5,

        },
        new MeditationCategory()
        {
            MeditationId = 1,
            CategoryId = 6,
        },
        new MeditationCategory()
        {
            MeditationId = 2,
            CategoryId = 1,
        },
        new MeditationCategory()
        {
            MeditationId = 3,
            CategoryId = 8,
        },
        new MeditationCategory()
        {
            MeditationId = 4,
            CategoryId = 1,
        },
        new MeditationCategory()
        {
            MeditationId = 4,
            CategoryId = 3,
        },
        new MeditationCategory()
        {
            MeditationId = 4,
            CategoryId = 6,
        },
        new MeditationCategory()
        {
            MeditationId = 5,
            CategoryId = 5,
        },
        new MeditationCategory()
        {
            MeditationId = 5,
            CategoryId = 6,
        },
        new MeditationCategory()
        {
            MeditationId = 6,
            CategoryId = 2,
        },
        new MeditationCategory()
        {
            MeditationId = 7,
            CategoryId = 2,
        },
        new MeditationCategory()
        {
            MeditationId = 7,
            CategoryId = 9,
        },
        new MeditationCategory()
        {
            MeditationId = 8,
            CategoryId = 1,
        },
        new MeditationCategory()
        {
            MeditationId = 8,
            CategoryId = 2,
        },
        new MeditationCategory()
        {
            MeditationId = 9,
            CategoryId = 2,
        },
        new MeditationCategory()
        {
            MeditationId = 10,
            CategoryId = 5,
        },
        new MeditationCategory()
        {
            MeditationId = 11,
            CategoryId = 1,
        },
        new MeditationCategory()
        {
            MeditationId = 11,
            CategoryId = 2,
        },
        new MeditationCategory()
        {
            MeditationId = 12,
            CategoryId = 1,
        },
        new MeditationCategory()
        {
            MeditationId = 12,
            CategoryId = 3,
        },
        new MeditationCategory()
        {
            MeditationId = 13,
            CategoryId = 1,
        },
        new MeditationCategory()
        {
            MeditationId = 14,
            CategoryId = 9,
        },
        new MeditationCategory()
        {
            MeditationId = 15,
            CategoryId = 9,
        },
        new MeditationCategory()
        {
            MeditationId = 15,
            CategoryId = 7,
        },
        new MeditationCategory()
        {
            MeditationId = 16,
            CategoryId = 2,
        },
        new MeditationCategory()
        {
            MeditationId = 17,
            CategoryId = 5,
        },
        new MeditationCategory()
        {
            MeditationId = 18,
            CategoryId = 2,
        },
        new MeditationCategory()
        {
            MeditationId = 19,
            CategoryId = 8,
        },
        new MeditationCategory()
        {
            MeditationId = 20,
            CategoryId = 6,
        },
        new MeditationCategory()
        {
            MeditationId = 21,
            CategoryId = 8,
        },
        new MeditationCategory()
        {
            MeditationId = 22,
            CategoryId = 1,
        },
        new MeditationCategory()
        {
            MeditationId = 22,
            CategoryId = 2,
        },
        new MeditationCategory()
        {
            MeditationId = 23,
            CategoryId = 1,
        },
        new MeditationCategory()
        {
            MeditationId = 23,
            CategoryId = 3,
        },
        new MeditationCategory()
        {
            MeditationId = 24,
            CategoryId = 1,
        },
        new MeditationCategory()
        {
            MeditationId = 24,
            CategoryId = 3,
        },
        new MeditationCategory()
        {
            MeditationId = 24,
            CategoryId = 6,
        },
        new MeditationCategory()
        {
            MeditationId = 25,
            CategoryId = 5,
        },
        new MeditationCategory()
        {
            MeditationId = 26,
            CategoryId = 4,
        },
        new MeditationCategory()
        {
            MeditationId = 26,
            CategoryId = 5,
        },
        new MeditationCategory()
        {
            MeditationId = 26,
            CategoryId = 9,
        },
        new MeditationCategory()
        {
            MeditationId = 27,
            CategoryId = 8,
        },
        new MeditationCategory()
        {
            MeditationId = 28,
            CategoryId = 7,
        },
        new MeditationCategory()
        {
            MeditationId = 29,
            CategoryId = 1,
        },
        new MeditationCategory()
        {
            MeditationId = 29,
            CategoryId = 2,
        },
        new MeditationCategory()
        {
            MeditationId = 30,
            CategoryId = 2,
        },
        new MeditationCategory()
        {
            MeditationId = 30,
            CategoryId = 7,
        }
    };

    public void Seed(EntityTypeBuilder<MeditationCategory> builder) => builder.HasData(meditationCategory);
}
