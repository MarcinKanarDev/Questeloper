using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questeloper.Domain.Entities;

namespace Questeloper.Infrastructure.Persistence.EntityConfigurations;

public class BattleConfiguration : IEntityTypeConfiguration<Battle>
{
    public void Configure(EntityTypeBuilder<Battle> builder)
    {
        builder.HasKey(b => b.Id);

        builder
            .Property(b => b.Result)
            .IsRequired();

        builder
            .Property(b => b.BattleDate)
            .IsRequired();
        
        builder
            .HasOne(b => b.Enemy)
            .WithMany()
            .HasForeignKey(e => e.EnemyId);
        
        builder.HasOne(b => b.Hero)
            .WithMany()
            .HasForeignKey(e => e.HeroId);
    }
}