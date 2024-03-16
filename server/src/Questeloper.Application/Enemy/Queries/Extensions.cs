namespace Questeloper.Application.Enemy.Queries;

public static class Extensions
{
    public static GetEnemyResponse ToResponse(this Domain.Entities.Enemy enemy) =>
        new GetEnemyResponse(
            enemy.Name.Value,
            enemy.HealthPoints.Points,
            enemy.Level.LevelValue);

}