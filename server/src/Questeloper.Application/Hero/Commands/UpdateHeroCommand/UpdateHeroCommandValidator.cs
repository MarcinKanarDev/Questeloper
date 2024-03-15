using FluentValidation;

namespace Questeloper.Application.Hero.Commands.UpdateHeroCommand;

internal sealed class UpdateHeroCommandValidator : AbstractValidator<UpdateHeroCommand>
{
    public UpdateHeroCommandValidator()
    {
        RuleFor(x => x.NewName)
            .NotEmpty().WithMessage("Hero name is required.")
            .MaximumLength(200).WithMessage("Hero name must not exceed 200 characters.")
            .MinimumLength(2).WithMessage("Hero name must be longer than 2 characters.");
    }
}