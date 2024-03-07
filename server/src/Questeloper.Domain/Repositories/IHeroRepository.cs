using Questeloper.Domain.Entities;

namespace Questeloper.Domain.Repositories;

public interface IHeroRepository
{
    public Task<Hero?> GetByIdAsync(int id);
    public Task<IEnumerable<Hero>> GetHeroesAsync();
    public Task CreateHeroAsync(Hero hero);
    public Task RemoveHero(Hero hero);
    public Task CompleteAsync();
}