using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IMusicRepository : IGenericRepository<Music>
{
    Task<List<Music>> GetAllByUserIdAsync(int id);
}
