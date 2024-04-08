using FluentAssertions;
using Questeloper.Domain.Exceptions;
using Questeloper.Domain.ValueObjects;

namespace Questeloper.Tests.Unit.DomainTests.ValueObjects;

public class NickNameTests
{
    [Fact]
    public void Constructor_WhenValueIsNull_ShouldThrowValueIsEmptyException()
    {
        // Act
        var act = () => new NickName(null);

        // Assert
        act.Should().Throw<ValueIsEmptyException>();
    }

    [Fact]
    public void Constructor_WhenValueIsWhitespace_ShouldThrowValueIsEmptyException()
    {
        // Act
        var act = () => new NickName(" ");

        // Assert
        act.Should().Throw<ValueIsEmptyException>();
    }

    [Theory]
    [InlineData("JohnDoe")] // Valid case
    public void Constructor_ForValidValue_ShouldNotThrow(string validValue)
    {
        // Act
        var act = () => new NickName(validValue);

        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [InlineData("Jo")] // Less than MinLength
    public void Constructor_WhenValueIsOutOfRange_ShouldThrowValueIncorrectLengthException(string invalidValue)
    {
        // Act
        var act = () => new NickName(invalidValue);

        // Assert
        act.Should().Throw<ValueIncorrectLengthException>();
    }

    [Fact]
    public void ImplicitConversion_ToString_ShouldReturnCorrectStringValue()
    {
        // Arrange
        var nickName = new NickName("Johnny");

        // Act
        string result = nickName;

        // Assert
        result.Should().Be("Johnny");
    }

    [Fact]
    public void ExplicitConversion_FromString_ShouldCreateValidObject()
    {
        // Act
        var nickName = (NickName)"Nickname";

        // Assert
        nickName.Should().NotBeNull();
        nickName.Value.Should().Be("Nickname");
    }

    [Fact]
    public void ToString_Invoked_ShouldReturnCorrectValue()
    {
        // Arrange
        var nickName = new NickName("HeroName");

        // Act
        var result = nickName.ToString();

        // Assert
        result.Should().Be("HeroName");
    }
}
