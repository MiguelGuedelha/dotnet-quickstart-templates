using CleanArchMinimalApi.Application.ExampleFeature.Get;
using CleanArchMinimalApi.Application.ExampleFeature.Post;
using CleanArchMinimalApi.Presentation.ExampleFeature.Get;
using CleanArchMinimalApi.Presentation.ExampleFeature.Post;
using CleanArchMinimalApi.Presentation.ExampleFeature.Requests;
using CleanArchMinimalApi.Presentation.Shared.Extensions;
using Microsoft.AspNetCore.Routing;

namespace CleanArchMinimalApi.Presentation.ExampleFeature;

public sealed class ExampleFeatureModule : CarterModule
{
    public ExampleFeatureModule() : base("/example-feature")
    {
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MediateGet<ExampleFeatureGetRequest, ExampleFeatureGetQuery, ExampleFeatureGetQueryResponse, ExampleFeatureGetResponse>("/{id}");
        app.MediatePost<ExampleFeaturePostRequest, ExampleFeaturePostCommand, ExampleFeaturePostCommandResponse, ExampleFeaturePostResponse>("/{id}");
    }
}
