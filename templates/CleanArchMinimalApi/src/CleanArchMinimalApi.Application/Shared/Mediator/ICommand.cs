using MediatR;

namespace CleanArchMinimalApi.Application.Abstractions.Mediator;

internal interface ICommand<out TResponse> : IRequest<TResponse>
{
}

internal interface ICommand : IRequest
{
}
