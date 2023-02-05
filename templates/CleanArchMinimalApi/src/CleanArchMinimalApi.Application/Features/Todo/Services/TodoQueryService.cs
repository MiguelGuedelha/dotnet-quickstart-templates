using CleanArchMinimalApi.Application.Features.Todo.GetTodo;
using CleanArchMinimalApi.Application.Features.Todo.Repositories;
using CleanArchMinimalApi.Application.Shared.Exceptions;

namespace CleanArchMinimalApi.Application.Features.Todo.Services;

internal sealed class TodoQueryService : ITodoQueryService
{
    private readonly ITodoRepository _todoRepository;

    public TodoQueryService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<GetTodoQueryResult> GetTodo(GetTodoQuery query, CancellationToken cancellationToken)
    {
        var todo = await _todoRepository.GetTodoById(query.Id, cancellationToken);

        if (todo is null)
            throw new NotFoundException<GetTodoQueryResult>($"Failed to get todo with Id={query.Id}");

        return todo;
    }
}
