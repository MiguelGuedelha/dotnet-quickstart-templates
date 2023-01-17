using CleanArchMinimalApi.Domain.Features.Todo;

namespace CleanArchMinimalApi.Application.Features.Todo.Responses;

public record CreateTodoResponse
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required string Note { get; init; }
    public required bool Done { get; init; }

    public static CreateTodoResponse MapFromTodoItem(TodoItem item)
    {
        return new CreateTodoResponse
        {
            Id = item.Id,
            Title = item.Title,
            Note = item.Note,
            Done = item.Done
        };
    }
}
