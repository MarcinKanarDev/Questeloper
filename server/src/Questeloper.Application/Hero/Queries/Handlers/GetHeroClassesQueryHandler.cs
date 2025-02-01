using Questeloper.Application.Abstractions;
using Questeloper.Domain.Repositories;

namespace Questeloper.Application.Hero.Queries.Handlers;

internal sealed class GetHeroClassesQueryHandler(IHeroRepository heroRepository)  : IQueryHandler<GetHeroClassesQuery, IEnumerable<GetHeroClassesResponse>>
{
    public async Task<IEnumerable<GetHeroClassesResponse>> Handle(GetHeroClassesQuery request, CancellationToken cancellationToken)
    {
        var classes =
            await heroRepository.GetHeroClasses();

        return classes.Select(x => x.ToResponse());
    }
}
