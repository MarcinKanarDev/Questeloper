using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questeloper.Domain.Entities;
using Questeloper.Domain.ValueObjects;

namespace Questeloper.Infrastructure.Persistence.EntityConfigurations;

public class EnemyConfiguration : IEntityTypeConfiguration<Enemy>
{
    public void Configure(EntityTypeBuilder<Enemy> builder)
    {
        builder.HasKey(e => e.Id);

        builder
            .Property(e => e.Name)
            .HasConversion(e => e.Name,
                e => new EnemyName(e))
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(e => e.HealthPoints)
            .IsRequired();

        builder
            .Property(e => e.Level)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasMany(e => e.Questions)
            .WithOne(e => e.Enemy)
            .HasForeignKey(q => q.EnemyId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}