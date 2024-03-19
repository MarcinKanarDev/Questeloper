using Questeloper.Domain.Exceptions;

namespace Questeloper.Domain.ValueObjects;

public sealed record NickName
{
    private const int MinLength = 3;
    private const int MaxLength = 250;
    
    public string Value { get; }
    
    public NickName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValueIsEmptyException(nameof(NickName));
        }

        if (value.Length is < MinLength or > MaxLength)
        {
            throw new ValueIncorrectLengthException(nameof(NickName), MinLength, MaxLength);
        }

        Value = value;
    }
    
    public static implicit operator string(NickName nickName) => nickName.Value;
    
    public static explicit operator NickName(string nickName) => new(nickName);
    
    public override string ToString() => Value;
}