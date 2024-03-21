using Questeloper.Application.Abstractions;

namespace Questeloper.Application.Enemy.Queries;

public sealed record GetAllEnemiesQuery : IQuery<IEnumerable<GetEnemyResponse>>;