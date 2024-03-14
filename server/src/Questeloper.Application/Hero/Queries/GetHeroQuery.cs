using Questeloper.Application.Abstractions;

namespace Questeloper.Application.Hero.Queries;

public sealed record GetHeroQuery(int HeroId) : IQuery<GetHeroResponse>;