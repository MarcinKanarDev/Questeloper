using Questeloper.Domain.Exceptions;

namespace Questeloper.Domain.ValueObjects;

public sealed record HeroClass
{
    private const int MinLength = 3;
    private const int MaxLength = 250;
    
    public string Value { get; }
    
    public HeroClass(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValueIsEmptyException(nameof(HeroClass));
        }

        if (value.Length is < MinLength or > MaxLength)
        {
            throw new ValueIncorrectLengthException(nameof(HeroClass), MinLength, MaxLength);
        }

        Value = value;
    }
    
    public static implicit operator string(HeroClass heroClass) => heroClass.Value;
    
    public static explicit operator HeroClass(string heroClass) => new(heroClass);
    
    public override string ToString() => Value;
}