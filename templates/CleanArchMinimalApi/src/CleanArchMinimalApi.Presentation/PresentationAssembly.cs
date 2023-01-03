using System.Reflection;

namespace CleanArchMinimalApi.Presentation;

public static class PresentationAssembly
{
    private static Assembly _assembly = default!;

    public static Assembly Instance
    {
        get
        {
            _assembly ??= Assembly.GetAssembly(typeof(PresentationAssembly))!;
            return _assembly;
        }
    }
}
