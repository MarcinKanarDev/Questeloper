using MediatR;

namespace Questeloper.Application.Hero.Queries.Handlers;

internal sealed class GetHeroQueryHandler : IRequestHandler<GetHeroQuery, GetHeroResponse>
{
    public Task<GetHeroResponse> Handle(GetHeroQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}