using System.Reflection;

namespace CleanArchMinimalApi.Domain;

public static class AssemblyReference
{
    public static Assembly Instance => Assembly.GetAssembly(typeof(AssemblyReference));
}
