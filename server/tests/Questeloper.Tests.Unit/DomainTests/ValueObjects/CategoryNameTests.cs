using FluentAssertions;
using Questeloper.Domain.Exceptions;
using Questeloper.Domain.ValueObjects;

namespace Questeloper.Tests.Unit.DomainTests.ValueObjects;

public class CategoryNameTests
{
    [Fact]
    public void Constructor_WhenValueIsNull_ShouldThrowValueIsEmptyException()
    {
        // Act
        var act = () => new CategoryName(null);

        // Assert
        act.Should().Throw<ValueIsEmptyException>();
    }

    [Fact]
    public void Constructor_WhenValueIsWhitespace_ShouldThrowValueIsEmptyException()
    {
        // Act
        var act = () => new CategoryName(" ");

        // Assert
        act.Should().Throw<ValueIsEmptyException>();
    }

    [Theory]
    [InlineData("abc")]
    public void Constructor_ForValidValue_ShouldNotThrow(string validValue)
    {
        // Act
        var act = () => new CategoryName(validValue);

        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [InlineData("ab")]
    public void Constructor_WhenValueIsIncorrectLength_ShouldThrowValueIncorrectLengthException(string invalidValue)
    {
        // Act
        var act = () => new CategoryName(invalidValue);

        // Assert
        act.Should().Throw<ValueIncorrectLengthException>();
    }

    [Fact]
    public void ImplicitConversion_ToString_ShouldReturnCorrectStringValue()
    {
        // Arrange
        var categoryName = new CategoryName("Programming");

        // Act
        var result = categoryName;
        
        // Assert
        result.Should().Be("Programming");
    }

    [Fact]
    public void ExplicitConversion_FromString_ShouldCreateValidObject()
    {
        // Act
        var categoryName = (CategoryName)"Design";

        // Assert
        categoryName.Should().NotBeNull();
        categoryName.Value.Should().Be("Design");
    }

    [Fact]
    public void ToString_Invoked_ShouldReturnCorrectValue()
    {
        // Arrange
        var categoryName = new CategoryName("Art");

        // Act
        var result = categoryName.ToString();

        // Assert
        result.Should().Be("Art");
    }
}