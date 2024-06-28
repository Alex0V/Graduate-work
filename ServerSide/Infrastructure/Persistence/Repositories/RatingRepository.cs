using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class RatingRepository : GenericRepository<Rating>, IRatingRepository
{
    public RatingRepository(MeditDBContext dbContext) : base(dbContext) { }

    public async Task<Rating> GetScoreByUserIdAndProgramIdAsync(int userId, int programId)
    {
        return await _dbContext.Ratings
        .Include(cr => cr.User)
        .FirstOrDefaultAsync(cr => cr.MeditationProgramId == programId && cr.UserId == userId);
    }
}
