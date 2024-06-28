using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(MeditDBContext dbContext) : base(dbContext) { }
}
