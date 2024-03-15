using Questeloper.Domain.Entities;

namespace Questeloper.Domain.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategories();
}