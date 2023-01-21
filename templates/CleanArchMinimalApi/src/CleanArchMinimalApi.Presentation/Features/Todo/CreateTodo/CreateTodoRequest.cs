using CleanArchMinimalApi.Application.Features.Todo.CreateTodo;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMinimalApi.Presentation.Features.Todo.CreateTodo;

internal sealed record CreateTodoRequest
{
    [FromBody] public required CreateTodoRequestBody Body { get; init; }

    public static CreateTodoCommand MapToCommand(CreateTodoRequest request)
    {
        return new()
        {
            Note = request.Body.Note, 
            Title = request.Body.Title
        };
    }
}

internal sealed record CreateTodoRequestBody
{
    public required string Title { get; init; }
    public required string Note { get; init; }
}
