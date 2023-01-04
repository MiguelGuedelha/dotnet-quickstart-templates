using MediatR;

namespace CleanArchMinimalApi.Application.ExampleFeature.Post;

internal class ExampleFeaturePostCommandHandler : IRequestHandler<ExampleFeaturePostCommand, ExampleFeaturePostCommandResponse>
{

    public async Task<ExampleFeaturePostCommandResponse> Handle(ExampleFeaturePostCommand command, CancellationToken cancellationToken)
    {
        await Task.Delay(0, cancellationToken);
        return new ExampleFeaturePostCommandResponse(command.Id, command.NestedPropertyName);
    }
}
