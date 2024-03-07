using MediatR;

namespace Questeloper.Application.Hero.Queries.Handlers;

internal sealed class GetAllHeroesQueryHandler : IRequestHandler<GetAllHeroesQuery, IEnumerable<GetHeroResponse>>
{
    public Task<IEnumerable<GetHeroResponse>> Handle(GetAllHeroesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}