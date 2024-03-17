using FluentAssertions;
using FluentValidation.TestHelper;
using Questeloper.Application.Hero.Commands.UpdateHeroCommand;

namespace Questeloper.Tests.Unit.Hero.Commands;

public class UpdateHeroCommandValidatorTests
{
    private readonly UpdateHeroCommandValidator _validator = new();
    
    [Fact]
    public async Task UpdateHeroCommandValidator_ForValidCommand_ShouldBeValidAndNotHaveAnyValidationErrors()
    {
        //Arrange
        var command = new UpdateHeroCommand(1, "Name");
        
        //Act
        var result = await _validator.TestValidateAsync(command);
        
        //Assert
        result.IsValid.Should().BeTrue();
        result.ShouldNotHaveAnyValidationErrors();
    }
    
    [Fact]
    public async Task UpdateHeroCommandValidator_ForEmptyCommandProperties_ShouldBeNotBeValidAndHaveValidationErrors()
    {
        //Arrange
        var command = new UpdateHeroCommand(1, "");
        
        //Act
        var result = await _validator.TestValidateAsync(command);
        
        //Assert
        result.IsValid.Should().BeFalse();
        result
            .ShouldHaveValidationErrorFor(x => x.NewName)
            .WithErrorMessage("Hero name is required.");
    }
    
    [Fact]
    public async Task UpdateHeroCommandValidator_ForWrongCommandPropertiesLength_ShouldBeNotBeValidAndHaveValidationErrors()
    {
        //Arrange
        var command = new UpdateHeroCommand(1, "This name is way too long and definitely exceeds two hundred characters." +
            "This name is way too long and definitely exceeds two hundred characters." +
            "This name is way too long and definitely exceeds two hundred characters.");
        
        //Act
        var result = await _validator.TestValidateAsync(command);
        
        //Assert
        result.IsValid.Should().BeFalse();
        result
            .ShouldHaveValidationErrorFor(x => x.NewName)
            .WithErrorMessage("Hero name must not exceed 200 characters.");
    }
    
}