using Questeloper.Application.Abstractions;

namespace Questeloper.Application.Category.Queries;

public sealed record GetAllCategoriesQuery
    : IQuery<IEnumerable<GetCategoryResponse>>, IQuery<GetCategoryResponse>;
