using Questeloper.Application.Abstractions;
using Questeloper.Domain.Exceptions;
using Questeloper.Domain.Repositories;

namespace Questeloper.Application.User.Queries.Handlers;

internal sealed class GetUserByIdQueryHandler(IUserRepository userRepository)
    : IQueryHandler<GetUserByIdQuery, GetUserResponse>
{
    public async Task<GetUserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.Id)
                   ?? throw new UserNotFoundException(request.Id);;

        return user.ToResponse();
    }
}