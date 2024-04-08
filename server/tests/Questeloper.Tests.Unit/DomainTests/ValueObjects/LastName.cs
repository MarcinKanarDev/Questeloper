using FluentAssertions;
using Questeloper.Domain.Exceptions;
using Questeloper.Domain.ValueObjects;

namespace Questeloper.Tests.Unit.DomainTests.ValueObjects;

public class LastNameTests
{
    [Fact]
    public void Constructor_WhenValueIsNull_ShouldThrowValueIsEmptyException()
    {
        // Act
        var act = () => new LastName(null);

        // Assert
        act.Should().Throw<ValueIsEmptyException>();
    }

    [Fact]
    public void Constructor_WhenValueIsWhitespace_ShouldThrowValueIsEmptyException()
    {
        // Act
        var act = () => new LastName(" ");

        // Assert
        act.Should().Throw<ValueIsEmptyException>();
    }

    [Theory]
    [InlineData("Doe")]
    public void Constructor_ForValidValue_ShouldNotThrow(string validValue)
    {
        // Act
        var act = () => new LastName(validValue);

        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [InlineData("Yo")] // Too short
    public void Constructor_WhenValueIsIncorrectLength_ShouldThrowValueIncorrectLengthException(string invalidValue)
    {
        // Act
        var act = () => new LastName(invalidValue);

        // Assert
        act.Should().Throw<ValueIncorrectLengthException>();
    }

    [Fact]
    public void ImplicitConversion_ToString_ShouldReturnCorrectStringValue()
    {
        // Arrange
        var lastName = new LastName("Smith");

        // Act
        string result = lastName;
        
        // Assert
        result.Should().Be("Smith");
    }

    [Fact]
    public void ExplicitConversion_FromString_ShouldCreateValidObject()
    {
        // Act
        var lastName = (LastName)"Johnson";

        // Assert
        lastName.Should().NotBeNull();
        lastName.Value.Should().Be("Johnson");
    }

    [Fact]
    public void ToString_Invoked_ShouldReturnCorrectValue()
    {
        // Arrange
        var lastName = new LastName("Brown");

        // Act
        var result = lastName.ToString();

        // Assert
        result.Should().Be("Brown");
    }
}