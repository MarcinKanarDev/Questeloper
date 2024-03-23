namespace Questeloper.Application.User.Commands.RegisterUser;

public static class RegisterUserCommandExtensions
{
    public static Domain.Entities.User MapToEntity(this RegisterUserCommand command,
        string hashedPassword, DateTime createdAt)
    {
        return new Domain.Entities.User(
            command.Email,
            hashedPassword,
            command.FirstName,
            command.LastName,
            command.NickName,
            createdAt);
    }
}