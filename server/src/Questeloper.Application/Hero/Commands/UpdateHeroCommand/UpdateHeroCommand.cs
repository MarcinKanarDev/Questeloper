using MediatR;

namespace Questeloper.Application.Hero.Commands.UpdateHeroCommand;

public sealed record UpdateHeroCommand(int Id, string NewName) : IRequest;