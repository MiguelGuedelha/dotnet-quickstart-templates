using MediatR;

namespace CleanArchMinimalApi.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}
