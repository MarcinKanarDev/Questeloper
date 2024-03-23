using Questeloper.Application.Abstractions;

namespace Questeloper.Application.User.Commands.RegisterUser;

public sealed record RegisterUserCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName,
    string NickName) : ICommand<int>;
