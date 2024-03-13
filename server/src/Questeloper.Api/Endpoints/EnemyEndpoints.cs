using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questeloper.Application.Enemy.Queries;
using Questeloper.Application.Hero.Queries;

namespace Questeloper.Api.Endpoints;

public static class EnemyEndpoints
{
    private static string EndpointRoute => "/api/enemies";

    public static IEndpointRouteBuilder MapEnemiesEndpoints(this IEndpointRouteBuilder app)
    {
        var enemies = app.MapGroup(EndpointRoute)
            .WithTags("enemies");
        
        enemies.MapGet("/", GetEnemies)
            .Produces(StatusCodes.Status200OK, typeof(IEnumerable<GetEnemyResponse>))
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithName(nameof(GetEnemies))
            .WithDescription("Get all enemies");
        
        enemies.MapGet("/{id:int}", GetEnemyById)
            .Produces(StatusCodes.Status200OK, typeof(GetEnemyResponse))
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithName(nameof(GetEnemyById))
            .WithDescription("Get enemy by specific id");

        return app;
    }
    
    private static async Task<IResult> GetEnemies([FromServices] ISender sender)
    {
        var result = await sender.Send(new GetAllEnemiesQuery());

        return Results.Ok(result);
    }
    
    private static async Task<IResult> GetEnemyById([FromRoute] int id, [FromServices] ISender sender)
    {
        var result = await sender.Send(new GetEnemyByIdQuery(id));

        return Results.Ok(result);
    }
}