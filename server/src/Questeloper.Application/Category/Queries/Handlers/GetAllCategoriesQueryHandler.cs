using Questeloper.Application.Abstractions;
using Questeloper.Domain.Repositories;

namespace Questeloper.Application.Category.Queries.Handlers;

internal sealed class GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
    : IQueryHandler<GetAllCategoriesQuery, IEnumerable<GetCategoryResponse>>
{
    public async Task<IEnumerable<GetCategoryResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetCategories();
        
        return categories.Select(x => x.ToResponse());
    }
}