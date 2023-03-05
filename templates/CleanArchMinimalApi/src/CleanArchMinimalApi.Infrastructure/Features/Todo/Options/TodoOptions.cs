namespace CleanArchMinimalApi.Infrastructure.Features.Todo.Options;

internal sealed class TodoOptions
{
    public const string Region = "Features:Todo";

    public required CacheKeys CacheKeys { get; init; }
}

internal sealed class CacheKeys
{
    public required string TodoCacheKeyFormat { get; init; }
}
