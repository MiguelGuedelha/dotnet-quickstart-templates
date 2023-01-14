using CleanArchMinimalApi.Application.Abstractions.Caching;
using CleanArchMinimalApi.Application.Abstractions.Query;
using CleanArchMinimalApi.Shared.Helpers;

namespace CleanArchMinimalApi.Application.ExampleFeature.Get;

public sealed class ExampleFeatureGetQueryHandler : IQueryHandler<ExampleFeatureGetQuery, ExampleFeatureGetQueryResponse>
{
    private readonly ICacheService _cacheService;
    private readonly ICacheKeyService _cacheKeyService;

    public ExampleFeatureGetQueryHandler(ICacheService cacheService, ICacheKeyService cacheKeyService)
    {
        ArgumentHelper.Initialise(cacheKeyService, out _cacheKeyService);
        ArgumentHelper.Initialise(cacheService, out _cacheService);
    }

    public async Task<ExampleFeatureGetQueryResponse> Handle(ExampleFeatureGetQuery request, CancellationToken cancellationToken)
    {
        var key = _cacheKeyService.ExampleCacheKey(nameof(ExampleFeatureGetQueryHandler), request.Id, request.Sort);

        var response = await _cacheService.GetAsync<ExampleFeatureGetQueryResponse>(key, cancellationToken);

        if (response is not null)
        {
            return response;
        }

        // Logic would be above here
        response = new ExampleFeatureGetQueryResponse(request.Id);

        await _cacheService.SetAsync(key, response, cancellationToken);

        await Task.Delay(0, cancellationToken);
        return response;
    }
}
