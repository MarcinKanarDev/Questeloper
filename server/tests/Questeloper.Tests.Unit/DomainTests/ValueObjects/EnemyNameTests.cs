using FluentAssertions;
using Questeloper.Domain.Exceptions;
using Questeloper.Domain.ValueObjects;

namespace Questeloper.Tests.Unit.DomainTests.ValueObjects;

public class EnemyNameTests
{
    [Fact]
    public void Constructor_WhenValueIsNull_ShouldThrowValueIsEmptyException()
    {
        // Act
        var act = () => new EnemyName(null);

        // Assert
        act.Should().Throw<ValueIsEmptyException>();
    }

    [Fact]
    public void Constructor_WhenValueIsWhitespace_ShouldThrowValueIsEmptyException()
    {
        // Act
        var act = () => new EnemyName(" ");

        // Assert
        act.Should().Throw<ValueIsEmptyException>();
    }

    [Theory]
    [InlineData("LazyLoading")]
    public void Constructor_ForValidValue_ShouldNotThrow(string validValue)
    {
        // Act
        var act = () => new EnemyName(validValue);

        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [InlineData("Yo")]
    public void Constructor_WhenValueIsIncorrectLength_ShouldThrowValueIncorrectLengthException(string invalidValue)
    {
        // Act
        Action act = () => new EnemyName(invalidValue);

        // Assert
        act.Should().Throw<ValueIncorrectLengthException>();
    }

    [Fact]
    public void ImplicitConversion_ToString_ShouldReturnCorrectStringValue()
    {
        // Arrange
        var enemyName = new EnemyName("Sauron");

        // Act
        string result = enemyName;
        
        // Assert
        result.Should().Be("Sauron");
    }

    [Fact]
    public void ExplicitConversion_FromString_ShouldCreateValidObject()
    {
        // Act
        var enemyName = (EnemyName)"Darth Vader";

        // Assert
        enemyName.Should().NotBeNull();
        enemyName.Value.Should().Be("Darth Vader");
    }

    [Fact]
    public void ToString_Invoked_ShouldReturnCorrectValue()
    {
        // Arrange
        var enemyName = new EnemyName("Joker");

        // Act
        var result = enemyName.ToString();

        // Assert
        result.Should().Be("Joker");
    }
}