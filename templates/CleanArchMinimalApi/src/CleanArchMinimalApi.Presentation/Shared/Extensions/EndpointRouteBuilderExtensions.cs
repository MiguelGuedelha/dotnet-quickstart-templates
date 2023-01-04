﻿using CleanArchMinimalApi.Application.Abstractions;
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
        return app.MapGet(route, async (ISender sender, [AsParameters] TRequest request) => await sender.Send(request!.Adapt<TQuery>()));
    }

    internal static RouteHandlerBuilder MediatePost<TRequest, TCommand, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TCommand : ICommand<TResponse>
    {
        return app.MapPost(route, async (ISender sender, [AsParameters] TRequest request) => await sender.Send(request!.Adapt<TCommand>()));
    }

    internal static RouteHandlerBuilder MediatePut<TRequest, TCommand, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TCommand : ICommand<TResponse>
    {
        return app.MapPut(route, async (ISender sender, [AsParameters] TRequest request) => await sender.Send(request!.Adapt<TCommand>()));
    }

    internal static RouteHandlerBuilder MediatePatch<TRequest, TCommand, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TCommand : ICommand<TResponse>
    {
        return app.MapPatch(route, async (ISender sender, [AsParameters] TRequest request) => await sender.Send(request!.Adapt<TCommand>()));
    }

    internal static RouteHandlerBuilder MediateDelete<TRequest, TCommand, TResponse>(
        this IEndpointRouteBuilder app,
        string route) where TCommand : ICommand<TResponse>
    {
        return app.MapDelete(route, async (ISender sender, [AsParameters] TRequest request) => await sender.Send(request!.Adapt<TCommand>()));
    }
}
