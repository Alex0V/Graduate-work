using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IMeditationProgramRepository : IGenericRepository<MeditationProgram>
{
    Task<MeditationProgram> GetWtihContentById(int id);
    Task<List<MeditationProgram>> GetAllByIdsAsync(List<int> ids);
}
