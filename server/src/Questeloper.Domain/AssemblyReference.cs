using System.Reflection;

namespace Questeloper.Domain;

public static class AssemblyReference
{
    public static Assembly Assembly = typeof(AssemblyReference).Assembly;
}