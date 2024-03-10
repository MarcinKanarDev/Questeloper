using System.Reflection;

namespace Questeloper.Infrastructure;

public static class AssemblyReference
{
    public static Assembly Assembly = typeof(AssemblyReference).Assembly;
}