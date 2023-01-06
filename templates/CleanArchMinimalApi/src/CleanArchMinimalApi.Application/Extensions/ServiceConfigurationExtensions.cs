using CleanArchMinimalApi.Application.Shared.Middleware;
using CleanArchMinimalApi.Application.Shared.Validation;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMinimalApi.Application.Extensions;

public static class ServiceConfigurationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(ApplicationAssembly.Instance);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(QueryValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
        services.AddTransient<ExceptionHandlingMiddleware>();

        services.AddValidatorsFromAssembly(ApplicationAssembly.Instance);

        return services;
    }

    public static WebApplication UseApplicationServices(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();

        return app;
    }
}
