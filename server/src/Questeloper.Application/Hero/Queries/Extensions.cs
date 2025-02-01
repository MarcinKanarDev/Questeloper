using Questeloper.Domain.Entities;

namespace Questeloper.Application.Hero.Queries;

internal static class Extensions
{
    public static GetHeroResponse ToResponse(this Domain.Entities.Hero hero) => 
        new GetHeroResponse(
            hero.HeroName.Value,
            hero.Level.LevelValue,
            hero.HeroClass.ClassName.Value,
            hero.Experience.ExperiencePoints,
            hero.HealthPoints.Points,
            hero.ManaPoints.Points);

    public static GetHeroClassesResponse ToResponse(this HeroClass heroClass) =>
        new GetHeroClassesResponse(heroClass.ClassName.Value);
}