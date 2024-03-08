using MediatR;

namespace Questeloper.Application.Hero.Commands.DeleteHero;

internal sealed class DeleteHeroCommandHandler(IHeroRepository heroRepository) : IRequestHandler<DeleteHeroCommand>
{
    public async Task Handle(DeleteHeroCommand request, CancellationToken cancellationToken)
    {
        await heroRepository.DeleteHero(request.HeroId);
    }
}
