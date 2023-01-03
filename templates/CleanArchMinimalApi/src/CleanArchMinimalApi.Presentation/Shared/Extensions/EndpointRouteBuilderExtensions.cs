using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace CleanArchMinimalApi.Presentation.Shared.Extensions;

internal static class EndpointRouteBuilderExtensions
{

    internal static IEndpointRouteBuilder MediateGet<TRequest, TQuery, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TQuery : IRequest<TResponse>
    {
        app.MapGet(route, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request!.Adapt<TQuery>()));

        return app;
    }

    internal static IEndpointRouteBuilder MediatePost<TRequest, TCommand, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TCommand : IRequest<TResponse>
    {
        app.MapPost(route, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request!.Adapt<TCommand>()));

        return app;
    }

    internal static IEndpointRouteBuilder MediatePut<TRequest, TCommand, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TCommand : IRequest<TResponse>
    {
        app.MapPut(route, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request!.Adapt<TCommand>()));

        return app;
    }

    internal static IEndpointRouteBuilder MediatePatch<TRequest, TCommand, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TCommand : IRequest<TResponse>
    {
        app.MapPatch(route, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request!.Adapt<TCommand>()));

        return app;
    }

    internal static IEndpointRouteBuilder MediateDelete<TRequest, TCommand, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TCommand : IRequest<TResponse>
    {
        app.MapDelete(route, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request!.Adapt<TCommand>()));

        return app;
    }
}
