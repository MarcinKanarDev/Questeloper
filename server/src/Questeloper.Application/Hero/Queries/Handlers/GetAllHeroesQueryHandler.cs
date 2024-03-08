using MediatR;

namespace Questeloper.Application.Hero.Queries.Handlers;

internal sealed class GetAllHeroesQueryHandler(IHeroRepository heroRepository) : IRequestHandler<GetAllHeroesQuery, IEnumerable<GetHeroResponse>>
{

    public async Task<IEnumerable<GetHeroResponse>> Handle(GetAllHeroesQuery request, CancellationToken cancellationToken)
    {
        var result = await heroRepository.GetAllHeroesAsync();

        return result;
    }
}