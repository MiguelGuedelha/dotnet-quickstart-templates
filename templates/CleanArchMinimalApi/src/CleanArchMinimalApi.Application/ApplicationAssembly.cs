using System.Reflection;

namespace CleanArchMinimalApi.Application;

public static class ApplicationAssembly
{
    public static readonly Assembly Instance = typeof(ApplicationAssembly).Assembly;
}
