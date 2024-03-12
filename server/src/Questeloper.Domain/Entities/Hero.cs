using Questeloper.Domain.ValueObjects;

namespace Questeloper.Domain.Entities;

public class Hero : EntityBase
{
    public HeroName HeroName { get; private set; }
    public Level Level { get; private set; }
    public HeroClass HeroClass { get; private set; }
    public Experience Experience { get; private set; }
    public HealthPoints HealthPoints { get; private set; }
    public ManaPoints ManaPoints { get; private set; }

    public ICollection<Battle> Battles { get; set; }

    public Hero()
    {
    }

    public Hero(string name, HeroClass heroClass)
    {
        HeroName = new HeroName(name);
        Level = new Level(1);
        HeroClass = heroClass;
        Experience = new Experience(0);
        HealthPoints = new HealthPoints(100);
        ManaPoints = new ManaPoints(100);
    }

    public void ChangeHeroName(string newName)
    {
        HeroName = new HeroName(newName);
    }
}