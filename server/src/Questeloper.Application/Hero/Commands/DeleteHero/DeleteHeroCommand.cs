using ICommand = Questeloper.Application.Abstractions.ICommand;

namespace Questeloper.Application.Hero.Commands.DeleteHero;

public sealed record DeleteHeroCommand(int HeroId) : ICommand;