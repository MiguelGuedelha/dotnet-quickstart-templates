using CleanArchMinimalApi.Application.Abstractions.Caching;
using CleanArchMinimalApi.Application.Features.Todo.Repositories;
using CleanArchMinimalApi.Infrastructure.Features.Todo.Repositories;
using CleanArchMinimalApi.Infrastructure.Options;
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
        return services
            .AddPackageServices(configuration)
            .AddLayerServices(configuration);
    }

    private static IServiceCollection AddLayerServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddScoped<ICacheService, CacheService>()
            .Configure<CacheOptions>(configuration.GetSection(CacheOptions.Region))
            .Configure<CacheKeyOptions>(configuration.GetSection(CacheKeyOptions.Region));

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        services.AddTransient<ITodoRepository, TodoRepository>();

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

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("CleanArchMinimalDb"));

        return services;
    }

    public static WebApplication UseInfrastructureServices(this WebApplication app)
    {
        return app;
    }
}
