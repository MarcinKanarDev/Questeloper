namespace Questeloper.Application.Category.Queries;

public static class Extensions
{
    public static GetCategoryResponse ToResponse(this Domain.Entities.Category category) =>
        new GetCategoryResponse(category.CategoryName.Value);

}