namespace CleanArchMinimalApi.Application.Abstractions.Services;

public interface ICacheService
{
    Task SetAsync<T>(string key, T value, CancellationToken cancellationToken) where T : class;

    Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken) where T : class;

    Task RemoveAsync(string key, CancellationToken cancellationToken);

    Task ClearPattern(string pattern, CancellationToken cancellationToken);

    Task ClearAll(CancellationToken cancellationToken);
}
