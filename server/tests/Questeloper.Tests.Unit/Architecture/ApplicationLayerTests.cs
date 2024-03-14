using FluentAssertions;
using NetArchTest.Rules;
using Questeloper.Application.Abstractions;
using Questeloper.Tests.Unit.Shared;

namespace Questeloper.Tests.Unit.Architecture;

public class ApplicationLayerTests
{
    [Fact]
    public void ApplicationLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
    {
        //Act
        var testResult = Types
            .InAssembly(Assemblies.ApplicationAssembly)
            .ShouldNot()
            .HaveDependencyOn(Assemblies.InfrastructureAssembly.GetName().Name)
            .GetResult();

        //Assert
        testResult.IsSuccessful.Should().Be(true);
    }
    
    [Fact]
    public void TypesInApplicationLayer_ShouldBeSealed_WhenImplementsICommandInterface()
    {
        //Act
        var testResult = Types
            .InAssembly(Assemblies.ApplicationAssembly)
            .That().ImplementInterface(typeof(ICommand))
            .Or().ImplementInterface(typeof(ICommand<>))
            .Should().BeSealed()
            .GetResult();

        //Assert
        testResult.IsSuccessful.Should().Be(true);
    }
    
    [Fact]
    public void TypesInApplicationLayer_ShouldBeSealed_WhenImplementsIQueryInterface()
    {
        //Act
        var testResult = Types
            .InAssembly(Assemblies.ApplicationAssembly)
            .That().ImplementInterface(typeof(IQuery<>))
            .Should().BeSealed()
            .GetResult();
        
        //Assert
        testResult.IsSuccessful.Should().Be(true);
    }
    
    [Fact]
    public void TypesInApplicationLayer_ShouldBeSealed_WhenImplementsICommandHandlerInterface()
    {
        //Act
        var testResult = Types
            .InAssembly(Assemblies.ApplicationAssembly)
            .That().ImplementInterface(typeof(ICommandHandler<>))
            .Or().ImplementInterface(typeof(ICommandHandler<,>))
            .Should().BeSealed()
            .GetResult();
        
        //Assert
        testResult.IsSuccessful.Should().Be(true);
    }
    
    [Fact]
    public void TypesInApplicationLayer_ShouldBeSealed_WhenImplementsIQueryHandlerInterface()
    {
        //Act
        var testResult = Types
            .InAssembly(Assemblies.ApplicationAssembly)
            .That().ImplementInterface(typeof(IQueryHandler<,>))
            .Should().BeSealed()
            .GetResult();
        
        //Assert
        testResult.IsSuccessful.Should().Be(true);
    }
    
    [Fact]
    public void TypesInApplicationLayer_ShouldHaveNameEndingWithCommandHandler_WhenImplementsICommandHandlerInterface()
    {
        //Act
        var testResult = Types
            .InAssembly(Assemblies.ApplicationAssembly)
            .That().ImplementInterface(typeof(ICommandHandler<>))
            .Or().ImplementInterface(typeof(ICommandHandler<,>))
            .Should()
            .HaveNameEndingWith("CommandHandler")
            .GetResult();
        
        //Assert
        testResult.IsSuccessful.Should().Be(true);
    }
    
    [Fact]
    public void TypesInApplicationLayer_ShouldHaveNameEndingWithQueryHandler_WhenImplementsIQueryHandlerInterface()
    {
        //Act
        var testResult = Types
            .InAssembly(Assemblies.ApplicationAssembly)
            .That().ImplementInterface(typeof(IQueryHandler<,>))
            .Should()
            .HaveNameEndingWith("QueryHandler")
            .GetResult();
        
        //Assert
        testResult.IsSuccessful.Should().Be(true);
    }
}