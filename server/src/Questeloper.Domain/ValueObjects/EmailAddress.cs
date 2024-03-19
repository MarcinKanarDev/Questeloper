using System.ComponentModel.DataAnnotations;
using Questeloper.Domain.Exceptions;

namespace Questeloper.Domain.ValueObjects;

public sealed record EmailAddress
{
    private const int MinLength = 3;
    private const int MaxLength = 250;
    
    public string Value { get; }
    
    public EmailAddress(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValueIsEmptyException(nameof(EmailAddress));
        }

        if (value.Length is < MinLength or > MaxLength)
        {
            throw new ValueIncorrectLengthException(nameof(EmailAddress), MinLength, MaxLength);
        }
        
        if (!new EmailAddressAttribute().IsValid(value))
        {
            throw new EmailAddressInvalidException(value);
        }

        Value = value;
    }
    
    public static implicit operator string(EmailAddress emailAddress) => emailAddress.Value;
    
    public static explicit operator EmailAddress(string emailAddress) => new(emailAddress);
    
    public override string ToString() => Value;
}