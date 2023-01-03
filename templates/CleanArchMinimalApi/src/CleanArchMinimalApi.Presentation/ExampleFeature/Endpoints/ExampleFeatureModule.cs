using Carter;
using CleanArchMinimalApi.Application.ExampleFeature.Get;
using CleanArchMinimalApi.Presentation.ExampleFeature.Requests;
using CleanArchMinimalApi.Presentation.Shared.Extensions;
using Microsoft.AspNetCore.Routing;

namespace CleanArchMinimalApi.Presentation.ExampleFeature.Endpoints;

public class ExampleFeatureModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MediateGet<ExampleFeatureGetRequest, ExampleFeatureGetQuery, ExampleFeatureGetQueryResponse>("feature-one/{id}");
    }
}
