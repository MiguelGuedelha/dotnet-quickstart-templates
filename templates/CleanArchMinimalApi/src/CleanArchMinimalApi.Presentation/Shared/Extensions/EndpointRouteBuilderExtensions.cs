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

    internal static RouteHandlerBuilder MediateGet<TRequest, TQuery, TQueryResponse, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TQuery : IQuery<TQueryResponse>
    {
        return app.MapGet(route, async (ISender sender, [AsParameters] TRequest request, CancellationToken cancellationToken)
            => await Send<TRequest, TQuery, TResponse>(request, sender, cancellationToken));
    }

    internal static RouteHandlerBuilder MediatePost<TRequest, TCommand, TCommandResponse, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TCommand : ICommand<TCommandResponse>
    {
        return app.MapPost(route, async (ISender sender, [AsParameters] TRequest request, CancellationToken cancellationToken)
            => await Send<TRequest, TCommand, TResponse>(request, sender, cancellationToken));
    }

    internal static RouteHandlerBuilder MediatePut<TRequest, TCommand, TCommandResponse, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TCommand : ICommand<TCommandResponse>
    {
        return app.MapPut(route, async (ISender sender, [AsParameters] TRequest request, CancellationToken cancellationToken)
            => await Send<TRequest, TCommand, TResponse>(request, sender, cancellationToken));
    }

    internal static RouteHandlerBuilder MediatePatch<TRequest, TCommand, TCommandResponse, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TCommand : ICommand<TCommandResponse>
    {
        return app.MapPatch(route, async (ISender sender, [AsParameters] TRequest request, CancellationToken cancellationToken)
            => await Send<TRequest, TCommand, TResponse>(request, sender, cancellationToken));
    }

    internal static RouteHandlerBuilder MediateDelete<TRequest, TCommand, TCommandResponse, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TCommand : ICommand<TCommandResponse>
    {
        return app.MapDelete(route, async (ISender sender, [AsParameters] TRequest request, CancellationToken cancellationToken)
            => await Send<TRequest, TCommand, TResponse>(request, sender, cancellationToken));
    }

    private static async Task<TResponse> Send<TRequest, TMediatorReq, TResponse>(TRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var mediatorReq = request!.Adapt<TMediatorReq>();
        var result = await sender.Send(mediatorReq!, cancellationToken);
        return result!.Adapt<TResponse>();
    }
}
