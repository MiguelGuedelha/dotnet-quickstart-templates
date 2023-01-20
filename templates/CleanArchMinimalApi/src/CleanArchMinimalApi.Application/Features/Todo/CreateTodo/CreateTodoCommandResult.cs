using CleanArchMinimalApi.Domain.Features.Todo;

namespace CleanArchMinimalApi.Application.Features.Todo.CreateTodo;

public record CreateTodoCommandResult
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required string Note { get; init; }
    public required bool Done { get; init; }

    public static CreateTodoCommandResult MapFromTodoItem(TodoItem item)
    {
        return new() { Id = item.Id, Title = item.Title, Note = item.Note, Done = item.Done };
    }
}
