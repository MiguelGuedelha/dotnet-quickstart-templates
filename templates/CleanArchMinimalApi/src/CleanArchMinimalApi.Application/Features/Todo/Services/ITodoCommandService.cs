using CleanArchMinimalApi.Application.Features.Todo.Commands;
using CleanArchMinimalApi.Application.Features.Todo.Responses;

namespace CleanArchMinimalApi.Application.Features.Todo.Services;

public interface ITodoCommandService
{
    Task<CreateTodoResponse> CreateTodo(CreateTodoCommand command, CancellationToken cancellationToken);
}
