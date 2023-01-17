using MediatR;

namespace CleanArchMinimalApi.Application.Abstractions.Query;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
}
