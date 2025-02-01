using Questeloper.Application.Abstractions;

namespace Questeloper.Application.Hero.Queries;

public sealed record GetHeroClassesQuery : IQuery<IEnumerable<GetHeroClassesResponse>>;
