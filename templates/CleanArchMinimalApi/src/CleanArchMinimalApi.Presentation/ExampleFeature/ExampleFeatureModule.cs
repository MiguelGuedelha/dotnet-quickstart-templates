using CleanArchMinimalApi.Application.ExampleFeature.Get;
using CleanArchMinimalApi.Application.ExampleFeature.Post;
using CleanArchMinimalApi.Presentation.ExampleFeature.Requests;
using CleanArchMinimalApi.Presentation.Shared.Extensions;
using Microsoft.AspNetCore.Routing;

namespace CleanArchMinimalApi.Presentation.ExampleFeature;

public class ExampleFeatureModule : CarterModule
{
    public ExampleFeatureModule() : base("/example-feature")
    {

    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MediateGet<ExampleFeatureGetRequest, ExampleFeatureGetQuery, ExampleFeatureGetQueryResponse>("/{id}");
        app.MediatePost<ExampleFeaturePostRequest, ExampleFeaturePostCommand, ExampleFeaturePostCommandResponse>("/{id}");
    }
}
