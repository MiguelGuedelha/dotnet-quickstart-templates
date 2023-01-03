using System.Reflection;

namespace CleanArchMinimalApi.Infrastructure;

public static class InfrastructureAssembly
{
    private static Assembly _assembly = default!;

    public static Assembly Instance
    {
        get
        {
            _assembly ??= Assembly.GetAssembly(typeof(InfrastructureAssembly))!;
            return _assembly;
        }
    }
}
