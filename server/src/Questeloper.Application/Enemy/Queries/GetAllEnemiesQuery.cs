using Questeloper.Application.Abstractions;

namespace Questeloper.Application.Enemy.Queries;

public record GetAllEnemiesQuery() : IQuery<IEnumerable<GetEnemyResponse>>;