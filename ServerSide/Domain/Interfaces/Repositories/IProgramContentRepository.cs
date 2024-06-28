using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IProgramContentRepository : IGenericRepository<ProgramContent>
{
    Task<List<ProgramContent>> GetAllByProgramId(int programId);
}
