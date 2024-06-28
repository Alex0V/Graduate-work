using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(MeditDBContext dbContext) : base(dbContext) { }


}
