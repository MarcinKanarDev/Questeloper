using Questeloper.Domain.ValueObjects;

namespace Questeloper.Domain.Entities;

public abstract class Question : EntityBase
{
    public QuestionContent? Content { get; set; }
    
    public int EnemyId { get; set; }
    public Enemy Enemy { get; set; }
    public ICollection<Category> Categories { get; set; }
}