using MediatR;

namespace CleanArchMinimalApi.Application.Abstractions.Command;

public interface ICommand<TResponse> : IRequest<TResponse>
{
}

public interface ICommand : IRequest
{
}
