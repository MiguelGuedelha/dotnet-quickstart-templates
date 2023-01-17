using CleanArchMinimalApi.Application.Abstractions.Command;
using CleanArchMinimalApi.Application.Abstractions.Query;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace CleanArchMinimalApi.Presentation.Shared.Extensions;

internal static class EndpointRouteBuilderExtensions
{
    internal static RouteHandlerBuilder MediateGet<TQuery, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TQuery : IQuery<TResponse> =>
        app.MapGet(route, async (ISender sender, [AsParameters] TQuery query, CancellationToken cancellationToken)
            => await sender.Send(query, cancellationToken));

    internal static RouteHandlerBuilder MediatePost<TCommand, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TCommand : ICommand<TResponse> =>
        app.MapPost(route, async (ISender sender, [AsParameters] TCommand command, CancellationToken cancellationToken)
            => await sender.Send(command, cancellationToken));

    internal static RouteHandlerBuilder MediatePut<TCommand, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TCommand : ICommand<TResponse> =>
        app.MapPut(route, async (ISender sender, [AsParameters] TCommand command, CancellationToken cancellationToken)
            => await sender.Send(command, cancellationToken));

    internal static RouteHandlerBuilder MediatePatch<TCommand, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TCommand : ICommand<TResponse> =>
        app.MapPatch(route, async (ISender sender, [AsParameters] TCommand command, CancellationToken cancellationToken)
            => await sender.Send(command, cancellationToken));

    internal static RouteHandlerBuilder MediateDelete<TCommand, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TCommand : ICommand<TResponse> =>
        app.MapDelete(route,
            async (ISender sender, [AsParameters] TCommand command, CancellationToken cancellationToken)
                => await sender.Send(command, cancellationToken));
}
