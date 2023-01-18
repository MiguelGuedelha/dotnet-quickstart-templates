using MediatR;

namespace CleanArchMinimalApi.Application.Abstractions.Mediator;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}

public interface ICommand : IRequest
{
}
