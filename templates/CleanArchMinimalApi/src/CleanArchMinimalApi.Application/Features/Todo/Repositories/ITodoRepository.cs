using CleanArchMinimalApi.Application.Features.Todo.GetTodo;
using CleanArchMinimalApi.Domain.Features.Todo;

namespace CleanArchMinimalApi.Application.Features.Todo.Repositories;

public interface ITodoRepository
{
    Task<bool> CreateTodoItem(TodoItem item, CancellationToken cancellationToken);
    Task<GetTodoQueryResult?> GetTodoById(Guid queryId, CancellationToken cancellationToken);
}
