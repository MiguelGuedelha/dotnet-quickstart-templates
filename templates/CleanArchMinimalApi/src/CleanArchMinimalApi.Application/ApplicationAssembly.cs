using System.Reflection;

namespace CleanArchMinimalApi.Application;

public static class ApplicationAssembly
{
    private static Assembly _assembly = default!;

    public static Assembly Instance
    {
        get
        {
            _assembly ??= typeof(ApplicationAssembly).Assembly;
            return _assembly;
        }
    }
}
