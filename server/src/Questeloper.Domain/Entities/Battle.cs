namespace Questeloper.Domain.Entities;

public class Battle : EntityBase
{
    public int Result { get; }
    public DateTime BattleDate { get; }
    
    public int HeroId { get; set; }
    public Hero Hero { get; set; }
    public int EnemyId { get; set; }
    public Enemy Enemy { get; set; }

    public Battle(int result)
    {
        Result = result;
        BattleDate = DateTime.Now;
    }
}