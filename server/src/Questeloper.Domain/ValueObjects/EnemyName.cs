using Questeloper.Domain.Exceptions;

namespace Questeloper.Domain.ValueObjects;

public sealed record EnemyName
{
    public string Value { get; }

    public EnemyName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EnemyNameIsEmptyException();
        }

        if (value.Length is > 250 or < 3)
        {
            throw new EnemyNameIncorrectLengthException(value);
        }

        Value = value;
    }
    
    public static implicit operator string(EnemyName categoryName) => categoryName.Value;
    
    public static explicit operator EnemyName(string enemyName) => new(enemyName);
    
    public override string ToString() => Value;
}