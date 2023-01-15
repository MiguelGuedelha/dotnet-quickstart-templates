namespace CleanArchMinimalApi.Presentation.ExampleFeature.Get;

internal sealed record ExampleFeatureGetResponse
{
    public required int Id { get; init; }
    public int CalculatedProp => Id * 3;
}
