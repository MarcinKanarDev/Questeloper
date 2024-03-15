namespace Questeloper.Application.Hero.Queries;

public sealed record GetHeroResponse(
    string Name,
    int Level,
    string HeroClass,
    int Experience,
    int HealthPoints,
    int ManaPoints);
