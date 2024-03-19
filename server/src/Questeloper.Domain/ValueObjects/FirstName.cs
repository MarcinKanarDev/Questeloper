using Questeloper.Domain.Exceptions;

namespace Questeloper.Domain.ValueObjects;

public sealed record FirstName
{
    private const int MinLength = 3;
    private const int MaxLength = 250;
    
    public string Value { get; }

    public FirstName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValueIsEmptyException(nameof(FirstName));
        }

        if (value.Length is < MinLength or > MaxLength)
        {
            throw new ValueIncorrectLengthException(nameof(FirstName), MinLength, MaxLength);
        }

        Value = value;
    }
    
    public static implicit operator string(FirstName firstName) => firstName.Value;
    
    public static explicit operator FirstName(string firstName) => new(firstName);
    
    public override string ToString() => Value;
}