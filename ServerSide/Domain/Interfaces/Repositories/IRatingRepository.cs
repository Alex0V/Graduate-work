using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IRatingRepository : IGenericRepository<Rating>
{
    Task<Rating> GetScoreByUserIdAndProgramIdAsync(int userId, int programId);

}
