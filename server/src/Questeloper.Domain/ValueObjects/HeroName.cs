using Questeloper.Domain.Exceptions;

namespace Questeloper.Domain.ValueObjects;

public sealed record HeroName
{
    public string Value { get; }

    public HeroName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new HeroNameIsEmptyException();
        }

        if (value.Length is > 250 or < 3)
        {
            throw new HeroNameIncorrectLengthException(value);
        }

        Value = value;
    }
    
    public static implicit operator string(HeroName heroName) => heroName.Value;
    
    public static explicit operator HeroName(string heroName) => new(heroName);
    
    public override string ToString() => Value;
}