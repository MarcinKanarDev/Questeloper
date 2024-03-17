using FluentAssertions;
using FluentValidation.TestHelper;
using Questeloper.Application.Hero.Commands.CreateHero;

namespace Questeloper.Tests.Unit.Hero.Commands;

public class CreateHeroCommandValidatorTests
{
    private readonly CreateHeroCommandValidator _validator = new();

    [Fact]
    public async Task CreateHeroCommandValidator_ForValidCommand_ShouldBeValidAndNotHaveAnyValidationErrors()
    {
        //Arrange
        var command = new CreateHeroCommand("Hero", "Backend Developer");

        //Act
        var result = await _validator.TestValidateAsync(command);

        //Assert
        result.IsValid.Should().BeTrue();
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public async Task CreateHeroCommandValidator_ForEmptyCommandProperties_ShouldBeNotBeValidAndHaveValidationErrors()
    {
        //Arrange
        var command = new CreateHeroCommand("", "");

        //Act
        var result = await _validator.TestValidateAsync(command);

        //Assert
        result.IsValid.Should().BeFalse();
        result
            .ShouldHaveValidationErrorFor(x => x.Name)
            .WithErrorMessage("Hero name is required.");
        result
            .ShouldHaveValidationErrorFor(x => x.HeroClass)
            .WithErrorMessage("Hero class is required.");
    }

    [Theory]
    [InlineData("A")]
    [InlineData("This name is way too long and definitely exceeds two hundred characters." +
                "This name is way too long and definitely exceeds two hundred characters." +
                "This name is way too long and definitely exceeds two hundred characters.")]
    public async Task CreateHeroCommandValidator_ForWrongCommandPropertiesLength_ShouldBeNotBeValidAndHaveValidationErrors(
        string name)
    {
        //Arrange
        var command = new CreateHeroCommand(name, "");

        //Act
        var result = await _validator.TestValidateAsync(command);

        //Assert
        result.IsValid.Should().BeFalse();
        result
            .ShouldHaveValidationErrorFor(x => x.Name)
            .WithErrorMessage(command.Name.Length < 2
                ? "Hero name must be longer than 2 characters."
                : "Hero name must not exceed 200 characters.");
    }
}