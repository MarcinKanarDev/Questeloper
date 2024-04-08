using FluentAssertions;
using Questeloper.Domain.Exceptions;
using Questeloper.Domain.ValueObjects;

namespace Questeloper.Tests.Unit.DomainTests.ValueObjects;

public class PasswordTests
{
    [Fact]
    public void Constructor_WhenValueIsNull_ShouldThrowValueIsEmptyException()
    {
        // Act
        var act = () => new Password(null);

        // Assert
        act.Should().Throw<ValueIsEmptyException>();
    }

    [Fact]
    public void Constructor_WhenValueIsWhitespace_ShouldThrowValueIsEmptyException()
    {
        // Act
        var act = () => new Password(" ");

        // Assert
        act.Should().Throw<ValueIsEmptyException>();
    }

    [Theory]
    [InlineData("password123")]
    public void Constructor_ForValidValue_ShouldNotThrow(string validValue)
    {
        // Act
        var act = () => new Password(validValue);

        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [InlineData("short")]
    public void Constructor_WhenValueIsIncorrectLength_ShouldThrowValueIncorrectLengthException(string invalidValue)
    {
        // Act
        var act = () => new Password(invalidValue);

        // Assert
        act.Should().Throw<ValueIncorrectLengthException>();
    }

    [Fact]
    public void ImplicitConversion_ToString_ShouldReturnCorrectStringValue()
    {
        // Arrange
        var password = new Password("SecurePassword123");

        // Act
        string result = password;
        
        // Assert
        result.Should().Be("SecurePassword123");
    }

    [Fact]
    public void ExplicitConversion_FromString_ShouldCreateValidObject()
    {
        // Act
        var password = (Password)"AnotherSecurePassword123";

        // Assert
        password.Should().NotBeNull();
        password.Value.Should().Be("AnotherSecurePassword123");
    }

    [Fact]
    public void ToString_Invoked_ShouldReturnCorrectValue()
    {
        // Arrange
        var password = new Password("PasswordToString");

        // Act
        var result = password.ToString();

        // Assert
        result.Should().Be("PasswordToString");
    }
}