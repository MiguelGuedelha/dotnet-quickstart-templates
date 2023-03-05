using CleanArchMinimalApi.Application.Shared.Mediator;

namespace CleanArchMinimalApi.Application.Features.Todo.CreateTodo;

public sealed record CreateTodoCommand : ICommand<CreateTodoCommandResult>
{
    public required string Title { get; init; }
    public required string Note { get; init; }
}
