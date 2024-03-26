using Questeloper.Application.Abstractions;
using Questeloper.Domain.Exceptions;
using Questeloper.Domain.Repositories;

namespace Questeloper.Application.Hero.Queries.Handlers;

internal sealed class GetHeroQueryHandler(IHeroRepository heroRepository) : IQueryHandler<GetHeroQuery, GetHeroResponse>
{
    public async Task<GetHeroResponse> Handle(GetHeroQuery request, CancellationToken cancellationToken)
    {
        var hero = 
            await heroRepository.GetByIdAsync(request.HeroId)
            ?? throw new ResourceNotFoundException(nameof(Domain.Entities.Hero), request.HeroId);

        return hero.ToResponse();
    }
}