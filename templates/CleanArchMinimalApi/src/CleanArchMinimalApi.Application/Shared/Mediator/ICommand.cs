using MediatR;

namespace CleanArchMinimalApi.Application.Shared.Mediator;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}

public interface ICommand : IRequest
{
}
