using Questeloper.Application.Abstractions;
using Questeloper.Application.Enemy.Queries;

namespace Questeloper.Application.User.Queries;

public sealed record GetUsersQuery : IQuery<IEnumerable<GetUserResponse>>;