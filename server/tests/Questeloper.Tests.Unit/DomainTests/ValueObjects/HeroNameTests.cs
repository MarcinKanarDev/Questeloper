using FluentAssertions;
using Questeloper.Domain.Exceptions;
using Questeloper.Domain.ValueObjects;

namespace Questeloper.Tests.Unit.DomainTests.ValueObjects;

public class HeroNameTests
{
    [Fact]
    public void Constructor_WhenValueIsNull_ShouldThrowValueIsEmptyException()
    {
        // Act
        var act = () => new HeroName(null);

        // Assert
        act.Should().Throw<ValueIsEmptyException>();
    }

    [Fact]
    public void Constructor_WhenValueIsWhitespace_ShouldThrowValueIsEmptyException()
    {
        // Act
        var act = () => new HeroName(" ");

        // Assert
        act.Should().Throw<ValueIsEmptyException>();
    }

    [Theory]
    [InlineData("Batman")] 
    public void Constructor_ForValidValue_ShouldNotThrow(string validValue)
    {
        // Act
        var act = () => new HeroName(validValue);

        // Assert
        act.Should().NotThrow();
    }

    [Fact]
    public void ImplicitConversion_ToString_ShouldReturnCorrectStringValue()
    {
        // Arrange
        var heroName = new HeroName("Superman");

        // Act
        string result = heroName;
        
        // Assert
        result.Should().Be("Superman");
    }

    [Fact]
    public void ExplicitConversion_FromString_ShouldCreateValidObject()
    {
        // Act
        var heroName = (HeroName)"Wonder Woman";

        // Assert
        heroName.Should().NotBeNull();
        heroName.Value.Should().Be("Wonder Woman");
    }

    [Fact]
    public void ToString_Invoked_ShouldReturnCorrectValue()
    {
        // Arrange
        var heroName = new HeroName("Iron Man");

        // Act
        var result = heroName.ToString();

        // Assert
        result.Should().Be("Iron Man");
    }
}
