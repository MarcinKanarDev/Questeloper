using Microsoft.EntityFrameworkCore;
using Questeloper.Domain.Entities;
using Questeloper.Domain.Repositories;

namespace Questeloper.Infrastructure.Persistence.Repositories;

internal sealed class EnemyRepository(QuesteloperDbContext questeloperDbContext) : IEnemyRepository
{
    public async Task<Enemy?> GetByIdAsync(int id) =>
        await questeloperDbContext.Enemies.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<Enemy>> GetEnemiesAsync() =>
        await questeloperDbContext.Enemies.ToListAsync();
}