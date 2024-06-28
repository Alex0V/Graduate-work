using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations;

public class MeditationSessionConfig : IEntityTypeConfiguration<MeditationSession>
{
    public void Configure(EntityTypeBuilder<MeditationSession> builder)
    {
        builder.HasKey(sc => sc.Id);

        builder.HasOne(x => x.User)
            .WithMany(x => x.MeditationSessions)
            .HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.ProgramContent)
            .WithMany(x => x.MeditationSessions)
            .HasForeignKey(x => x.ProgramContentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
