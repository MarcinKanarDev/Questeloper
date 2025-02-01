using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Questeloper.Domain.Abstractions;

namespace Questeloper.Infrastructure.Persistence.DatabaseSeeders;

internal sealed class DatabaseInitializer(IServiceProvider serviceProvider, IClock clock, 
    ILogger<DatabaseInitializer> logger, ILoggerFactory loggerFactory) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Starting database initializer...");

        using var scope = serviceProvider.CreateScope();
        
        var dbContext = scope.ServiceProvider.GetRequiredService<QuesteloperDbContext>();
        await dbContext.Database.MigrateAsync(cancellationToken);
        
        var heroSeeder = new QuesteloperDataSeeder(dbContext, loggerFactory.CreateLogger<QuesteloperDataSeeder>(), clock);
        await heroSeeder.SeedAsync();

        await dbContext.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Database initialisation was succesfull!");
    }

    public async Task StopAsync(CancellationToken cancellationToken) => await Task.CompletedTask;
}