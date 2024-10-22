using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questeloper.Application.User.Commands.LoginUserCommand;
using Questeloper.Application.User.Commands.RegisterUser;
using Questeloper.Application.User.Queries;

namespace Questeloper.Api.Endpoints;

public static class UserEndpoints
{
    private static string EndpointRoute => "/api/users";

    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var users = app.MapGroup(EndpointRoute)
            .WithTags("users");
        
        users.MapPost($"/{nameof(Register).ToLower()}", Register)
            .Produces(StatusCodes.Status201Created, typeof(GetUserResponse))
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithName(nameof(Register))
            .WithDescription("Create and register user account");
        
        users.MapPost($"/{nameof(Login).ToLower()}", Login)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithName(nameof(Login))
            .WithDescription("Login and authorize user to the application.");
        
        users.MapGet("/", GetUsers)
            .Produces(StatusCodes.Status200OK, typeof(IEnumerable<GetUserResponse>))
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithName(nameof(GetUsers))
            .WithDescription("Get all users");
        
        users.MapGet("/{id:int}", GetUserById)
            .Produces(StatusCodes.Status200OK, typeof(GetUserResponse))
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithName(nameof(GetUserById))
            .WithDescription("Get user by specific id");

        return app;
    }
    
    private static async Task<IResult> Register([FromBody] RegisterUserCommand command,
        [FromServices] ISender sender)
    {
        var result = await sender.Send(command);

        return Results.Created(nameof(GetUserById), new { id = result.ToString()});
    }
    
    private static async Task<IResult> Login([FromBody] LoginUserCommand command,
        [FromServices] ISender sender)
    {
        await sender.Send(command);

        return Results.NoContent();
    }
    
    private static async Task<IResult> GetUsers([FromServices] ISender sender)
    {
        var result = await sender.Send(new GetUsersQuery());

        return Results.Ok(result);
    }
    
    private static async Task<IResult> GetUserById([FromRoute] int id, [FromServices] ISender sender)
    {
        var result = await sender.Send(new GetUserByIdQuery(id));

        return Results.Ok(result);
    }
}