using Questeloper.Domain.ValueObjects;

namespace Questeloper.Domain.Entities;

public class HeroClass : EntityBase
{
    public HeroClassName ClassName { get; private set; } = null!;
    
    // Relations
    public ICollection<Hero>? Heroes { get; set; }

    private HeroClass()
    {
    }

    public HeroClass(string className)
    {
        ClassName = new HeroClassName(className);
    }
}