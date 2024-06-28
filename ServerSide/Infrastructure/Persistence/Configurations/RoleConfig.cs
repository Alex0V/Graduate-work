using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations;

public class RoleConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(sc => sc.Id);

        builder.Property(sc => sc.UserRole)
            .HasMaxLength(30)
            .IsRequired();

        // Seed data
        //new RoleSeeding().Seed(builder);
    }
}

