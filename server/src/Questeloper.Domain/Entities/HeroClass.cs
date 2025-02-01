using Questeloper.Domain.ValueObjects;

namespace Questeloper.Domain.Entities;

public class HeroClass : EntityBase
{
    public HeroClassName ClassName { get; private set; }

    public HeroClass(string className)
    {
        ClassName = new HeroClassName(className);
    }
}