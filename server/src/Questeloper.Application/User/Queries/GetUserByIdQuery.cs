using Questeloper.Application.Abstractions;

namespace Questeloper.Application.User.Queries;

public sealed record GetUserByIdQuery(int Id) : IQuery<GetUserResponse>;
