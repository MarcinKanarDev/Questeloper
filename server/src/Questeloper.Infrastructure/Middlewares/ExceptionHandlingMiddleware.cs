using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Questeloper.Domain.Exceptions;

namespace Questeloper.Infrastructure.Middlewares;

internal sealed class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception.Message);
            
            await HandleExceptionAsync(exception, context);
        }
    }

    private static async Task HandleExceptionAsync(Exception exception, HttpContext context)
    {
        var apiError = exception switch
        {
            CustomException customException => new ApiError(customException.StatusCode, customException.Message),
            _ => new ApiError(HttpStatusCode.InternalServerError, exception.Message)
        };

        context.Response.StatusCode = (int)apiError.StatusCode;
        await context.Response.WriteAsJsonAsync(apiError);
    }

    private record ApiError(HttpStatusCode StatusCode, string Message);
}