using Microsoft.EntityFrameworkCore;
using Questeloper.Domain.Entities;

namespace Questeloper.Infrastructure.Persistence;

internal class QuesteloperDbContext : DbContext
{
    public QuesteloperDbContext(DbContextOptions<QuesteloperDbContext> options)
        : base(options)
    {
    }

    public DbSet<Hero> Heroes { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Enemy> Enemies { get; set; }
    public DbSet<Battle> Battles { get; set; }
    public DbSet<Question> Questions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}