using MediatR;
using Questeloper.Domain.Repositories;

namespace Questeloper.Application.Hero.Queries.Handlers;

internal sealed class GetAllHeroesQueryHandler(IHeroRepository heroRepository) : IRequestHandler<GetAllHeroesQuery, IEnumerable<GetHeroResponse>>
{
    public async Task<IEnumerable<GetHeroResponse>> Handle(GetAllHeroesQuery request, CancellationToken cancellationToken)
    {
        var heroes = await heroRepository.GetHeroesAsync();

        return heroes.Select(x => x.ToResponse());
    }
}