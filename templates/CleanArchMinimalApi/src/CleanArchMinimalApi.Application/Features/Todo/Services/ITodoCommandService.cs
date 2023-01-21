using CleanArchMinimalApi.Application.Features.Todo.CreateTodo;

namespace CleanArchMinimalApi.Application.Features.Todo.Services;

public interface ITodoCommandService
{
    Task<CreateTodoCommandResult> CreateTodo(CreateTodoCommand command, CancellationToken cancellationToken);
}
