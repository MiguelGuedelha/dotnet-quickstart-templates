using CleanArchMinimalApi.Application.Abstractions;

namespace CleanArchMinimalApi.Application.ExampleFeature.Post;

public record ExampleFeaturePostCommand(int Id, string NestedPropertyName, string NestedPropertySort) : ICommand<ExampleFeaturePostCommandResponse>
{
}
