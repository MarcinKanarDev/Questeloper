using Questeloper.Application.Abstractions;
using Questeloper.Domain.Repositories;
using Questeloper.Domain.ValueObjects;

namespace Questeloper.Application.Hero.Commands.CreateHero;

internal sealed class CreateHeroCommandHandler(IHeroRepository heroRepository)
    : ICommandHandler<CreateHeroCommand, int>
{
    public async Task<int> Handle(CreateHeroCommand request, CancellationToken cancellationToken)
    {
        var hero = new Domain.Entities.Hero(request.Name, new HeroClassName(request.HeroClass));
        
        await heroRepository.CreateHeroAsync(hero);
        await heroRepository.CompleteAsync();

        return hero.Id;
    }
}