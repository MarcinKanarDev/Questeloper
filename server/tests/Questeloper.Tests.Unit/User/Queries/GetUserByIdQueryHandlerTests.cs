using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Questeloper.Application.Abstractions;
using Questeloper.Application.User.Queries;
using Questeloper.Application.User.Queries.Handlers;
using Questeloper.Domain.Exceptions;
using Questeloper.Domain.Repositories;
using Questeloper.Domain.ValueObjects;

namespace Questeloper.Tests.Unit.User.Queries;

public class GetUserByIdQueryHandlerTests
{
    private readonly IQueryHandler<GetUserByIdQuery, GetUserResponse> _queryHandler;
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandlerTests()
    {
        _userRepository = Substitute.For<IUserRepository>();
        _queryHandler = new GetUserByIdQueryHandler(_userRepository);
    }
    
    [Fact]
    public async Task GetUserByIdQueryHandler_ForValidQuery_ShouldReturnCorrectGetUserResponse()
    {
        //Arrange
        var user = new Domain.Entities.User(
            new EmailAddress("adres@emial.com "),
            new Password("123456789"),
            new FirstName("Nick"),
            new LastName("Name"),
            new NickName("NickName"));
            ;
        var query = new GetUserByIdQuery(user.Id);
        
        _userRepository.GetByIdAsync(Arg.Any<int>()).Returns(user);
        
        //Act
        var result = await _queryHandler.Handle(query, CancellationToken.None);
        
        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<GetUserResponse>();
        result.Email.Should().Be(user.EmailAddress.Value);
        result.Name.Should().Be(user.NickName.Value);
    }
    
    [Fact]
    public async Task GetUserByIdQueryHandler_ForInvalidQuery_ShouldThrowUserNotFoundException()
    {
        //Arrange
        var query = new GetUserByIdQuery(1);
        
        _userRepository.GetByIdAsync(Arg.Any<int>()).ReturnsNullForAnyArgs();
        
        //Assert
        await Assert.ThrowsAsync<UserNotFoundException>(() =>
            _queryHandler.Handle(query, CancellationToken.None));
    }
}