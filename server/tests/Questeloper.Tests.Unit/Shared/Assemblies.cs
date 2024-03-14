using System.Reflection;

namespace Questeloper.Tests.Unit.Shared;

internal static class Assemblies
{
    public static readonly Assembly ApplicationAssembly = Application.AssemblyReference.Assembly;
    public static readonly Assembly DomainAssembly = Domain.AssemblyReference.Assembly;
    public static readonly Assembly InfrastructureAssembly = Infrastructure.AssemblyReference.Assembly;
}