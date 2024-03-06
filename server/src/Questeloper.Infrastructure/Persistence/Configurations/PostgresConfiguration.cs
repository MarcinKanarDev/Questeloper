namespace Questeloper.Infrastructure.Persistence.Configurations;

public class PostgresConfiguration
{
    public const string SectionName = nameof(PostgresConfiguration);
    
    public string ConnectionString { get; set; }
}