using CleanArchMinimalApi.Application.Features.Todo.GetTodo;

namespace CleanArchMinimalApi.Presentation.Features.Todo.GetTodo;

public record GetTodoResponse
{
    public required string Title { get; init; }
    public required string Note { get; init; }
    public required bool Done { get; init; }

    public static GetTodoResponse MapFromQueryResponse(GetTodoQueryResult result)
    {
        return new() { Title = result.Title, Note = result.Note, Done = result.Done };
    }
}
