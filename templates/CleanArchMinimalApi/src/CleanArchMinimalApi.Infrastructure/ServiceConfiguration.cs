﻿using CleanArchMinimalApi.Application.Abstractions.Caching;
using CleanArchMinimalApi.Application.Features.Todo.Repositories;
using CleanArchMinimalApi.Infrastructure.Features.Todo.Options;
using CleanArchMinimalApi.Infrastructure.Features.Todo.Repositories;
using CleanArchMinimalApi.Infrastructure.Shared.Caching;
using CleanArchMinimalApi.Infrastructure.Shared.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace CleanArchMinimalApi.Infrastructure;

public static class ServiceConfiguration
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
           .AddPackageServices(configuration)
           .AddLayerServices(configuration);

        return services;
    }

    private static IServiceCollection AddLayerServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
           .AddScoped<ICacheRepository, CacheRepository>()
           .Configure<CacheOptions>(configuration.GetSection(CacheOptions.Region));

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        services
           .AddScoped<TodoRepository>()
           .AddScoped<ITodoRepository, CachedTodoRepository>()
           .Configure<TodoOptions>(configuration.GetSection(TodoOptions.Region));

        return services;
    }

    private static IServiceCollection AddPackageServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connMultiplexer = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")!);

        services.AddSingleton<IConnectionMultiplexer>(connMultiplexer);

        services.AddStackExchangeRedisCache(options =>
        {
            options.ConnectionMultiplexerFactory = () => Task.FromResult(connMultiplexer as IConnectionMultiplexer);
        });

        //Swap out for preferred DB connection
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("Sqlite"));
        });

        return services;
    }

    public static WebApplication UseInfrastructureServices(this WebApplication app)
    {
        return app;
    }
}
