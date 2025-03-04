﻿using Microsoft.EntityFrameworkCore;
using Questeloper.Domain.Entities;
using Questeloper.Domain.Repositories;

namespace Questeloper.Infrastructure.Persistence.Repositories;

internal sealed class HeroRepository(QuesteloperDbContext questeloperDbContext) : IHeroRepository
{
    public async Task<Hero?> GetByIdAsync(int id) =>
        await questeloperDbContext.Heroes.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<Hero>> GetHeroesAsync() =>
        await questeloperDbContext.Heroes
            .Include(h => h.HeroClass)
            .AsNoTracking()
            .ToListAsync();

    public async Task CreateHeroAsync(Hero hero) =>
        await questeloperDbContext.Heroes.AddAsync(hero);

    public Task RemoveHero(Hero hero) =>
        Task.FromResult(questeloperDbContext.Heroes.Remove(hero));

    public async Task<IEnumerable<HeroClass>> GetHeroClasses() =>
    await questeloperDbContext.HeroClasses.ToListAsync();

    public async Task CompleteAsync() =>
        await questeloperDbContext.SaveChangesAsync();
}