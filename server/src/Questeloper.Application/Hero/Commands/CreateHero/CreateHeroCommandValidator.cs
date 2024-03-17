using FluentValidation;

namespace Questeloper.Application.Hero.Commands.CreateHero;

internal sealed class CreateHeroCommandValidator : AbstractValidator<CreateHeroCommand>
{
    public CreateHeroCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Hero name is required.")
            .MaximumLength(200).WithMessage("Hero name must not exceed 200 characters.")
            .MinimumLength(2).WithMessage("Hero name must be longer than 2 characters.");

        RuleFor(x => x.HeroClass)
            .NotEmpty().WithMessage("Hero class is required.");
    }
}