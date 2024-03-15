using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questeloper.Application.Category.Queries;

namespace Questeloper.Api.Endpoints;

public static class CategoryEndpoints
{
    private static string EndpointRoute => "/api/categories";

    public static IEndpointRouteBuilder MapCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        var enemies = app.MapGroup(EndpointRoute)
            .WithTags("categories");
        
        enemies.MapGet("/", GetCategories)
            .Produces(StatusCodes.Status200OK, typeof(IEnumerable<GetCategoryResponse>))
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithName(nameof(GetCategories))
            .WithDescription("Get all categories");

        return app;
    }
    
    private static async Task<IResult> GetCategories([FromServices] ISender sender)
    {
        var result = await sender.Send(new GetAllCategoriesQuery());

        return Results.Ok(result);
    }
    
}