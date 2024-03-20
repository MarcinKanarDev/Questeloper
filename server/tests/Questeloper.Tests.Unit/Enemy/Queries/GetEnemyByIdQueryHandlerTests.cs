using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Questeloper.Application.Abstractions;
using Questeloper.Application.Enemy.Queries;
using Questeloper.Application.Enemy.Queries.Handlers;
using Questeloper.Domain.Exceptions;
using Questeloper.Domain.Repositories;

namespace Questeloper.Tests.Unit.Enemy.Queries;

public class GetEnemyByIdQueryHandlerTests
{
    private readonly IQueryHandler<GetEnemyByIdQuery, GetEnemyResponse> _queryHandler;
    private readonly IEnemyRepository _enemyRepository;

    public GetEnemyByIdQueryHandlerTests()
    {
        _enemyRepository = Substitute.For<IEnemyRepository>();
        _queryHandler = new GetEnemyByIdQueryHandler(_enemyRepository);
    }
    
    [Fact]
    public async Task GetEnemyByIdQueryHandler_ForValidQuery_ShouldReturnCorrectGetEnemyResponse()
    {
        //Arrange
        var enemy = new Domain.Entities.Enemy("Enemy");
        var query = new GetEnemyByIdQuery(enemy.Id);
        
        _enemyRepository.GetByIdAsync(Arg.Any<int>()).Returns(enemy);
        
        //Act
        var result = await _queryHandler.Handle(query, CancellationToken.None);
        
        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<GetEnemyResponse>();
        result.Name.Should().Be(enemy.Name.Value);
        result.Level.Should().Be(enemy.Level.LevelValue);
        result.HealthPoints.Should().Be(enemy.HealthPoints.Points);
    }
    
    [Fact]
    public async Task GetEnemyByIdQueryHandler_ForInvalidQuery_ShouldThrowEnemyNotFoundException()
    {
        //Arrange
        var query = new GetEnemyByIdQuery(1);
        
        _enemyRepository.GetByIdAsync(Arg.Any<int>()).ReturnsNullForAnyArgs();
        
        //Assert
        await Assert.ThrowsAsync<EnemyNotFoundException>(() =>
            _queryHandler.Handle(query, CancellationToken.None));
    }
}