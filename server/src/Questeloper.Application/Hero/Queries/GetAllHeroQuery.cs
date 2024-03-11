using MediatR;
using Questeloper.Application.Abstractions;

namespace Questeloper.Application.Hero.Queries;

public sealed record GetAllHeroesQuery : IQuery<IEnumerable<GetHeroResponse>>;