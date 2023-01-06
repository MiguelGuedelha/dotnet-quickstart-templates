using Microsoft.AspNetCore.Mvc;

namespace CleanArchMinimalApi.Presentation.ExampleFeature.Requests;

internal sealed record ExampleFeaturePostRequest
{
    public int Id { get; init; }

    [FromBody]
    public RequestBody NestedProperty { get; init; }
};

internal sealed record RequestBody(string Name, string Sort);
