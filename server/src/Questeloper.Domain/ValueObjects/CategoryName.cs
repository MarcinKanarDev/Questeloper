using Questeloper.Domain.Exceptions;

namespace Questeloper.Domain.ValueObjects;

public sealed record CategoryName
{
    private const int MinLength = 3;
    private const int MaxLength = 250;
    
    public string Value { get; }

    public CategoryName(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValueIsEmptyException(nameof(CategoryName));
        }

        if (value.Length is < MinLength or > MaxLength)
        {
            throw new ValueIncorrectLengthException(nameof(CategoryName), MinLength, MaxLength);
        }

        Value = value;
    }
    
    public static implicit operator string(CategoryName categoryName) => categoryName.Value;
    
    public static explicit operator CategoryName(string categoryName) => new(categoryName);
    
    public override string ToString() => Value;
}