using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Seeding;

public class RoleSeeding : ISeeder<Role>
{
    private static readonly List<Role> sessions = new List<Role>()
    {
        new Role()
        {
            Id = 1,
            UserRole = "User"
        },
        new Role()
        {
            Id = 2,
            UserRole = "Admin"
        }
    };

    public void Seed(EntityTypeBuilder<Role> builder) => builder.HasData(sessions);
}
