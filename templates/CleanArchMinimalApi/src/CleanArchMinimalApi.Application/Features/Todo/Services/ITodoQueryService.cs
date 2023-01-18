using CleanArchMinimalApi.Application.Features.Todo.GetTodo;

namespace CleanArchMinimalApi.Application.Features.Todo.Services;

public interface ITodoQueryService
{
    Task<GetTodoQueryResult> GetTodo(GetTodoQuery query, CancellationToken cancellationToken);
}
