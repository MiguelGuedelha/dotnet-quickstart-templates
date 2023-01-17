using System.Text.Json;
using CleanArchMinimalApi.Application.Abstractions.Caching;
using CleanArchMinimalApi.Infrastructure.Options;
using CleanArchMinimalApi.Shared.Helpers;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace CleanArchMinimalApi.Infrastructure.Shared.Caching;

internal sealed class CacheService : ICacheService
{
    private readonly IDistributedCache _distributedCache;
    private readonly DistributedCacheEntryOptions _insertionOptions;
    private readonly IEnumerable<IServer> _servers;

    public CacheService(IDistributedCache distributedCache, IConnectionMultiplexer multiplexer,
        IOptions<CacheOptions> options)
    {
        ArgumentHelper.Initialise(distributedCache, out _distributedCache);
        ArgumentHelper.Initialise(multiplexer.GetEndPoints().Select(x => multiplexer.GetServer(x)), out _servers);
        ArgumentHelper.Initialise(options.Value, out var cacheOptions);

        _insertionOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheOptions.AbsoluteExpiration),
            SlidingExpiration = TimeSpan.FromSeconds(cacheOptions.SlidingExpiration)
        };
    }

    public async Task SetAsync<T>(string key, T value, CancellationToken cancellationToken)
        where T : class =>
        await _distributedCache.SetStringAsync(key, JsonSerializer.Serialize(value), _insertionOptions,
            cancellationToken);

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken)
        where T : class
    {
        var cacheString = await _distributedCache.GetStringAsync(key, cancellationToken);

        if (string.IsNullOrWhiteSpace(cacheString))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<T>(cacheString);
        }
        catch
        {
            await RemoveAsync(key, cancellationToken);
            return null;
        }
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken) =>
        await _distributedCache.RemoveAsync(key, cancellationToken);

    public async Task ClearPattern(string pattern, CancellationToken cancellationToken)
    {
        var keys = _servers.SelectMany(server => server.Keys(pattern: pattern, pageSize: 1000));
        foreach (var key in keys)
        {
            await RemoveAsync(key!, cancellationToken);
        }
    }

    public async Task ClearAll(CancellationToken cancellationToken) => await ClearPattern("*", cancellationToken);
}
