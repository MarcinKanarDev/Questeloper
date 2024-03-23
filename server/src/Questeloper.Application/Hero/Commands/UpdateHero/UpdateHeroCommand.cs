using Questeloper.Application.Abstractions;

namespace Questeloper.Application.Hero.Commands.UpdateHero;

public sealed record UpdateHeroCommand(int Id, string NewName) : ICommand;