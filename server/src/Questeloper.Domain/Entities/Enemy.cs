using Questeloper.Domain.ValueObjects;

namespace Questeloper.Domain.Entities;

public class Enemy
{
    public int Id { get; set; }
    public EnemyName Name { get; set; }
    public int HealthPoints { get; set; }
    public int Level { get; set; }

    public ICollection<Question> Questions { get; set; }
    public ICollection<Battle> Battles { get; set; }

    public Enemy()
    {
    }

    public Enemy(string name)
    {
        Name = new EnemyName(name);
        HealthPoints = 100;
        Level = 0;
    }
}