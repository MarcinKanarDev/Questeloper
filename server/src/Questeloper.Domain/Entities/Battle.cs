namespace Questeloper.Domain.Entities;

public class Battle : EntityBase
{
    public int Result { get; private set; } = default;
    public DateTime BattleDate { get; private set; } = default;
    
    public int HeroId { get; set; }
    public Hero Hero { get; set; } = null!;
    public int EnemyId { get; set; }
    public Enemy Enemy { get; set; } = null!;

    private Battle()
    {
    }

    public Battle(int result, Hero hero, Enemy enemy)
    {
        Result = result;
        BattleDate = DateTime.Now;
        Hero = hero;
        Enemy = enemy;
    }
}