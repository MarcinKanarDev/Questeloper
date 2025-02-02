using Questeloper.Domain.Exceptions;

namespace Questeloper.Domain.ValueObjects;

public sealed record EnemyName
{
    private const int MinLength = 3;
    private const int MaxLength = 250;
    
    public string Value { get; }

    public EnemyName(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValueIsEmptyException(nameof(EnemyName));
        }

        if (value.Length is < MinLength or > MaxLength)
        {
            throw new ValueIncorrectLengthException(nameof(EnemyName), MinLength, MaxLength);
        }

        Value = value;
    }
    
    public static implicit operator string(EnemyName categoryName) => categoryName.Value;
    
    public static explicit operator EnemyName(string enemyName) => new(enemyName);
    
    public override string ToString() => Value;
}