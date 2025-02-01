using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Questeloper.Domain.Abstractions;
using Questeloper.Domain.Entities;
using Questeloper.Domain.ValueObjects;

namespace Questeloper.Infrastructure.Persistence.DatabaseSeeders;

internal sealed class QuesteloperDataSeeder(QuesteloperDbContext questeloperDbContext, ILogger<QuesteloperDataSeeder> logger, IClock clock)
{
    private readonly string[] HeroClasses = { "Front-End Developer", "Back-End Developer", "Tester" };

    internal async Task SeedAsync()
    {
        if (!questeloperDbContext.HeroClasses.Any()) await GenerateHeroClasses();
        if (!questeloperDbContext.Heroes.Any()) await GenerateHeroes();
        if (!questeloperDbContext.Categories.Any()) await GenerateCategories();
        if (!questeloperDbContext.Enemies.Any()) await GenerateEnemies();
        if (!questeloperDbContext.Questions.Any()) await GenerateQuestions();
        if (!questeloperDbContext.Users.Any()) await GenerateUsers();
    }

    #region Generators

    private async Task GenerateHeroClasses()
    {
        logger.LogInformation("Generating hero classes...");

        var heroClassesToSeed = new List<HeroClass>();

        foreach (var className in HeroClasses)
        {
            var heroeClassesFaker = new Faker<HeroClass>()
                    .RuleFor(x => x.ClassName, x => new HeroClassName(className));

            heroClassesToSeed.Add(heroeClassesFaker);
        }

        await questeloperDbContext.HeroClasses.AddRangeAsync(heroClassesToSeed);
        await questeloperDbContext.SaveChangesAsync();

        logger.LogInformation("Generating hero classes succesful!");
    }

    private async Task GenerateHeroes()
    {
        logger.LogInformation("Generating heroes...");

        var heroClassIds = await questeloperDbContext.HeroClasses.Select(x => x.Id).ToListAsync();

        var heroesFaker = new Faker<Hero>()
            .RuleFor(x => x.Level, x => new Level(x.Random.Int(1, 100)))
            .RuleFor(x => x.HeroName, x => new HeroName(x.Person.UserName))
            .RuleFor(x => x.Experience, x => new Experience(x.Random.Int(1, 10000)))
            .RuleFor(x => x.HealthPoints, x => new HealthPoints(x.Random.Int(1, 100)))
            .RuleFor(x => x.ManaPoints, x => new ManaPoints(x.Random.Int(1, 100)))
            .RuleFor(x => x.HeroClassId, x => x.PickRandom(heroClassIds))
            .RuleFor(x => x.HeroClass, x => 
                new HeroClass(x.PickRandom(HeroClasses)));

        var heroesToSeed = heroesFaker.Generate(2);
        await questeloperDbContext.Heroes.AddRangeAsync(heroesToSeed);
        await questeloperDbContext.SaveChangesAsync();

        logger.LogInformation("Generating heroes succesful!");
    }
    
    private async Task GenerateCategories()
    {
        logger.LogInformation("Generating categories...");

        var categoriesFaker = new Faker<Category>()
            .RuleFor(x => x.CategoryName,
                x => new CategoryName(x.Lorem.Sentence(3)));

        var categoriesToSeed = categoriesFaker.Generate(5);
        await questeloperDbContext.Categories.AddRangeAsync(categoriesToSeed);
        await questeloperDbContext.SaveChangesAsync();

        logger.LogInformation("Generating categories succesful!");
    }

    private async Task GenerateQuestions()
    {
        logger.LogInformation("Generating questions...");

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

        logger.LogInformation("Generating questions succesfull!");
    }

    private async Task GenerateEnemies() 
    {
        logger.LogInformation("Generating enemies...");

        var enemiesFaker = new Faker<Enemy>()
            .RuleFor(x => x.Name, x => new EnemyName(x.Lorem.Word()))
            .RuleFor(x => x.HealthPoints, x => new HealthPoints(x.Random.Int(1, 100)))
            .RuleFor(x => x.Level, x => new Level(x.Random.Int(1, 100)));

        var enemiesToSeed = enemiesFaker.Generate(3);

        await questeloperDbContext.Enemies.AddRangeAsync(enemiesToSeed);
        await questeloperDbContext.SaveChangesAsync();

        logger.LogInformation("Generating enemies succesfull!");
    }
    
    private async Task GenerateUsers() 
    {
        logger.LogInformation("Generating users...");

        var usersFaker = new Faker<User>()
            .RuleFor(x => x.NickName, x => new NickName(x.Person.UserName))
            .RuleFor(x => x.EmailAddress, x => new EmailAddress(x.Person.Email))
            .RuleFor(x => x.FirstName, x => new FirstName(x.Person.FirstName))
            .RuleFor(x => x.LastName, x => new LastName(x.Person.LastName))
            .RuleFor(x => x.HashedPassword, x => new Password(x.Internet.Password()))
            .RuleFor(x => x.CreatedAt, x => new CreatedAt(clock.Current));

        var usersToSeed = usersFaker.Generate(1);

        await questeloperDbContext.Users.AddRangeAsync(usersToSeed);
        await questeloperDbContext.SaveChangesAsync();

        logger.LogInformation("Generating users succesfull!");
    }

    # endregion
}