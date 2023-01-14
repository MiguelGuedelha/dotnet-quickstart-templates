using FluentValidation;
using MediatR;
using ValidationException = CleanArchMinimalApi.Application.Shared.Exceptions.ValidationException;

namespace CleanArchMinimalApi.Application.Shared.Validation;

internal class BaseValidationBehavior<TRequest, TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    protected BaseValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    protected async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return await Task.FromCanceled<TResponse>(cancellationToken);
        }

        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var errorsDictionary = _validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .GroupBy(
                x => x.PropertyName,
                x => x.ErrorMessage,
                (propertyName, errorMessages) => new
                {
                    Key = propertyName,
                    Values = errorMessages.Distinct().ToArray()
                })
            .ToDictionary(x => x.Key, x => x.Values);

        return errorsDictionary.Any()
            ? throw new ValidationException(errorsDictionary)
            : await next();
    }
}
