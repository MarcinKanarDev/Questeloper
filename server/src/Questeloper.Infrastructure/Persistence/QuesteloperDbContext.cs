using Microsoft.EntityFrameworkCore;
using Questeloper.Domain.Entities;

namespace Questeloper.Infrastructure.Persistence;

internal class QuesteloperDbContext(DbContextOptions<QuesteloperDbContext> options) : DbContext(options)
{
    public DbSet<Hero> Heroes { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Enemy> Enemies { get; set; }
    public DbSet<Battle> Battles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<HeroClass> HeroClasses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}