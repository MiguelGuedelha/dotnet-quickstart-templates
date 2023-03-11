﻿using CleanArchMinimalApi.Application.Features.Todo.Services;
using CleanArchMinimalApi.Application.Shared.Middleware;
using CleanArchMinimalApi.Application.Shared.Services;
using CleanArchMinimalApi.Application.Shared.Validation;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMinimalApi.Application;

public static class ServiceConfiguration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services
           .AddPackageServices()
           .AddMiddleware()
           .AddLayerServices();
    }

    private static IServiceCollection AddPackageServices(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(ApplicationAssembly.Instance);
        });

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(QueryValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
        services.AddValidatorsFromAssembly(ApplicationAssembly.Instance);

        return services;
    }

    private static IServiceCollection AddMiddleware(this IServiceCollection services)
    {
        services.AddTransient<ExceptionHandlingMiddleware>();
        services.AddScoped<CorrelationIdMiddleware>();

        return services;
    }

    private static IServiceCollection AddLayerServices(this IServiceCollection services)
    {
        services
           .AddScoped<ITodoCommandService, TodoCommandService>()
           .AddScoped<ITodoQueryService, TodoQueryService>()
           .AddScoped<ICorrelationIdService, CorrelationIdService>()
           .AddTransient<IDateTimeService, DateTimeService>();

        return services;
    }

    public static WebApplication UseApplicationServices(this WebApplication app)
    {
        app.UseMiddleware<CorrelationIdMiddleware>();
        app.UseMiddleware<ExceptionHandlingMiddleware>();

        return app;
    }
}
