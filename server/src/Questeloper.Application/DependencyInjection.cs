using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Questeloper.Application.Behaviours;

namespace Questeloper.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(AssemblyReference.Assembly));
        
        services
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>))
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehaviour<,>));

        services.AddValidatorsFromAssembly(AssemblyReference.Assembly, includeInternalTypes: true);
        
        return services;
    }
}