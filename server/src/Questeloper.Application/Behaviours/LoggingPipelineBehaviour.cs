using MediatR;
using Microsoft.Extensions.Logging;
using DateTime = System.DateTime;

namespace Questeloper.Application.Behaviours;

internal sealed class LoggingPipelineBehaviour<TRequest, TResponse>(
    ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : class
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("[START_REQUEST] {@Request}, {@DateTimeUtc}",
            typeof(TRequest).Name, DateTime.UtcNow);

        var result = await next();

        logger.LogInformation("[END_REQUEST] {@Request}, {@DateTimeUtc}",
            typeof(TRequest).Name, DateTime.UtcNow);

        return result;
    }
}