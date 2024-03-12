namespace Questeloper.Infrastructure.Persistence.Configurations;

internal sealed class PostgresConfiguration
{
    public const string SectionName = nameof(PostgresConfiguration);
    
    public string? ConnectionString { get; set; }
}