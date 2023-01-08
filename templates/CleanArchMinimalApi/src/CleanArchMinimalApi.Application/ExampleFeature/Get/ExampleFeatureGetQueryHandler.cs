using CleanArchMinimalApi.Application.Abstractions.Caching;
using CleanArchMinimalApi.Application.Abstractions.Query;
using CleanArchMinimalApi.Shared.Helpers;

namespace CleanArchMinimalApi.Application.ExampleFeature.Get;

public sealed class ExampleFeatureGetQueryHandler : IQueryHandler<ExampleFeatureGetQuery, ExampleFeatureGetQueryResponse>
{
    private readonly ICacheService _cacheService;

    public ExampleFeatureGetQueryHandler(ICacheService cacheService)
    {
        ArgumentHelper.Initialise(cacheService, out _cacheService);
    }

    public async Task<ExampleFeatureGetQueryResponse> Handle(ExampleFeatureGetQuery request, CancellationToken cancellationToken)
    {
        ExampleFeatureGetQueryResponse? response;

        var key = $"{nameof(ExampleFeatureGetQueryHandler)}:{request.Id}_{request.Sort}";

        response = await _cacheService.GetAsync<ExampleFeatureGetQueryResponse>(key, cancellationToken);

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
