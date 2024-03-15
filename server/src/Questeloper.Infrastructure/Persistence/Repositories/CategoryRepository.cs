using Microsoft.EntityFrameworkCore;
using Questeloper.Domain.Entities;
using Questeloper.Domain.Repositories;

namespace Questeloper.Infrastructure.Persistence.Repositories;

internal class CategoryRepository(QuesteloperDbContext questeloperDbContext) : ICategoryRepository
{
    public async Task<IEnumerable<Category>> GetCategories() =>
        await questeloperDbContext.Categories.ToListAsync();
}