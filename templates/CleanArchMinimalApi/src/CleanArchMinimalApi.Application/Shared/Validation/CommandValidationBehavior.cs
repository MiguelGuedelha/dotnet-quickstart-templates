using CleanArchMinimalApi.Application.Abstractions.Command;
using FluentValidation;
using MediatR;

namespace CleanArchMinimalApi.Application.Shared.Validation;

internal sealed class CommandValidationBehavior<TRequest, TResponse>
    : BaseValidationBehavior<TRequest, TResponse>, IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{
    public CommandValidationBehavior(IEnumerable<IValidator<TRequest>> validators) : base(validators)
    {
    }

    public new async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        return await base.Handle(request, next, cancellationToken);
    }
}
