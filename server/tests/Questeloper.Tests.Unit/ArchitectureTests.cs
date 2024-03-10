using System.Reflection;
using FluentAssertions;
using NetArchTest.Rules;

namespace Questeloper.Tests.Unit;

public class ArchitectureTests
{
    private readonly Assembly _applicationAssembly = Application.AssemblyReference.Assembly;
    private readonly Assembly _domainAssembly = Domain.AssemblyReference.Assembly;
    private readonly Assembly _infrastructureAssembly = Infrastructure.AssemblyReference.Assembly;
    
    [Fact]
    public void DomainLayer_ShouldNotHaveDependencyOn_ApplicationAndInfrastructure()
    {
        var testResult = Types
            .InAssembly(_domainAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(_applicationAssembly.GetName().Name,
                _infrastructureAssembly.GetName().Name)
            .GetResult();

        testResult.IsSuccessful.Should().Be(true);
    }
    
    [Fact]
    public void ApplicationLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
    {
        var testResult = Types
            .InAssembly(_applicationAssembly)
            .ShouldNot()
            .HaveDependencyOn(_infrastructureAssembly.GetName().Name)
            .GetResult();

        testResult.IsSuccessful.Should().Be(true);
    }
}