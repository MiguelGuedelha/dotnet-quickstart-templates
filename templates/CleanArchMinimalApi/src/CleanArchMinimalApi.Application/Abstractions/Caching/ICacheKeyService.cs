namespace CleanArchMinimalApi.Application.Abstractions.Caching;

public interface ICacheKeyService
{
    string ExampleCacheKey(string handlerName, int id, string sort);
}
