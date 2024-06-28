using Domain.Entities;
using Infrastructure.Persistence.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class MeditationConfig : IEntityTypeConfiguration<Meditation>
{
    public void Configure(EntityTypeBuilder<Meditation> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Description);

        builder.Property(e => e.CreationDate)
            .IsRequired();

        builder.Property(e => e.FotoKey)
            .HasMaxLength(150);

        builder.Property(e => e.S3UrlFoto)
            .HasMaxLength(150);

        builder.Property(e => e.Duration)
            .IsRequired()
            .HasMaxLength(50);

        // Seed data
        new MeditationSeeding().Seed(builder);
    }
}
