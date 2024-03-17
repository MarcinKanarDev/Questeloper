using FluentAssertions;
using Questeloper.Application.Hero.Commands.CreateHero;
using FluentValidation.TestHelper;

namespace Questeloper.Tests.Unit.Hero;

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
        result.ShouldHaveValidationErrorFor(x => x.Name);
        result.ShouldHaveValidationErrorFor(x => x.HeroClass);
    }
}