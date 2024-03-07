using MediatR;

namespace Questeloper.Application.Hero.Commands.DeleteHero;

public sealed record DeleteHeroCommand(int HeroId) : IRequest;