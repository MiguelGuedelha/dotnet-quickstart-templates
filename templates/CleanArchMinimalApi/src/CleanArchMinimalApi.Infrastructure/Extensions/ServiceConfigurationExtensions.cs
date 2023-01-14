using CleanArchMinimalApi.Application.Abstractions.Caching;
using CleanArchMinimalApi.Infrastructure.Options;
using CleanArchMinimalApi.Infrastructure.Shared.Caching;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace CleanArchMinimalApi.Infrastructure.Extensions;

public static class ServiceConfigurationExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connMultiplexer = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")!);

        services.AddSingleton<IConnectionMultiplexer>(connMultiplexer);

        services.AddStackExchangeRedisCache(options =>
        {
            options.ConnectionMultiplexerFactory = () => Task.FromResult(connMultiplexer as IConnectionMultiplexer);
        });

        services.AddScoped<ICacheService, CacheService>();
        services.AddScoped<ICacheKeyService, CacheKeyService>();

        services.Configure<CacheOptions>(configuration.GetSection(CacheOptions.Region));
        services.Configure<CacheKeyOptions>(configuration.GetSection(CacheKeyOptions.Region));

        return services;
    }

    public static WebApplication UseInfrastructureServices(this WebApplication app)
    {


        return app;
    }
}
