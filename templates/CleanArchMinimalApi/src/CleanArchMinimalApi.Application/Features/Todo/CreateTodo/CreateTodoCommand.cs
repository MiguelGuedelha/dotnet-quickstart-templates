using CleanArchMinimalApi.Application.Abstractions.Mediator;
using CleanArchMinimalApi.Application.Features.Todo.CreateTodo;

namespace CleanArchMinimalApi.Application.Features.Todo.Commands;

public sealed record CreateTodoCommand : ICommand<CreateTodoCommandResult>
{
    public required string Title { get; init; }
    public required string Note { get; init; }
}
