using FluentAssertions;
using NetArchTest.Rules;
using Questeloper.Domain.Repositories;
using Questeloper.Tests.Unit.Shared;

namespace Questeloper.Tests.Unit.Architecture;

public class InfrastructureLayerTests
{
    [Fact]
    public void TypesInInfrastructureLayer_ShouldBeSealed_WhenImplementsIRepositoryInterface()
    {
        //Act
        var testResult = Types
            .InAssembly(Assemblies.InfrastructureAssembly)
            .That().ImplementInterface(typeof(IHeroRepository))
            .Or().ImplementInterface(typeof(IEnemyRepository))
            .Should().BeSealed()
            .GetResult();

        //Assert
        testResult.IsSuccessful.Should().Be(true);
    }
    
    [Fact]
    public void InfrastructureLayer_ShouldNotHaveDependencyOn_ApplicationAndApiLayers()
    {
        //Act
        var testResult = Types
            .InAssembly(Assemblies.DomainAssembly)
            .ShouldNot()
            .HaveDependencyOnAny(Assemblies.ApplicationAssembly.GetName().Name,
                Assemblies.ApiAssembly.GetName().Name)
            .GetResult();

        //Assert
        testResult.IsSuccessful.Should().Be(true);
    }
}