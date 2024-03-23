using Questeloper.Domain.Exceptions;

namespace Questeloper.Domain.ValueObjects;

public sealed record Password
{
    private const int MinLength = 8;
    private const int MaxLength = 128;

    public string Value { get; }
    
    public Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValueIsEmptyException(nameof(Password));
        }

        if (value.Length is < MinLength or > MaxLength)
        {
            throw new ValueIncorrectLengthException(nameof(Password), MinLength, MaxLength);
        }

        Value = value;
    }
    
    public static implicit operator string(Password password) => password.Value;
    
    public static explicit operator Password(string password) => new(password);
    
    public override string ToString() => Value;
}