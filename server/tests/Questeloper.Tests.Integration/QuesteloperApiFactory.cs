using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Questeloper.Api;
using Questeloper.Infrastructure.Persistence;
using Testcontainers.PostgreSql;

namespace Questeloper.Tests.Integration;

public class QuesteloperApiFactory : WebApplicationFactory<IApiMarker>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer =
        new PostgreSqlBuilder()
            .WithDatabase("QuesteloperDb")
            .WithUsername("postgres")
            .WithPassword("postgres")
            .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureLogging(logging =>
        {
            logging.ClearProviders();
        });

        builder.ConfigureTestServices(services =>
        {
            services.AddDbContext<QuesteloperDbContext>(o =>
                o.UseNpgsql(_dbContainer.GetConnectionString()));
        });
    }
    
    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
    }

    public new async Task DisposeAsync()
    {
        await _dbContainer.DisposeAsync();
    }
}