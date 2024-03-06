using Bogus;
using Microsoft.EntityFrameworkCore;
using Questeloper.Domain.Entities;
using Questeloper.Domain.ValueObjects;

namespace Questeloper.Infrastructure.Persistence.DatabaseSeeders;

internal sealed class QuesteloperDataSeeder(QuesteloperDbContext questeloperDbContext)
{
    internal async Task SeedAsync()
    {
        if (!questeloperDbContext.Heroes.Any()) await GenerateHeroes();
        if (!questeloperDbContext.Categories.Any()) await GenerateCategories();
        if (!questeloperDbContext.Enemies.Any()) await GenerateEnemies();
        if (!questeloperDbContext.Questions.Any()) await GenerateQuestions();
    }
    
    private async Task GenerateHeroes()
    {
        var heroesClasses = new[] { "Front-End Developer", "Back-End Developer", "Tester" };
        
        var heroesFaker = new Faker<Hero>()
            .RuleFor(x => x.Level, x => x.Random.Int(1, 100))
            .RuleFor(x => x.HeroName, x => new HeroName(x.Person.UserName))
            .RuleFor(x => x.HeroClass, x => 
                new HeroClass(x.PickRandom(heroesClasses)));

        var heroesToSeed = heroesFaker.Generate(10);
        await questeloperDbContext.Heroes.AddRangeAsync(heroesToSeed);
    }
    
    private async Task GenerateCategories()
    {
        var categoriesFaker = new Faker<Category>()
            .RuleFor(x => x.CategoryName,
                x => x.Lorem.Word());

        var categoriesToSeed = categoriesFaker.Generate(10);
        await questeloperDbContext.Categories.AddRangeAsync(categoriesToSeed);
        await questeloperDbContext.SaveChangesAsync();
    }

    private async Task GenerateQuestions()
    {
        var categories = await questeloperDbContext.Categories.ToListAsync();
        var enemyIds = await questeloperDbContext.Enemies.Select(x => x.Id).ToListAsync();
        
        var multipleQuestionsFaker = new Faker<MultipleChoiceQuestion>()
            .RuleFor(x => x.Content, x => new QuestionContent(x.Lorem.Lines()))
            .RuleFor(x => x.CorrectAnswer, x => x.Lorem.Lines())
            .RuleFor(x => x.OptionA, x => x.Lorem.Lines())
            .RuleFor(x => x.OptionB, x => x.Lorem.Lines())
            .RuleFor(x => x.OptionC, x => x.Lorem.Lines())
            .RuleFor(x => x.OptionD, x => x.Lorem.Lines())
            .RuleFor(x => x.EnemyId, x => x.PickRandom(enemyIds))
            .RuleFor(x => x.Categories, 
                x => x.PickRandom(categories, 2).ToList());

        var textAnswerQuestions = new Faker<TextAnswerQuestion>()
            .RuleFor(x => x.Content, x => new QuestionContent(x.Lorem.Lines()))
            .RuleFor(x => x.CorrectAnswer, x => x.Lorem.Lines())
            .RuleFor(x => x.EnemyId, x => x.PickRandom(enemyIds))
            .RuleFor(x => x.Categories, 
                x => x.PickRandom(categories, 2).ToList());

        var multipleQuestionsToSeed = multipleQuestionsFaker.Generate(30);
        var textAnswersQuestionsToSeed = textAnswerQuestions.Generate(30);

        var addMultipleQuestionsTask = questeloperDbContext.Questions.AddRangeAsync(multipleQuestionsToSeed);
        var addTextAnswerQuestionsTask = questeloperDbContext.Questions.AddRangeAsync(textAnswersQuestionsToSeed);

        await Task.WhenAll(addMultipleQuestionsTask, addTextAnswerQuestionsTask);
        await questeloperDbContext.SaveChangesAsync();
    }

    private async Task GenerateEnemies() 
    {
        var enemiesFaker = new Faker<Enemy>()
            .RuleFor(x => x.Name, x => new EnemyName(x.Lorem.Word()))
            .RuleFor(x => x.Level, x => x.Random.Int(1, 100));

        var enemiesToSeed = enemiesFaker.Generate(10);

        await questeloperDbContext.Enemies.AddRangeAsync(enemiesToSeed);
        await questeloperDbContext.SaveChangesAsync();
    }

}