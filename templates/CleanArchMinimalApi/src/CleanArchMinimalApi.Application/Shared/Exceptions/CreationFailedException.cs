namespace CleanArchMinimalApi.Application.Shared.Exceptions;

internal sealed class CreationFailedException<T> : Exception
{
    public CreationFailedException()
    {
    }

    public CreationFailedException(string message) : base(message)
    {
    }

    public CreationFailedException(string message, Exception exception) : base(message, exception)
    {
    }
}
