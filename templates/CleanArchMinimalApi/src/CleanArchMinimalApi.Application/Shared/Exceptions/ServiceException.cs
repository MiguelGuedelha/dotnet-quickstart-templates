namespace CleanArchMinimalApi.Application.Shared.Exceptions;

public class ServiceException<T> : Exception
{
    public ServiceException() : base()
    {
    }
    
    public ServiceException(string message) : base(message)
    {
    }

    public ServiceException(string message, Exception exception) : base(message, exception)
    {
    }
}
