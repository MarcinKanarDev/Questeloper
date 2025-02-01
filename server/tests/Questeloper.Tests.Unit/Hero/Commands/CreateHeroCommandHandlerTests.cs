using FluentAssertions;
using NSubstitute;
using Questeloper.Application.Abstractions;
using Questeloper.Application.Hero.Commands.CreateHero;
using Questeloper.Domain.Repositories;

namespace Questeloper.Tests.Unit.Hero.Commands;

public class CreateHeroCommandHandlerTests
{
    private readonly ICommandHandler<CreateHeroCommand, int> _commandHandler;
    private readonly IHeroRepository _heroRepository;
    
    public CreateHeroCommandHandlerTests()
    {
        _heroRepository = Substitute.For<IHeroRepository>();
        _commandHandler = new CreateHeroCommandHandler(_heroRepository);
    }
    
    [Fact]
    public async Task CreateHeroCommandHandler_ForValidCommand_ShouldCreateHeroAndInvokeHeroRepository()
    {
        //Arrange
        const int expectedHeroId = 1; 
        var command = new CreateHeroCommand("Hero", "Backend Developer");

        _heroRepository
            .CreateHeroAsync(Arg.Any<Domain.Entities.Hero>())
            .Returns(Task.CompletedTask)
            .AndDoes(ci => ci.Arg<Domain.Entities.Hero>().Id = expectedHeroId);
        
        //Act
        var result = await _commandHandler.Handle(command, CancellationToken.None);
        
        //Assert
        await _heroRepository
            .Received(1)
            .CreateHeroAsync(Arg.Is<Domain.Entities.Hero>(h =>
                h.HeroName == command.Name && h.HeroClass.ClassName.Value == command.HeroClass));
        await _heroRepository.Received(1).CompleteAsync();
        
        result.Should().Be(expectedHeroId);
    }
}