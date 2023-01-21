using MediatR;

namespace CleanArchMinimalApi.Application.Abstractions.Mediator;

internal interface IQuery<out TResponse> : IRequest<TResponse>
{
}
