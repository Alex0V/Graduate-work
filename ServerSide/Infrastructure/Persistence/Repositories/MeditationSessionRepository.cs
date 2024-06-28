using Infrastructure.Persistence.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Persistence.Repositories;

public class MeditationSessionRepository : GenericRepository<MeditationSession>, IMeditationSessionRepository
{
    public MeditationSessionRepository(MeditDBContext dbContext) : base(dbContext) { }

}
