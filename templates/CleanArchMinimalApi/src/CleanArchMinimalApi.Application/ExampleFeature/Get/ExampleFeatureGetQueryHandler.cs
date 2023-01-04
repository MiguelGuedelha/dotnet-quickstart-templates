using MediatR;

namespace CleanArchMinimalApi.Application.ExampleFeature.Get;

internal class ExampleFeaturePostCommandHandler : IRequestHandler<ExampleFeatureGetQuery, ExampleFeatureGetQueryResponse>
{
    public async Task<ExampleFeatureGetQueryResponse> Handle(ExampleFeatureGetQuery request, CancellationToken cancellationToken)
    {
        await Task.Delay(0, cancellationToken);
        return new ExampleFeatureGetQueryResponse(request.Id);
    }

}
