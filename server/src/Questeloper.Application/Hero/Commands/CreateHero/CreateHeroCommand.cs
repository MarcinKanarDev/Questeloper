using Questeloper.Application.Abstractions;

namespace Questeloper.Application.Hero.Commands.CreateHero;

public sealed record CreateHeroCommand(string Name, string HeroClass) : ICommand<int>;