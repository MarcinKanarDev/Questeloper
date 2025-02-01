using Questeloper.Domain.ValueObjects;

namespace Questeloper.Domain.Entities;

public class HeroClass : EntityBase
{
    public HeroClassName ClassName { get; private set; }
    
    // Relations
    public ICollection<Hero> Heroes { get; set; }

    public HeroClass()
    {
    }

    public HeroClass(string className)
    {
        ClassName = new HeroClassName(className);
    }
}