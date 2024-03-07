using MediatR;

namespace Questeloper.Application.Hero.Commands.CreateHero;

public sealed record CreateHeroCommand(string Name, string HeroClass) : IRequest<int>;