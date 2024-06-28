using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Seeding;

namespace Infrastructure.Persistence.Configurations;

public class MeditationProgramConfig : IEntityTypeConfiguration<MeditationProgram>
{
    public void Configure(EntityTypeBuilder<MeditationProgram> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(x => x.ProgramName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.FotoKey)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(e => e.S3UrlFoto)
            .HasMaxLength(150)
            .IsRequired();

        builder.HasOne(x => x.Meditation)
            .WithMany(x => x.MeditationPrograms)
            .HasForeignKey(x => x.MeditationId)
            .OnDelete(DeleteBehavior.Cascade);

        new MeditationProgramSeeding().Seed(builder);
    }
}
