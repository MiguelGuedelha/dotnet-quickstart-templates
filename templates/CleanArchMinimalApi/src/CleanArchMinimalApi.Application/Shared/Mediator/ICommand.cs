using MediatR;

namespace CleanArchMinimalApi.Application.Shared.Mediator;

internal interface ICommand<out TResponse> : IRequest<TResponse>
{
}

internal interface ICommand : IRequest
{
}
