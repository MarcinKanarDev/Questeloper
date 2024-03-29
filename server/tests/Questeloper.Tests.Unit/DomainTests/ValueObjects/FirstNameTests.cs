using FluentAssertions;
using Questeloper.Domain.Exceptions;
using Questeloper.Domain.ValueObjects;

namespace Questeloper.Tests.Unit.DomainTests.ValueObjects;

public class FirstNameTests
{
    [Fact]
    public void Constructor_WhenValueIsNull_ShouldThrowValueIsEmptyException()
    {
        // Act
        Action act = () => new FirstName(null);

        // Assert
        act.Should().Throw<ValueIsEmptyException>();
    }

    [Fact]
    public void Constructor_WhenValueIsWhitespace_ShouldThrowValueIsEmptyException()
    {
        // Act
        Action act = () => new FirstName(" ");

        // Assert
        act.Should().Throw<ValueIsEmptyException>();
    }

    [Theory]
    [InlineData("John")]
    public void Constructor_ForValidValue_ShouldNotThrow(string validValue)
    {
        // Act
        Action act = () => new FirstName(validValue);

        // Assert
        act.Should().NotThrow();
    }

    [Fact]
    public void ImplicitConversion_ToString_ShouldReturnCorrectStringValue()
    {
        // Arrange
        var firstName = new FirstName("Alex");

        // Act
        string result = firstName;
        
        // Assert
        result.Should().Be("Alex");
    }

    [Fact]
    public void ExplicitConversion_FromString_ShouldCreateValidObject()
    {
        // Act
        var firstName = (FirstName)"Emma";

        // Assert
        firstName.Should().NotBeNull();
        firstName.Value.Should().Be("Emma");
    }

    [Fact]
    public void ToString_Invoked_ShouldReturnCorrectValue()
    {
        // Arrange
        var firstName = new FirstName("Mike");

        // Act
        var result = firstName.ToString();

        // Assert
        result.Should().Be("Mike");
    }
}
