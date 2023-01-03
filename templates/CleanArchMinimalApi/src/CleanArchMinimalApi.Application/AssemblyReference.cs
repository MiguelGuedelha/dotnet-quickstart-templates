using System.Reflection;

namespace CleanArchMinimalApi.Application;

public static class AssemblyReference
{
    public static Assembly Instance => Assembly.GetAssembly(typeof(AssemblyReference));
}
