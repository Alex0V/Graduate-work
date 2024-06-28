using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Seeding;

public class RatinSeeding : ISeeder<Rating>
{
    private static readonly List<Rating> sessions = new List<Rating>()
    {
        new Rating()
        {
            Id = 1,
            UserId = 2,
            MeditationProgramId = 5,
            Score = 5
        }
    };

    public void Seed(EntityTypeBuilder<Rating> builder) => builder.HasData(sessions);
}
