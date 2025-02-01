using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Questeloper.Domain.Exceptions;

namespace Questeloper.Infrastructure.Middlewares;

internal sealed class ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            logger.LogError(exception.Message);
            
            await HandleExceptionAsync(exception, context);

            throw;
        }
    }

    private static async Task HandleExceptionAsync(Exception exception, HttpContext context)
    {
        var apiError = exception switch
        {
            CustomException customException =>
                new ApiError(customException.StatusCode, customException.Message),
            ValidationException validationException =>
                new ApiError(HttpStatusCode.BadRequest, "Request validation error.",
                    GetErrors(validationException)),
            _ =>
                new ApiError(HttpStatusCode.InternalServerError, exception.Message)
        };

        context.Response.StatusCode = (int)apiError.StatusCode;
        await context.Response.WriteAsJsonAsync(apiError);
    }

    private static IDictionary<string, string[]> GetErrors(ValidationException exception)
    {
        return exception.Errors
            .GroupBy(x => x.PropertyName)
            .ToDictionary(x => x.Key, x =>
                x.Select(y => y.ErrorMessage).ToArray());
    }

    private sealed record ApiError(
        HttpStatusCode StatusCode,
        string? Message = default,
        IDictionary<string, string[]>? Errors = default);
}