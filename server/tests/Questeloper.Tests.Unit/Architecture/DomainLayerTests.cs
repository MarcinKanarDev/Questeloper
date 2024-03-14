using FluentAssertions;
using NetArchTest.Rules;
using Questeloper.Tests.Unit.Shared;

namespace Questeloper.Tests.Unit.Architecture;

public class DomainLayerTests
{
    [Fact]
    public void DomainLayer_ShouldNotHaveDependencyOn_ApplicationAndInfrastructure()
    {
        //Act
        var testResult = Types
            .InAssembly(Assemblies.DomainAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(
                Assemblies.ApplicationAssembly.GetName().Name,
                Assemblies.InfrastructureAssembly.GetName().Name)
            .GetResult();

        //Assert
        testResult.IsSuccessful.Should().Be(true);
    }
}