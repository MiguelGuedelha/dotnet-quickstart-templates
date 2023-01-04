using MediatR;

namespace CleanArchMinimalApi.Application.Abstractions;

public interface ICommand<TResponse> : IRequest<TResponse>
{
}
