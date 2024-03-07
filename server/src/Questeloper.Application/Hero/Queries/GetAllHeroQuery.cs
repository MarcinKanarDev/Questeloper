using MediatR;

namespace Questeloper.Application.Hero.Queries;

public sealed record GetAllHeroesQuery : IRequest<IEnumerable<GetHeroResponse>>;