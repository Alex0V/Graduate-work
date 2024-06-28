using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IMeditationCategoryRepository
{
    Task AddAsync(MeditationCategory entity);
    Task DeleteByMeditationIdAsync(int meditationId);
}
