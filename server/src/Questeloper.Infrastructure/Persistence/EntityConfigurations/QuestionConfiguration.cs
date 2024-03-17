using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questeloper.Domain.Entities;
using Questeloper.Domain.ValueObjects;

namespace Questeloper.Infrastructure.Persistence.EntityConfigurations;

internal sealed class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(q => q.Id);

        builder
            .Property(q => q.Content)
            .HasConversion(q => q.Content,
                q => new QuestionContent(q))
            .IsRequired();

        builder
            .HasDiscriminator<string>("QuestionType")
            .HasValue<MultipleChoiceQuestion>("MultipleChoiceQuestion")
            .HasValue<TextAnswerQuestion>("TextAnswerQuestion");
        
        builder
            .HasMany(q => q.Categories)
            .WithMany(c => c.Questions);
    }
}