using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMinimalApi.Application.Extensions;

public static class ServiceConfigurationExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {


        return services;
    }

    public static WebApplication UseInfrastructureServices(this WebApplication app)
    {


        return app;
    }
}
