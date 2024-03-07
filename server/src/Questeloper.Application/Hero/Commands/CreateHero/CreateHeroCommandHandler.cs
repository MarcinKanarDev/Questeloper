using MediatR;

namespace Questeloper.Application.Hero.Commands.CreateHero;

internal sealed class CreateHeroCommandHandler : IRequestHandler<CreateHeroCommand, int>
{
    public Task<int> Handle(CreateHeroCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}