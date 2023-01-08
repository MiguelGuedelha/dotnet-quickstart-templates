using CleanArchMinimalApi.Application.Abstractions.Command;
using CleanArchMinimalApi.Application.Abstractions.Query;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace CleanArchMinimalApi.Presentation.Shared.Extensions;

internal static class EndpointRouteBuilderExtensions
{

    internal static RouteHandlerBuilder MediateGet<TRequest, TQuery, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TQuery : IQuery<TResponse>
    {
        return app.MapGet(route, async (ISender sender, [AsParameters] TRequest request, CancellationToken cancellationToken)
            => await sender.Send(request!.Adapt<TQuery>(), cancellationToken));
    }

    internal static RouteHandlerBuilder MediatePost<TRequest, TCommand, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TCommand : ICommand<TResponse>
    {
        return app.MapPost(route, async (ISender sender, [AsParameters] TRequest request, CancellationToken cancellationToken)
            => await sender.Send(request!.Adapt<TCommand>(), cancellationToken));
    }

    internal static RouteHandlerBuilder MediatePut<TRequest, TCommand, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TCommand : ICommand<TResponse>
    {
        return app.MapPut(route, async (ISender sender, [AsParameters] TRequest request, CancellationToken cancellationToken)
            => await sender.Send(request!.Adapt<TCommand>(), cancellationToken));
    }

    internal static RouteHandlerBuilder MediatePatch<TRequest, TCommand, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TCommand : ICommand<TResponse>
    {
        return app.MapPatch(route, async (ISender sender, [AsParameters] TRequest request, CancellationToken cancellationToken)
            => await sender.Send(request!.Adapt<TCommand>(), cancellationToken));
    }

    internal static RouteHandlerBuilder MediateDelete<TRequest, TCommand, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TCommand : ICommand<TResponse>
    {
        return app.MapDelete(route, async (ISender sender, [AsParameters] TRequest request, CancellationToken cancellationToken)
            => await sender.Send(request!.Adapt<TCommand>(), cancellationToken));
    }
}
