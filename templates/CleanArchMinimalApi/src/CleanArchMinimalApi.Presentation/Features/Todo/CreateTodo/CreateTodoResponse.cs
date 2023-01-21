using CleanArchMinimalApi.Application.Features.Todo.CreateTodo;

namespace CleanArchMinimalApi.Presentation.Features.Todo.CreateTodo;

public sealed record CreateTodoResponse
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required string Note { get; init; }
    public required bool Done { get; init; }

    public static CreateTodoResponse MapFromCommandResponse(CreateTodoCommandResult result)
    {
        return new()
        {
            Id = result.Id, 
            Title = result.Title, 
            Done = result.Done, 
            Note = result.Note
        };
    }
}
