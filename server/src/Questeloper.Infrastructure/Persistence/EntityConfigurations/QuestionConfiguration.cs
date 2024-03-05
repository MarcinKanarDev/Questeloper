using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questeloper.Domain.Entities;

namespace Questeloper.Infrastructure.Persistence.EntityConfigurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(q => q.Id);

        builder
            .Property(q => q.Content)
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