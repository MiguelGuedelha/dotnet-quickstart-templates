using System.Reflection;

namespace CleanArchMinimalApi.Domain;

public static class DomainAssembly
{
    public static readonly Assembly Instance = typeof(DomainAssembly).Assembly;
}
