namespace CleanArchMinimalApi.Application.Abstractions.Caching;

public interface ICacheRepository
{
    Task SetAsync<T>(string key, T value, CancellationToken cancellationToken)
        where T : class;

    Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken)
        where T : class;

    Task RemoveAsync(string key, CancellationToken cancellationToken);

    Task ClearPattern(string pattern, CancellationToken cancellationToken);

    Task ClearAll(CancellationToken cancellationToken);
}
