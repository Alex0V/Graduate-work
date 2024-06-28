using Infrastructure.Persistence.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Persistence.Repositories;

public class MeditationRepository : GenericRepository<Meditation>, IMeditationRepository
{
    public MeditationRepository(MeditDBContext dbContext) : base(dbContext) { }
}
