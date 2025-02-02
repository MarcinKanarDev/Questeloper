using Questeloper.Domain.ValueObjects;

namespace Questeloper.Domain.Entities;

public class Hero : EntityBase
{
    public HeroName HeroName { get; private set; } = null!;
    public Level Level { get; private set; } = null!;
    public Experience Experience { get; private set; } = null!;
    public HealthPoints HealthPoints { get; private set; } = null!;
    public ManaPoints ManaPoints { get; private set; } = null!;

    // Relations
    public int HeroClassId { get; set; }
    public HeroClass HeroClass { get; private set; } = null!;
    public ICollection<Battle>? Battles { get; set; }

    private Hero()
    {
    }

    public Hero(string name, HeroClassName heroClass)
    {
        HeroName = new HeroName(name);
        Level = new Level(1);
        HeroClass = new HeroClass(heroClass.Value);
        Experience = new Experience(0);
        HealthPoints = new HealthPoints(100);
        ManaPoints = new ManaPoints(100);
    }

    public void ChangeHeroName(string newName)
    {
        HeroName = new HeroName(newName);
    }
}