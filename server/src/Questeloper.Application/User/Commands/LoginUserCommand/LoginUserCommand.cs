using Questeloper.Application.Abstractions;

namespace Questeloper.Application.User.Commands.LoginUserCommand;

public sealed record LoginUserCommand(string UserName, string Password) : ICommand;
