using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questeloper.Domain.Entities;
using Questeloper.Domain.ValueObjects;

namespace Questeloper.Infrastructure.Persistence.EntityConfigurations;

public class HeroConfiguration : IEntityTypeConfiguration<Hero>
{
    public void Configure(EntityTypeBuilder<Hero> builder)
    {
        builder.HasKey(h => h.Id);

        builder
            .Property(h => h.HeroName)
            .HasConversion(h => h.Name,
                x => new HeroName(x))
            .HasMaxLength(200);

        builder
            .Property(h => h.Level)
            .HasMaxLength(100);

        builder
            .Property(h => h.HeroClass)
            .HasConversion(h => h.Name,
                h => new HeroClass(h))
            .IsRequired();

        builder
            .Property(h => h.HealthPoints)
            .IsRequired();

        builder
            .Property(h => h.ManaPoints)
            .IsRequired();
    }
}