using Questeloper.Domain.Exceptions;

namespace Questeloper.Domain.ValueObjects;

public sealed record HeroClassName
{
    private const int MinLength = 3;
    private const int MaxLength = 250;
    
    public string Value { get; }
    
    public HeroClassName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValueIsEmptyException(nameof(HeroClassName));
        }

        if (value.Length is < MinLength or > MaxLength)
        {
            throw new ValueIncorrectLengthException(nameof(HeroClassName), MinLength, MaxLength);
        }

        Value = value;
    }
    
    public static implicit operator string(HeroClassName heroClass) => heroClass.Value;
    
    public static explicit operator HeroClassName(string heroClass) => new(heroClass);
    
    public override string ToString() => Value;
}