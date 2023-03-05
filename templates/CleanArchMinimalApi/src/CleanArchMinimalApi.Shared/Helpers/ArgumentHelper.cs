namespace CleanArchMinimalApi.Shared.Helpers;

public static class ArgumentHelper
{
    public static T Initialise<T>(T argument)
    {
        ArgumentNullException.ThrowIfNull(argument);
        return argument;
    }
}
