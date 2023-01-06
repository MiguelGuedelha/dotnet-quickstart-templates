using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using CleanArchMinimalApi.Application.Shared.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CleanArchMinimalApi.Application.Shared.Middleware;

internal sealed partial class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            await HandleExceptionAsync(context, e);
        }
    }
    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var statusCode = GetStatusCode(exception);

        var statusName = string.Join(" ", CamelCase().Split(((HttpStatusCode)statusCode).ToString()));

        var response = new
        {
            Title = statusName,
            Status = statusCode,
            Detail = exception.Message,
            Errors = GetErrors(exception)
        };

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
    private static int GetStatusCode(Exception exception) =>
        exception switch
        {
            ValidationException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

    private static IReadOnlyDictionary<string, string[]>? GetErrors(Exception exception)
    {
        IReadOnlyDictionary<string, string[]>? errors = null;
        if (exception is ValidationException validationException)
        {
            errors = validationException.Errors;
        }
        return errors;
    }

    [GeneratedRegex("(?<!^)(?=[A-Z])")]
    private static partial Regex CamelCase();
}
