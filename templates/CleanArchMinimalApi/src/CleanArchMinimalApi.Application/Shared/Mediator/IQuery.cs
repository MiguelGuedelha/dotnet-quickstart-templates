using MediatR;

namespace CleanArchMinimalApi.Application.Shared.Mediator;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
