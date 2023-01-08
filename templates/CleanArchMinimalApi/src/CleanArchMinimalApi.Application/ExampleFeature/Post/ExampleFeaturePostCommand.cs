using CleanArchMinimalApi.Application.Abstractions.Command;

namespace CleanArchMinimalApi.Application.ExampleFeature.Post;

public sealed record ExampleFeaturePostCommand(int Id, string NestedPropertyName, string NestedPropertySort) : ICommand<ExampleFeaturePostCommandResponse>;

public sealed record ExampleFeaturePostCommandResponse(int Id, string Name);
