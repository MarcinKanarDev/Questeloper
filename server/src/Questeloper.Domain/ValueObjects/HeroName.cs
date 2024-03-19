using Questeloper.Domain.Exceptions;

namespace Questeloper.Domain.ValueObjects;

public sealed record HeroName
{
    private const int MinLength = 3;
    private const int MaxLength = 250;
    
    public string Value { get; }

    public HeroName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValueIsEmptyException(nameof(HeroName));
        }

        if (value.Length is < MinLength or > MaxLength)
        {
            throw new ValueIncorrectLengthException(nameof(HeroName), MinLength, MaxLength);
        }

        Value = value;
    }
    
    public static implicit operator string(HeroName heroName) => heroName.Value;
    
    public static explicit operator HeroName(string heroName) => new(heroName);
    
    public override string ToString() => Value;
}