using Domain.Entities;
using Infrastructure.Persistence.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class RatingConfig : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne(x => x.User)
            .WithMany(x => x.Ratings)
            .HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.MeditationProgram)
            .WithMany(x => x.Ratings)
            .HasForeignKey(x => x.MeditationProgramId);

        new RatinSeeding().Seed(builder);
    }
}
