namespace Questeloper.Domain.Entities;

public class Category : EntityBase
{
    public string CategoryName { get; init; } = string.Empty;

    public ICollection<Question> Questions { get; set; }
}