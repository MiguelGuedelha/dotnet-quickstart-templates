namespace CleanArchMinimalApi.Infrastructure.Options;

internal sealed class CacheOptions
{
    public const string Region = "Cache";

    public int AbsoluteExpiration { get; init; }

    public int SlidingExpiration { get; init; }
}
