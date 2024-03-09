using MediatR;
using Questeloper.Domain.Repositories;

namespace Questeloper.Application.Hero.Queries.Handlers;

internal sealed class GetHeroQueryHandler(IHeroRepository heroRepository) : IRequestHandler<GetHeroQuery, GetHeroResponse>
{

    public async Task<GetHeroResponse> Handle(GetHeroQuery request, CancellationToken cancellationToken)
    {
        var result = await heroRepository.GetByIdAsync(request.HeroId);

        return null;
    }
}