namespace CleanArchMinimalApi.Presentation.ExampleFeature.Post;

internal sealed record ExampleFeaturePostResponse()
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public string IdName => $"{Id}-{Name}";
}
