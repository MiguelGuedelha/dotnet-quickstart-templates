using MediatR;

namespace CleanArchMinimalApi.Application.Abstractions.Query;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}
