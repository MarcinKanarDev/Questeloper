using Questeloper.Domain.ValueObjects;

namespace Questeloper.Domain.Entities;

public class Category : EntityBase
{
    public required CategoryName CategoryName { get; init; }

    public ICollection<Question>? Questions { get; set; }
}