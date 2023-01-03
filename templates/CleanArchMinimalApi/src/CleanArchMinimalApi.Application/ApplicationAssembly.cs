using System.Reflection;

namespace CleanArchMinimalApi.Application;

public static class ApplicationAssembly
{
    private static Assembly _assembly = default!;

    public static Assembly Instance
    {
        get
        {
            _assembly ??= Assembly.GetAssembly(typeof(ApplicationAssembly))!;
            return _assembly;
        }
    }
}
