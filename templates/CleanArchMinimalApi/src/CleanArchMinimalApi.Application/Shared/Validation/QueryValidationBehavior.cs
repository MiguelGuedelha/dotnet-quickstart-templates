﻿using CleanArchMinimalApi.Application.Abstractions.Query;
using FluentValidation;
using MediatR;

namespace CleanArchMinimalApi.Application.Shared.Validation;

internal sealed class QueryValidationBehavior<TRequest, TResponse>
    : BaseValidationBehavior<TRequest, TResponse>, IPipelineBehavior<TRequest, TResponse>
    where TRequest : IQuery<TResponse>
{
    public QueryValidationBehavior(IEnumerable<IValidator<TRequest>> validators) : base(validators)
    {
    }

    public new async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken) => await base.Handle(request, next, cancellationToken);
}
