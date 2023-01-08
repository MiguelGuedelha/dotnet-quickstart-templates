using CleanArchMinimalApi.Application.Abstractions.Query;

namespace CleanArchMinimalApi.Application.ExampleFeature.Get;

public sealed record ExampleFeatureGetQuery(int Id, string Sort) : IQuery<ExampleFeatureGetQueryResponse>;

public sealed record ExampleFeatureGetQueryResponse(int id);
