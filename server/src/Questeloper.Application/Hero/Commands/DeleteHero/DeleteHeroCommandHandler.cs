using MediatR;

namespace Questeloper.Application.Hero.Commands.DeleteHero;

internal sealed class DeleteHeroCommandHandler : IRequestHandler<DeleteHeroCommand>
{
    public Task Handle(DeleteHeroCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}