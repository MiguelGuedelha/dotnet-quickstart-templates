using CleanArchMinimalApi.Application.Abstractions.Caching;
using CleanArchMinimalApi.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace CleanArchMinimalApi.Infrastructure.Shared.Caching;

internal sealed class CacheKeyService : ICacheKeyService
{
    private readonly CacheKeyOptions _cacheKeyOptions;


    public CacheKeyService(IOptions<CacheKeyOptions> cacheKeyOptions)
    {
        _cacheKeyOptions = cacheKeyOptions.Value;
    }

    public string ExampleCacheKey(string handlerName, int id, string sort)
    {
        return string.Format(_cacheKeyOptions.ExampleCacheKeyFormat, handlerName, id, sort);
    }
}
