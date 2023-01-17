using MediatR;

namespace CleanArchMinimalApi.Application.Abstractions.Query;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
