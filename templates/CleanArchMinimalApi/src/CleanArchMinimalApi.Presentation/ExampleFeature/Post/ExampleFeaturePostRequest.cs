using Microsoft.AspNetCore.Mvc;

namespace CleanArchMinimalApi.Presentation.ExampleFeature.Post;

internal sealed record ExampleFeaturePostRequest
{
    public int Id { get; init; }

    [FromBody]
    public RequestBody Body { get; init; }
}

internal sealed record RequestBody(string Name, string Sort);
