using Microsoft.AspNetCore.Http;

namespace CleanArchMinimalApi.Application.Shared.Services;

public class CorrelationIdService : ICorrelationIdService
{
    private const string CorrelationIdHeaderKey = "X-Correlation-ID";
    private string _correlationId = string.Empty;

    public string GetCorrelationId()
    {
        return _correlationId;
    }

    public string GetCorrelationId(HttpContext context)
    {
        if (!string.IsNullOrWhiteSpace(_correlationId))
            return _correlationId;

        if (!context.Request.Headers.TryGetValue(CorrelationIdHeaderKey, out var stringValues))
        {
            _correlationId = Guid.NewGuid()
               .ToString();
            return _correlationId;
        }

        var correlationId = stringValues.FirstOrDefault(x => x == CorrelationIdHeaderKey)!;
        _correlationId = correlationId;
        return _correlationId;
    }
}
