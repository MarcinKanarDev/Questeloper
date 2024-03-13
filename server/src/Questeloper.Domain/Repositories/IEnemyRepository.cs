using Questeloper.Domain.Entities;

namespace Questeloper.Domain.Repositories;

public interface IEnemyRepository
{
    public Task<Enemy?> GetByIdAsync(int id);
    public Task<IEnumerable<Enemy>> GetEnemiesAsync();
}