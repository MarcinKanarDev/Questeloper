using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Questeloper.Domain.Abstractions;

namespace Questeloper.Infrastructure.Persistence.DatabaseSeeders;

internal sealed class DatabaseInitializer(IServiceProvider serviceProvider, IClock clock) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();
        
        var dbContext = scope.ServiceProvider.GetRequiredService<QuesteloperDbContext>();
        await dbContext.Database.MigrateAsync(cancellationToken);
        
        var heroSeeder = new QuesteloperDataSeeder(dbContext, clock);
        await heroSeeder.SeedAsync();

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken) => await Task.CompletedTask;
}