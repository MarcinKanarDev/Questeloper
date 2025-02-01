using Questeloper.Api.Endpoints;
using Questeloper.Application;
using Questeloper.Infrastructure;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting web application...");

    var builder = WebApplication.CreateBuilder(args);
    
    builder.Services.AddInfrastructure(builder.Configuration).AddApplication();
    
    builder.Host.UseSerilog((context, configuration) =>
    {
        configuration.ReadFrom.Configuration(context.Configuration);
    });
    
    var app = builder.Build();

    app.UseInfrastructure();

    app.MapHeroEndpoints();
    app.MapEnemyEndpoints();
    app.MapUserEndpoints();
    app.MapCategoryEndpoints();
    
    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
    Console.ReadKey();
}
finally
{
    _ = Log.CloseAndFlushAsync();
}