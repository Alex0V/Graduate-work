using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations;

public class MusicConfig : IEntityTypeConfiguration<Music>
{
    public void Configure(EntityTypeBuilder<Music> builder)
    {
        builder.HasKey(sc => sc.Id);

        builder.HasOne(x => x.User)
            .WithMany(x => x.Musics)
            .HasForeignKey(x => x.UserId);
    }
}
