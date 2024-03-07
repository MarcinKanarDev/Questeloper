using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questeloper.Api.Abstractions;
using Questeloper.Application.Hero.Commands.CreateHero;
using Questeloper.Application.Hero.Commands.DeleteHero;
using Questeloper.Application.Hero.Commands.UpdateHeroCommand;
using Questeloper.Application.Hero.Queries;

namespace Questeloper.Api.Endpoints;

public class HeroEndpoints(ISender sender) : ApiEndpointBase(sender), ICarterModule
{
    private readonly ISender _sender = sender;
    protected override string EndpointRoute => "/api/heroes";
    
    public void AddRoutes(IEndpointRouteBuilder app)
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
    }
    
    private async Task<IResult> DeleteHero([FromBody] DeleteHeroCommand command)
    {
        await _sender.Send(command);

        return Results.NoContent();
    }

    private async Task<IResult> UpdateHero([FromBody] UpdateHeroCommand command)
    {
        await _sender.Send(command);

        return Results.NoContent();
    }

    private async Task<IResult> CreateHero([FromBody] CreateHeroCommand command)
    {
        var result = await _sender.Send(command);
        
        return Results.Created(nameof(GetHeroById), new { id = result.ToString()});
    }
    
    private async Task<IResult> GetHeroById([FromRoute] int id)
    {
        var query = new GetHeroQuery(id);
        var result = await _sender.Send(query);

        return Results.Ok(result);
    }

    private async Task<IResult> GetHeroes()
    {
        var query = new GetAllHeroesQuery();
        var result = await _sender.Send(query);
        
        return Results.Ok(result);
    }
}