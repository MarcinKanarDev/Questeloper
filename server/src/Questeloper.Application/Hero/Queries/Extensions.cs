namespace Questeloper.Application.Hero.Queries;

internal static class Extensions
{
    public static GetHeroResponse ToResponse(this Domain.Entities.Hero hero) => 
        new GetHeroResponse(
            hero.HeroName.Name,
            hero.Level,
            hero.HeroClass.Name,
            hero.Experience,
            hero.HealthPoints); 
}