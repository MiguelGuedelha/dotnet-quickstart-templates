namespace CleanArchMinimalApi.Application.Shared.Exceptions;

internal sealed class NotFoundException<T> : BaseNotFoundException
{
    public NotFoundException()
    {
    }

    public NotFoundException(string message)
        : base(message)
    {
    }

    public NotFoundException(string message, Exception exception)
        : base(message, exception)
    {
    }
}

internal class BaseNotFoundException : Exception
{
    protected BaseNotFoundException()
    {
    }

    protected BaseNotFoundException(string message)
        : base(message)
    {
    }

    protected BaseNotFoundException(string message, Exception exception)
        : base(message, exception)
    {
    }
}
