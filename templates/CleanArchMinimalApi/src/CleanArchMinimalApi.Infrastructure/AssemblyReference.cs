using System.Reflection;

namespace CleanArchMinimalApi.Infrastructure;

public static class AssemblyReference
{
    public static Assembly Instance => Assembly.GetAssembly(typeof(AssemblyReference));
}
