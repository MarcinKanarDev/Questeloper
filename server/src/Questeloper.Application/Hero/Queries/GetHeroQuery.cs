using MediatR;

namespace Questeloper.Application.Hero.Queries;

public sealed record GetHeroQuery(int HeroId) : IRequest<GetHeroResponse>;