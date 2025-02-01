using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Questeloper.Application.Abstractions;
using Questeloper.Application.Hero.Queries;
using Questeloper.Application.Hero.Queries.Handlers;
using Questeloper.Domain.Exceptions;
using Questeloper.Domain.Repositories;
using Questeloper.Domain.ValueObjects;

namespace Questeloper.Tests.Unit.Hero.Queries;

public class GetHeroQueryHandlerTests
{
    private readonly IQueryHandler<GetHeroQuery, GetHeroResponse> _queryHandler;
    private readonly IHeroRepository _heroRepository;
    
    public GetHeroQueryHandlerTests()
    {
        _heroRepository = Substitute.For<IHeroRepository>();
        _queryHandler = new GetHeroQueryHandler(_heroRepository);
    }
    
    [Fact]
    public async Task GetHeroQueryHandler_ForValidQuery_ShouldReturnCorrectGetHeroResponse()
    {
        //Arrange
        var hero = new Domain.Entities.Hero("Hero", new HeroClassName("Backend Developer"));
        var query = new GetHeroQuery(hero.Id);
        
        _heroRepository.GetByIdAsync(Arg.Any<int>()).Returns(hero);
        
        //Act
        var result = await _queryHandler.Handle(query, CancellationToken.None);
        
        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<GetHeroResponse>();
        result.HeroClass.Should().Be(hero.HeroName.Value);
        result.Name.Should().Be(hero.HeroName.Value);
        result.Level.Should().Be(hero.Level.LevelValue);
        result.Experience.Should().Be(hero.Experience.ExperiencePoints);
        result.HealthPoints.Should().Be(hero.HealthPoints.Points);
        result.ManaPoints.Should().Be(hero.ManaPoints.Points);
    }
    
    [Fact]
    public async Task GetHeroQueryHandler_ForInvalidQuery_ShouldThrowHeroNotFoundException()
    {
        //Arrange
        var query = new GetHeroQuery(1);
        
        _heroRepository.GetByIdAsync(Arg.Any<int>()).ReturnsNullForAnyArgs();
        
        //Assert
        await Assert.ThrowsAsync<ResourceNotFoundException>(() =>
            _queryHandler.Handle(query, CancellationToken.None));
    }
}