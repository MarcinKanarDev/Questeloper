namespace Questeloper.Domain.Abstractions;

public interface IClock
{
    public DateTime Current { get; }
}