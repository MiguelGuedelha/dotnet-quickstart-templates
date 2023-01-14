namespace CleanArchMinimalApi.Infrastructure.Options;

internal sealed class CacheKeyOptions
{
    public const string Region = "CacheKey";

    public required string ExampleCacheKeyFormat { get; init; }
}
