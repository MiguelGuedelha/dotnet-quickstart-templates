using MediatR;

namespace CleanArchMinimalApi.Application.Abstractions.Mediator;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
