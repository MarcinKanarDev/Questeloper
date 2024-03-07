using MediatR;

namespace Questeloper.Application.Hero.Commands.UpdateHeroCommand;

internal sealed class UpdateHeroCommandHandler : IRequestHandler<UpdateHeroCommand>
{
    public Task Handle(UpdateHeroCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}