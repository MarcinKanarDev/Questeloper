using Questeloper.Domain.Entities;
using Questeloper.Domain.ValueObjects;

namespace Questeloper.Domain.Repositories;

public interface IHeroRepository
{
    public Task<Hero?> GetByIdAsync(int id);
    public Task<IEnumerable<Hero>> GetHeroesAsync();
    public Task CreateHeroAsync(Hero hero);
    public Task RemoveHero(Hero hero);
    public Task<IEnumerable<HeroClass>> GetHeroClasses();
    public Task CompleteAsync();
}