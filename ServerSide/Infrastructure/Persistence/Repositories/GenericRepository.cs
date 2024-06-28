using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly MeditDBContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(MeditDBContext context)
    {
        _dbContext = context;
        _dbSet = context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await SaveAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var entityToDelete = await _dbSet.FindAsync(id);

        if (entityToDelete != null)
        {
            _dbSet.Remove(entityToDelete);
            await SaveAsync();
        }
    }
    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<T>> GetAllAsync(bool tracked = true)
    {
        IQueryable<T> query = _dbSet;

        if (!tracked)
        {
            query = query.AsNoTracking();
        }

        return await query.ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await SaveAsync();
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
