using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questeloper.Domain.Entities;
using Questeloper.Domain.ValueObjects;

namespace Questeloper.Infrastructure.Persistence.EntityConfigurations;

internal sealed class HeroClassConfiguration : IEntityTypeConfiguration<HeroClass>
{
    public void Configure(EntityTypeBuilder<HeroClass> builder)
    {
        builder.HasKey(e => e.Id);

        builder
            .Property(e => e.ClassName)
            .HasConversion(e => e.Value,
                e => new HeroClassName(e))
            .HasMaxLength(255)
            .IsRequired();
    }
}
