using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questeloper.Domain.Entities;
using Questeloper.Domain.ValueObjects;

namespace Questeloper.Infrastructure.Persistence.EntityConfigurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        
        builder
            .Property(u => u.EmailAddress)
            .HasConversion(e => e.Value,
                e => new EmailAddress(e))
            .IsRequired();
        
        builder
            .Property(u => u.HashedPassword)
            .HasConversion(h => h.Value,
                h => new Password(h))
            .IsRequired();
        
        builder
            .Property(u => u.FirstName)
            .HasConversion(f => f.Value,
                f => new FirstName(f))
            .IsRequired(false);
        
        builder
            .Property(u => u.LastName)
            .HasConversion(l => l.Value,
                l => new LastName(l))
            .IsRequired(false);
        
        builder
            .Property(u => u.NickName)
            .HasConversion(n => n.Value,
                n => new NickName(n))
            .IsRequired(false);

        builder
            .Property(u => u.CreatedAt)
            .HasConversion(c => c.Value,
                c => new CreatedAt(c))
            .IsRequired();
    }
}