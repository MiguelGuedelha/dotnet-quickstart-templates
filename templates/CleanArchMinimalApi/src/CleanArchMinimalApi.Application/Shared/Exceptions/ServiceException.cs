namespace CleanArchMinimalApi.Application.Shared.Exceptions;

public class ServiceException<T> : Exception
{
    public ServiceException()
    {
    }

    public ServiceException(string message) : base(message)
    {
    }

    public ServiceException(string message, Exception exception) : base(message, exception)
    {
    }
}
