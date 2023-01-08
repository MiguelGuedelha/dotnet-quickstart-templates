using MediatR;

namespace CleanArchMinimalApi.Application.Abstractions.Query;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
}
