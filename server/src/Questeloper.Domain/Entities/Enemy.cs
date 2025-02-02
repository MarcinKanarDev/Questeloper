using Questeloper.Domain.ValueObjects;

namespace Questeloper.Domain.Entities;

public class Enemy : EntityBase
{
    public EnemyName Name { get; private set; } = null!;
    public HealthPoints HealthPoints { get; private set; } = null!;
    public Level Level { get; private set; } = null!;

    public ICollection<Question>? Questions { get; private set; }
    public ICollection<Battle>? Battles { get; private set; }

    private Enemy()
    {
    }

    public Enemy(string name)
    {
        Name = new EnemyName(name);
        HealthPoints = new HealthPoints(100);
        Level = new Level(1);
    }
}