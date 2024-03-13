using Questeloper.Application.Abstractions;
using Questeloper.Domain.Repositories;

namespace Questeloper.Application.Enemy.Queries.Handlers;

internal sealed class GetAllEnemiesQueryHandler(IEnemyRepository enemyRepository)
    : IQueryHandler<GetAllEnemiesQuery, IEnumerable<GetEnemyResponse>>
{
    public async Task<IEnumerable<GetEnemyResponse>> Handle(GetAllEnemiesQuery request, CancellationToken cancellationToken)
    {
        var enemies = await enemyRepository.GetEnemiesAsync();

        return enemies.Select(x => x.ToResponse());
    }
}