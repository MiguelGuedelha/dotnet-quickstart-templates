using CleanArchMinimalApi.Application.Abstractions.Command;

namespace CleanArchMinimalApi.Application.ExampleFeature.Post;

internal sealed class ExampleFeaturePostCommandHandler : ICommandHandler<ExampleFeaturePostCommand, ExampleFeaturePostCommandResponse>
{

    public async Task<ExampleFeaturePostCommandResponse> Handle(ExampleFeaturePostCommand command, CancellationToken cancellationToken)
    {
        await Task.Delay(0, cancellationToken);
        return new ExampleFeaturePostCommandResponse(command.Id, command.NestedPropertyName);
    }
}
