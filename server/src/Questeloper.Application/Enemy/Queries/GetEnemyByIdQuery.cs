using Questeloper.Application.Abstractions;

namespace Questeloper.Application.Enemy.Queries;

public record GetEnemyByIdQuery(int Id) : IQuery<GetEnemyResponse>;