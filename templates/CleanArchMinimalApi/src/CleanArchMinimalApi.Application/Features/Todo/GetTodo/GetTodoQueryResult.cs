using CleanArchMinimalApi.Domain.Features.Todo;

namespace CleanArchMinimalApi.Application.Features.Todo.GetTodo;

public record GetTodoQueryResult
{
    public required string Title { get; init; }
    public required string Note { get; init; }
    public required bool Done { get; init; }

    public static GetTodoQueryResult MapFromTodoItem(TodoItem todo)
    {
        return new()
        {
            Title = todo.Title, 
            Note = todo.Note, 
            Done = todo.Done
        };
    }
}
