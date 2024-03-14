using Microsoft.Extensions.DependencyInjection;

namespace Questeloper.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(AssemblyReference.Assembly));
        
        return services;
    }
}