using CleanArchMinimalApi.Application.Shared.Services;
using CleanArchMinimalApi.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CleanArchMinimalApi.Application.Shared.Middleware;

public class CorrelationIdMiddleware : IMiddleware
{
    private const string CorrelationIdHeaderKey = "X-Correlation-ID";
    private readonly ICorrelationIdService _correlationIdService;
    private readonly ILogger<CorrelationIdMiddleware> _logger;


    public CorrelationIdMiddleware(ILogger<CorrelationIdMiddleware> logger, ICorrelationIdService correlationIdService)
    {
        _correlationIdService = ArgumentHelper.Initialise(correlationIdService);
        _logger = ArgumentHelper.Initialise(logger);
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var correlationId = _correlationIdService.GetCorrelationId(context);

        _logger.LogInformation("CorrelationId for request | Id: {@CorrelationId}", correlationId);

        context.Response.OnStarting(() =>
        {
            if (!context.Response.Headers.TryGetValue(CorrelationIdHeaderKey, out _))
                context.Response.Headers.Add(CorrelationIdHeaderKey, correlationId);
            return Task.CompletedTask;
        });

        await next(context);
    }
}
