using Domain.Entities;
using Infrastructure.Persistence.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ProgramContentConfig : IEntityTypeConfiguration<ProgramContent>
{
    public void Configure(EntityTypeBuilder<ProgramContent> builder)
    {
        builder.HasKey(sc => sc.Id);

        builder.HasOne(x => x.MeditationProgram)
            .WithMany(x => x.ProgramContents)
            .HasForeignKey(x => x.MeditationProgramId);

        new ProgramContentSeeding().Seed(builder);
    }
}
