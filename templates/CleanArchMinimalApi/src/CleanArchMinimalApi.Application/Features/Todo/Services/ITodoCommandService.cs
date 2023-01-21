using CleanArchMinimalApi.Application.Features.Todo.CreateTodo;

namespace CleanArchMinimalApi.Application.Features.Todo.Services;

internal interface ITodoCommandService
{
    Task<CreateTodoCommandResult> CreateTodo(CreateTodoCommand command, CancellationToken cancellationToken);
}
