using CleanArchMinimalApi.Application.Abstractions.Caching;
using CleanArchMinimalApi.Infrastructure.Options;
using CleanArchMinimalApi.Infrastructure.Shared.Caching;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace CleanArchMinimalApi.Application.Extensions;

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

        services.AddTransient<ICacheService, CacheService>();

        services.Configure<CacheOptions>(configuration.GetSection(CacheOptions.Region));

        return services;
    }

    public static WebApplication UseInfrastructureServices(this WebApplication app)
    {


        return app;
    }
}
