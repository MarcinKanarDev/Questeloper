using Questeloper.Application.Abstractions;
using Questeloper.Domain.Exceptions;
using Questeloper.Domain.Repositories;

namespace Questeloper.Application.Hero.Commands.UpdateHeroCommand;

internal sealed class UpdateHeroCommandHandler(IHeroRepository heroRepository) : ICommandHandler<UpdateHeroCommand>
{
    public async Task Handle(UpdateHeroCommand request, CancellationToken cancellationToken)
    {
        var heroes = await heroRepository.GetHeroesAsync();

        if (heroes.Any(x => x.HeroName.Name.Equals(request.NewName)))
        {
            throw new HeroNameAlreadyExistsException(request.NewName);
        }

        var hero = await heroRepository.GetByIdAsync(request.Id)
                   ?? throw new HeroNotFoundException(request.Id);

        hero.ChangeHeroName(request.NewName);
        await heroRepository.CompleteAsync();
    }
}