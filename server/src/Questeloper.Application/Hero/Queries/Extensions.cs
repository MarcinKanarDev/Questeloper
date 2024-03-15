namespace Questeloper.Application.Hero.Queries;

internal static class Extensions
{
    public static GetHeroResponse ToResponse(this Domain.Entities.Hero hero) => 
        new GetHeroResponse(
            hero.HeroName.Name,
            hero.Level.LevelValue,
            hero.HeroClass.Name,
            hero.Experience.ExperiencePoints,
            hero.HealthPoints.Points,
            hero.ManaPoints.Points); 
}