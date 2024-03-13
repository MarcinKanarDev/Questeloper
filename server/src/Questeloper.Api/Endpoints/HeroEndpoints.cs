using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questeloper.Application.Hero.Commands.CreateHero;
using Questeloper.Application.Hero.Commands.DeleteHero;
using Questeloper.Application.Hero.Commands.UpdateHeroCommand;
using Questeloper.Application.Hero.Queries;

namespace Questeloper.Api.Endpoints;

public static class HeroEndpoints
{
    private static string EndpointRoute => "/api/heroes";
    
    public static IEndpointRouteBuilder AddRoutes(this IEndpointRouteBuilder app)
    {
        var heroes = app.MapGroup(EndpointRoute)
            .WithTags("heroes");

        heroes.MapPost("/", CreateHero)
            .Produces(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithName(nameof(CreateHero))
            .WithDescription("Create new hero");
        
        heroes.MapGet("/{id:int}", GetHeroById)
            .Produces(StatusCodes.Status200OK, typeof(GetHeroResponse))
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithName(nameof(GetHeroById))
            .WithDescription("Get hero by specific id");

        heroes.MapGet("/", GetHeroes)
            .Produces(StatusCodes.Status200OK, typeof(IEnumerable<GetHeroResponse>))
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithName(nameof(GetHeroes))
            .WithDescription("Get all heroes");

        heroes.MapPut("/", UpdateHero)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithName(nameof(UpdateHero))
            .WithDescription("Update hero name");

        heroes.MapDelete("/", DeleteHero)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithName(nameof(DeleteHero))
            .WithDescription("Delete hero by id");

        return app;
    }
    
    private static async Task<IResult> DeleteHero([FromBody] DeleteHeroCommand command, [FromServices] ISender sender)
    {
        await sender.Send(command);

        return Results.NoContent();
    }

    private static async Task<IResult> UpdateHero([FromBody] UpdateHeroCommand command, [FromServices] ISender sender)
    {
        await sender.Send(command);

        return Results.NoContent();
    }

    private static async Task<IResult> CreateHero([FromBody] CreateHeroCommand command, [FromServices] ISender sender)
    {
        var result = await sender.Send(command);
        
        return Results.Created(nameof(GetHeroById), new { id = result.ToString()});
    }
    
    private static async Task<IResult> GetHeroById([FromRoute] int id, [FromServices] ISender sender)
    {
        var query = new GetHeroQuery(id);
        var result = await sender.Send(query);

        return Results.Ok(result);
    }

    private static async Task<IResult> GetHeroes([FromServices] ISender sender)
    {
        var query = new GetAllHeroesQuery();
        var result = await sender.Send(query);
        
        return Results.Ok(result);
    }
}