using Questeloper.Domain.Exceptions;

namespace Questeloper.Domain.ValueObjects;

public sealed record LastName
{
    private const int MinLength = 3;
    private const int MaxLength = 250;
    
    public string Value { get; }
    
    public LastName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValueIsEmptyException(nameof(LastName));
        }

        if (value.Length is < MinLength or > MaxLength)
        {
            throw new ValueIncorrectLengthException(nameof(LastName), MinLength, MaxLength);
        }

        Value = value;
    }
    
    public static implicit operator string(LastName lastName) => lastName.Value;
    
    public static explicit operator LastName(string lastName) => new(lastName);
    
    public override string ToString() => Value;
}