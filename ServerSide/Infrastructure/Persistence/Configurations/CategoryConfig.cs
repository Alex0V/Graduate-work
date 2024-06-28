using Domain.Entities;
using Infrastructure.Persistence.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.CategoryName)
        .IsRequired()
        .HasMaxLength(100);

        new CategorySeeding().Seed(builder);
    }
}
