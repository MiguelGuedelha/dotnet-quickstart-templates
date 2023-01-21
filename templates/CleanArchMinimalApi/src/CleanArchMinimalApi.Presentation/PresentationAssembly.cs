using System.Reflection;

namespace CleanArchMinimalApi.Presentation;

public static class PresentationAssembly
{
    public static readonly Assembly Instance = typeof(PresentationAssembly).Assembly;
}
