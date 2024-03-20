using FluentAssertions;
using NSubstitute;
using Questeloper.Application.Abstractions;
using Questeloper.Application.Enemy.Queries;
using Questeloper.Application.Enemy.Queries.Handlers;
using Questeloper.Domain.Repositories;

namespace Questeloper.Tests.Unit.Enemy.Queries;

public class GetAllEnemiesQueryHandlerTests
{
    private readonly IQueryHandler<GetAllEnemiesQuery, IEnumerable<GetEnemyResponse>> _queryHandler;
    private readonly IEnemyRepository _enemyRepository;

    public GetAllEnemiesQueryHandlerTests()
    {
        _enemyRepository = Substitute.For<IEnemyRepository>();
        _queryHandler = new GetAllEnemiesQueryHandler(_enemyRepository);
    }
    
    [Fact]
    public async Task GetAllEnemiesQueryHandler_ForValidQuery_ShouldReturnCorrectGetEnemyResponse()
    {
        //Arrange
        var enemies = new List<Domain.Entities.Enemy>
        {
            new("Enemy1"),
            new("Enemy2")
        };
        var query = new GetAllEnemiesQuery();
        
        _enemyRepository.GetEnemiesAsync().Returns(enemies);
        
        //Act
        var result = await _queryHandler.Handle(query, CancellationToken.None);
        
        //Assert
        var getEnemyResponses = result.ToList();
        
        getEnemyResponses.Should().NotBeNull();
        getEnemyResponses.Should().BeOfType<List<GetEnemyResponse>>();
        getEnemyResponses.Count.Should().Be(enemies.Count);
        getEnemyResponses.First().Name.Should().Be(enemies.First().Name.Value);
        getEnemyResponses.First().Level.Should().Be(enemies.First().Level.LevelValue);
        getEnemyResponses.First().HealthPoints.Should().Be(enemies.First().HealthPoints.Points);
    }
}