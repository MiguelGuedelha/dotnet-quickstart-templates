using CleanArchMinimalApi.Application.Features.Todo.GetTodo;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMinimalApi.Presentation.Features.Todo.GetTodo;

public sealed record GetTodoRequest
{
    [FromRoute] public Guid Id { get; init; }

    public static GetTodoQuery MapToCommand(GetTodoRequest request)
    {
        return new()
        {
            Id = request.Id
        };
    }
}
