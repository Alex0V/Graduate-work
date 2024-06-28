using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class MeditationCategoryRepository : IMeditationCategoryRepository
{
    private readonly MeditDBContext _dbContext;
    public MeditationCategoryRepository(MeditDBContext dbContext) 
    {
        _dbContext = dbContext;
    }
    public async Task AddAsync(MeditationCategory entity)
    {
        await _dbContext.MeditationCategories.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteByMeditationIdAsync(int meditationId)
    {
        var meditationCategory = await _dbContext.MeditationCategories.FirstOrDefaultAsync(mc => mc.MeditationId == meditationId);
        if (meditationCategory != null)
        {
            _dbContext.MeditationCategories.Remove(meditationCategory);
            await _dbContext.SaveChangesAsync();
        }
    }
}
