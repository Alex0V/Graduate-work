using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Seeding;

namespace Infrastructure.Persistence.Configurations;

public class MeditationCategoryConfig : IEntityTypeConfiguration<MeditationCategory>
{
    public void Configure(EntityTypeBuilder<MeditationCategory> builder)
    {
        builder.HasKey(sc => new { sc.CategoryId, sc.MeditationId });

        builder.HasOne(x => x.Meditation)
            .WithMany(x => x.MeditationCategories)
            .HasForeignKey(x => x.MeditationId);

        builder.HasOne(x => x.Category)
            .WithMany(x => x.MeditationCategories)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        new MeditationCategorySeeding().Seed(builder);
    }
}
