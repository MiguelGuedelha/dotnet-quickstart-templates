using System.Reflection;

namespace CleanArchMinimalApi.Domain;

public static class DomainAssembly
{
    private static Assembly _assembly = default!;

    public static Assembly Instance
    {
        get
        {
            _assembly ??= typeof(DomainAssembly).Assembly;
            return _assembly;
        }
    }
}
