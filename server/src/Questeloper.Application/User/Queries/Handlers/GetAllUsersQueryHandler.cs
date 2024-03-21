using Questeloper.Application.Abstractions;
using Questeloper.Domain.Repositories;

namespace Questeloper.Application.User.Queries.Handlers;

internal sealed class GetAllUsersQueryHandler(IUserRepository userRepository)
    : IQueryHandler<GetUsersQuery, IEnumerable<GetUserResponse>>
{
    public async Task<IEnumerable<GetUserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetUsersAsync();

        return users.Select(x => x.ToResponse());
    }
}