using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMinimalApi.Application.Extensions;

public static class ServiceConfigurationExtensions
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddCarter();

        return services;
    }

    public static WebApplication UsePresentationServices(this WebApplication app)
    {
        app.MapCarter();

        return app;
    }
}
