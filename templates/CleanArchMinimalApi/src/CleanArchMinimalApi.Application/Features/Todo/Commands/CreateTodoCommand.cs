using CleanArchMinimalApi.Application.Abstractions.Command;
using CleanArchMinimalApi.Application.Features.Todo.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMinimalApi.Application.Features.Todo.Commands;

public record CreateTodoCommand : ICommand<CreateTodoResponse>
{
    [FromBody] 
    public required CreateTodoCommandBody Body { get; init; }
}

public record CreateTodoCommandBody
{
    public required string Title { get; init; }
    public required string Note { get; init; }
}
