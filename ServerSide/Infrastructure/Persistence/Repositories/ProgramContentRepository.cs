using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class ProgramContentRepository : GenericRepository<ProgramContent>, IProgramContentRepository
    {
        public ProgramContentRepository(MeditDBContext dbContext) : base(dbContext) { }

        public async Task<List<ProgramContent>> GetAllByProgramId(int programId)
        {
            return await _dbContext.ProgramContents.Where(c => c.MeditationProgramId == programId).ToListAsync();
        }
    }
}
