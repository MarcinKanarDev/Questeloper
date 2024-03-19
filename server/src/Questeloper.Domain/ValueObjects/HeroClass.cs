using Questeloper.Domain.Exceptions;

namespace Questeloper.Domain.ValueObjects;

public sealed record HeroClass
{
    public string Value { get; }
    
    public HeroClass(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new HeroClassIsEmptyException();
        }

        if (value.Length is > 250 or < 3)
        {
            throw new HeroClassIncorrectLengthException(value);
        }

        Value = value;
    }
    
    public static implicit operator string(HeroClass heroClass) => heroClass.Value;
    
    public static explicit operator HeroClass(string heroClass) => new(heroClass);
    
    public override string ToString() => Value;
}