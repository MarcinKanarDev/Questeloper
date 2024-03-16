using Questeloper.Domain.Exceptions;

namespace Questeloper.Domain.ValueObjects;

public sealed record CategoryName
{
    public string Value { get; }

    public CategoryName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new CategoryNameIsEmptyException();
        }

        if (value.Length is > 250 or < 3)
        {
            throw new CategoryNameIncorrectLengthException(value);
        }

        Value = value;
    }
    
    public static implicit operator string(CategoryName categoryName) => categoryName.Value;
    
    public static explicit operator CategoryName(string categoryName) => new(categoryName);
    
    public override string ToString() => Value;
}