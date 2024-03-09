using Questeloper.Domain.ValueObjects;

namespace Questeloper.Domain.Entities;

public class Hero : EntityBase
{
    public HeroName HeroName { get; private set; }
    public int Level { get; private set; }
    public HeroClass HeroClass { get; private set; }
    public int Experience { get; private set; }
    public int HealthPoints { get; private set; }
    public int ManaPoints { get; private set; }

    public ICollection<Battle> Battles { get; set; }

    public Hero()
    {
    }

    public Hero(string name, HeroClass heroClass)
    {
        HeroName = new HeroName(name);
        Level = 1;
        HeroClass = heroClass;
        Experience = 0;
        HealthPoints = 100;
        ManaPoints = 100;
    }

    public void ChangeHeroName(string newName)
    {
        HeroName = new HeroName(newName);
    }
}