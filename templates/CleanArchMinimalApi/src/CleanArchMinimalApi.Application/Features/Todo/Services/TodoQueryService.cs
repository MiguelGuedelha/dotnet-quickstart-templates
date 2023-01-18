using CleanArchMinimalApi.Application.Features.Todo.GetTodo;
using CleanArchMinimalApi.Application.Features.Todo.Repositories;

namespace CleanArchMinimalApi.Application.Features.Todo.Services;

public class TodoQueryService : ITodoQueryService
{
    private readonly ITodoRepository _todoRepository;

    public TodoQueryService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<GetTodoQueryResult> GetTodo(GetTodoQuery query, CancellationToken cancellationToken)
    {
        return await _todoRepository.GetTodoById(query.Id, cancellationToken);
    }
}
