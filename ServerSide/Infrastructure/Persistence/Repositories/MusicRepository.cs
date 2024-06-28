using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class MusicRepository : GenericRepository<Music>, IMusicRepository
{
    public MusicRepository(MeditDBContext dbContext) : base(dbContext) { }

    public async Task<List<Music>> GetAllByUserIdAsync(int id)
    {
        return await _dbContext.Musics.Where(m => m.UserId == id).ToListAsync();
    }
}
