using MediatR;

namespace Questeloper.Application.Hero.Queries.Handlers;

internal sealed class GetAllHeroesQueryHandler : IRequestHandler<GetAllHeroesQuery, IEnumerable<GetHeroResponse>>
{
    private readonly IHeroRepository _heroRepository;

    public GetAllHeroesQueryHandler(IHeroRepository heroRepository)
    {
        _heroRepository = heroRepository;
    }

    public async Task<IEnumerable<GetHeroResponse>> Handle(GetAllHeroesQuery request, CancellationToken cancellationToken)
    {
        var result = await _heroRepository.GetAllHeroesAsync();

        return result;
    }
}