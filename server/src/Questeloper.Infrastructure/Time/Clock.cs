using Questeloper.Domain.Abstractions;

namespace Questeloper.Infrastructure.Time;

internal sealed class Clock : IClock
{
    public DateTime Current => DateTime.UtcNow;
}