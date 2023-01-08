namespace CleanArchMinimalApi.Shared.Helpers;

public static class ArgumentHelper
{
    public static void Initialise<T>(T argument, out T destination)
    {
        ArgumentNullException.ThrowIfNull(argument);
        destination = argument;
    }
}
