using Questeloper.Domain.ValueObjects;

namespace Questeloper.Domain.Entities;

public class Enemy : EntityBase
{
    public EnemyName Name { get; set; }
    public HealthPoints HealthPoints { get; set; }
    public Level Level { get; set; }

    public ICollection<Question> Questions { get; set; }
    public ICollection<Battle> Battles { get; set; }

    public Enemy()
    {
    }

    public Enemy(string name)
    {
        Name = new EnemyName(name);
        HealthPoints = new HealthPoints(100);
        Level = new Level(1);
    }
}