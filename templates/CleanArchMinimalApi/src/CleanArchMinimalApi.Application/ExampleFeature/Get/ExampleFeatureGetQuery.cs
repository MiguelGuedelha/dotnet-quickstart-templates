using CleanArchMinimalApi.Application.Abstractions;

namespace CleanArchMinimalApi.Application.ExampleFeature.Get;


public record ExampleFeatureGetQuery(int Id, string Sort) : IQuery<ExampleFeatureGetQueryResponse>;
