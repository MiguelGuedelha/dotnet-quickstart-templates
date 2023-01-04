using Microsoft.AspNetCore.Mvc;

namespace CleanArchMinimalApi.Presentation.ExampleFeature.Requests;

internal record ExampleFeaturePostRequest
{
    public int Id { get; init; }

    [FromBody]
    public RequestBody NestedProperty { get; init; }
};

internal record RequestBody(string Name, string Sort);
