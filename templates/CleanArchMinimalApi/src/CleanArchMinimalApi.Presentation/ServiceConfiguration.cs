using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMinimalApi.Presentation;

public static class ServiceConfiguration
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
