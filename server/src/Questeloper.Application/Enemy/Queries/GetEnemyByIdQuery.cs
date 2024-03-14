using Questeloper.Application.Abstractions;

namespace Questeloper.Application.Enemy.Queries;

public sealed record GetEnemyByIdQuery(int Id) : IQuery<GetEnemyResponse>;