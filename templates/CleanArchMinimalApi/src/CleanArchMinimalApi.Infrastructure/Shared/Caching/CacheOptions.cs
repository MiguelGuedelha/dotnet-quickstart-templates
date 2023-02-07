namespace CleanArchMinimalApi.Infrastructure.Shared.Caching;

internal sealed class CacheOptions
{
    public const string Region = "Cache";

    public int AbsoluteExpiration { get; init; }

    public int SlidingExpiration { get; init; }
}
