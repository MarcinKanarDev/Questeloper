using Questeloper.Application.Abstractions;

namespace Questeloper.Application.User.Commands.LoginUserCommand;

public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand>
{
    public Task Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}