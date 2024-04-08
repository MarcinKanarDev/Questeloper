using FluentAssertions;
using Questeloper.Domain.Exceptions;
using Questeloper.Domain.ValueObjects;

namespace Questeloper.Tests.Unit.DomainTests.ValueObjects;

public class EmailAddressTests
{
    [Fact]
    public void Constructor_WhenValueIsNull_ShouldThrowValueIsEmptyException()
    {
        // Assert
        Assert.Throws<ValueIsEmptyException>(() =>
            new EmailAddress(null));
    }

    [Fact]
    public void Constructor_WhenValueIsWhitespace_ShouldThrowValueIsEmptyException()
    {
        // Assert
        Assert.Throws<ValueIsEmptyException>(() =>
            new EmailAddress(" "));
    }

    [Theory]
    [InlineData("a@b.c")] // Minimum valid length
    [InlineData("very.long.email.address@example.com")] // A longer valid example
    public void Constructor_ForValidValue_ShouldNotThrow(string validEmail)
    {
        // Act
        var act = () => new EmailAddress(validEmail);

        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [InlineData("ab")]
    public void Constructor_WhenValueIsIncorrectLength_ShouldThrowValueIncorrectLengthException(string invalidEmail)
    {
        // Assert
        Assert.Throws<ValueIncorrectLengthException>(() =>
           new EmailAddress(invalidEmail));
    }

    [Fact]
    public void Constructor_WhenValueIsInvalidFormat_ShouldThrowEmailAddressInvalidException()
    {
        // Arrange
        var invalidEmail = "invalid_email.com";
        
        // Assert
        Assert.Throws<EmailAddressInvalidException>(() =>
            new EmailAddress(invalidEmail));
    }

    [Fact]
    public void ImplicitConversion_ToString_ShouldReturnCorrectStringValue()
    {
        // Arrange
        var email = new EmailAddress("test@example.com");
        
        // Act
        string result = email;
        
        // Assert
        result.Should().Be("test@example.com");
    }

    [Fact]
    public void ExplicitConversion_FromString_ShouldCreateValidObject()
    {
        // Act
        var email = (EmailAddress)"test@example.com";
        
        // Assert
        email.Should().NotBeNull();
        email.Value.Should().Be("test@example.com");
    }

    [Fact]
    public void ToString_Invoked_ShouldReturnCorrectValue()
    {
        // Arrange
        var email = new EmailAddress("test@example.com");
        
        // Act
        var result = email.ToString();
        
        // Assert
        result.Should().Be("test@example.com");
    }
}