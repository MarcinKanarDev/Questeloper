using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Questeloper.Domain.Repositories;
using Questeloper.Infrastructure.Middlewares;
using Questeloper.Infrastructure.Persistence;
using Questeloper.Infrastructure.Persistence.Configurations;
using Questeloper.Infrastructure.Persistence.DatabaseSeeders;
using Questeloper.Infrastructure.Persistence.Repositories;

namespace Questeloper.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        var options = configuration.GetOptions<PostgresConfiguration>(PostgresConfiguration.SectionName);
        
        services.AddDbContext<QuesteloperDbContext>(o =>
            o.UseNpgsql(options.ConnectionString));
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(swagger =>
        {
            swagger.EnableAnnotations();
            swagger.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Questeloper",
                Version = "v1"
            });
        });
        
        services.AddHostedService<DatabaseInitializer>();
    
        services.AddSingleton<ExceptionHandlingMiddleware>();
        services.AddScoped<IHeroRepository, HeroRepository>();
        
        services.AddEndpointsApiExplorer();
        
        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        
        return app;
    }
    
    private static T GetOptions<T>(this IConfiguration configuration, string sectionName)
        where T : class, new()
    {
        var options = new T();
        var section = configuration.GetRequiredSection(sectionName);
        section.Bind(options);

        return options;
    }
}