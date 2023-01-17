using CleanArchMinimalApi.Domain.Features.Todo;

namespace CleanArchMinimalApi.Application.Features.Todo.Repositories;

public interface ITodoRepository
{
    Task<bool> CreateTodoItem(TodoItem item);
}
