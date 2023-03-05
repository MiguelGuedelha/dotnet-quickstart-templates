using Microsoft.AspNetCore.Http;

namespace CleanArchMinimalApi.Application.Shared.Services;

public interface ICorrelationIdService
{
    string GetCorrelationId();

    string GetCorrelationId(HttpContext context);
}
