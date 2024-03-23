using Questeloper.Application.Abstractions;
using Questeloper.Application.Security;
using Questeloper.Domain.Abstractions;
using Questeloper.Domain.Exceptions;
using Questeloper.Domain.Repositories;

namespace Questeloper.Application.User.Commands.RegisterUser;

internal sealed class RegisterUserCommandHandler(IUserRepository userRepository, IPasswordService passwordService,
        IClock clock)
    : ICommandHandler<RegisterUserCommand, int>
{
    public async Task<int> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var isExists = userRepository.IsExists(command.Email, command.NickName);

        if (isExists)
        {
            throw new UserAlreadyExistsException();
        }

        var hashedPassword = passwordService.SecurePassword(command.Password);
        var user = command.MapToEntity(hashedPassword, clock.Current);
        
        await userRepository.CreateUserAsync(user);
        await userRepository.CompleteAsync();
        
        return user.Id;
    }
}