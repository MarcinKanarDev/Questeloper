﻿using MediatR;
using Questeloper.Application.Hero.Queries;
using Questeloper.Domain.Exceptions;
using Questeloper.Domain.Repositories;

namespace Questeloper.Application.Hero.Commands.DeleteHero;

internal sealed class DeleteHeroCommandHandler(IHeroRepository heroRepository) : IRequestHandler<DeleteHeroCommand>
{
    public async Task Handle(DeleteHeroCommand request, CancellationToken cancellationToken)
    {
        var hero = await heroRepository.GetByIdAsync(request.HeroId);

        if (hero is null)
        {
            throw new HeroNotFoundException(request.HeroId);
        }

        await heroRepository.RemoveHero(hero);
        await heroRepository.CompleteAsync();
    }
}
