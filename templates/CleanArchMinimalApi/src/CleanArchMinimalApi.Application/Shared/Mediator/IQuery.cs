using MediatR;

namespace CleanArchMinimalApi.Application.Shared.Mediator;

internal interface IQuery<out TResponse> : IRequest<TResponse>
{
}
