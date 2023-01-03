using MediatR;

namespace CleanArchMinimalApi.Application.ExampleFeature.Get;


public record ExampleFeatureGetQuery(
    int Id, string Sort) : IRequest<ExampleFeatureGetQueryResponse>;
