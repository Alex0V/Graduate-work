using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class MeditationProgramRepository : GenericRepository<MeditationProgram>, IMeditationProgramRepository
{
    public MeditationProgramRepository(MeditDBContext dbContext) : base(dbContext) { }

    public async Task<MeditationProgram> GetWtihContentById(int id)
    {
        var meditationProgram = await _dbContext.MeditationPrograms
                                         .Include(mp => mp.ProgramContents)
                                         .FirstOrDefaultAsync(mp => mp.Id == id);
        return meditationProgram;
    }

    public async Task<List<MeditationProgram>> GetAllByIdsAsync(List<int> ids)
    {
        var meditationProgram = await _dbContext.MeditationPrograms
            .Where(mp => ids.Contains(mp.Id))
            .ToListAsync();
        return meditationProgram;
    }
}
