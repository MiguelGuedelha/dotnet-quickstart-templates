using CleanArchMinimalApi.Application.Abstractions;

namespace CleanArchMinimalApi.Application.ExampleFeature.Get;

internal sealed class ExampleFeatureGetQueryHandler : IQueryHandler<ExampleFeatureGetQuery, ExampleFeatureGetQueryResponse>
{
    public async Task<ExampleFeatureGetQueryResponse> Handle(ExampleFeatureGetQuery request, CancellationToken cancellationToken)
    {
        await Task.Delay(0, cancellationToken);
        return new ExampleFeatureGetQueryResponse(request.Id);
    }

}
