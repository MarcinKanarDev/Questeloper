using MediatR;

namespace Questeloper.Application.Hero.Queries.Handlers;

internal sealed class GetHeroQueryHandler : IRequestHandler<GetHeroQuery, GetHeroResponse>
{
    private readonly IHeroRepository _heroRepository;

    public GetHeroQueryHandler(IHeroRepository heroRepository)
    {
        _heroRepository = heroRepository;
    }

    public async Task<GetHeroResponse> Handle(GetHeroQuery request, CancellationToken cancellationToken)
    {
        var result = await _heroRepository.GetHero(request.HeroId);

        return result;
    }
}