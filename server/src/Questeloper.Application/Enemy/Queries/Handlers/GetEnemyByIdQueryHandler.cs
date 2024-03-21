using Questeloper.Application.Abstractions;
using Questeloper.Domain.Exceptions;
using Questeloper.Domain.Repositories;

namespace Questeloper.Application.Enemy.Queries.Handlers;

internal sealed class GetEnemyByIdQueryHandler(IEnemyRepository enemyRepository)
    : IQueryHandler<GetEnemyByIdQuery, GetEnemyResponse>
{
    public async Task<GetEnemyResponse> Handle(GetEnemyByIdQuery request, CancellationToken cancellationToken)
    {
        var enemy = await enemyRepository.GetByIdAsync(request.Id)
                    ?? throw new EnemyNotFoundException(request.Id);
        
        return enemy.ToResponse();
    }
}