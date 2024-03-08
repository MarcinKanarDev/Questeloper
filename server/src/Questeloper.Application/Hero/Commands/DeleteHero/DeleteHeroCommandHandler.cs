using MediatR;

namespace Questeloper.Application.Hero.Commands.DeleteHero;

internal sealed class DeleteHeroCommandHandler : IRequestHandler<DeleteHeroCommand>
{

    private readonly IHeroRepository _heroRepository;   
        
    public GetHeroQueryHandler(IHeroRepository heroRepository)
    {
        _heroRepository = heroRepository;
    }

    public async Task Handle(DeleteHeroCommand request, CancellationToken cancellationToken)
    {
        await _heroRepository.DeleteHero(request.HeroId);
    }
}