using CleanArchMinimalApi.Application.Abstractions.Caching;
using CleanArchMinimalApi.Application.Features.Todo.GetTodo;
using CleanArchMinimalApi.Application.Features.Todo.Repositories;
using CleanArchMinimalApi.Domain.Features.Todo;
using CleanArchMinimalApi.Infrastructure.Features.Todo.Options;
using CleanArchMinimalApi.Shared.Helpers;
using Microsoft.Extensions.Options;

namespace CleanArchMinimalApi.Infrastructure.Features.Todo.Repositories;

internal sealed class CachedTodoRepository : ITodoRepository
{
    private readonly ICacheRepository _cacheRepository;
    private readonly TodoOptions _todoOptions;
    private readonly TodoRepository _todoRepository;

    public CachedTodoRepository(
        TodoRepository todoRepository,
        ICacheRepository cacheRepository,
        IOptions<TodoOptions> todoOptions)
    {
        ArgumentHelper.Initialise(todoRepository, out _todoRepository);
        ArgumentHelper.Initialise(cacheRepository, out _cacheRepository);
        ArgumentHelper.Initialise(todoOptions.Value, out _todoOptions);
    }

    public async Task<bool> CreateTodoItem(TodoItem item, CancellationToken cancellationToken)
    {
        return await _todoRepository.CreateTodoItem(item, cancellationToken);
    }

    public async Task<GetTodoQueryResult?> GetTodoById(Guid queryId, CancellationToken cancellationToken)
    {
        var cacheKeyFormat = _todoOptions.CacheKeys.TodoCacheKeyFormat;
        var cacheKey = string.Format(cacheKeyFormat, queryId);

        var cacheResult = await _cacheRepository.GetAsync<GetTodoQueryResult>(cacheKey, cancellationToken);

        if (cacheResult is not null)
            return cacheResult;

        var todo = await _todoRepository.GetTodoById(queryId, cancellationToken);

        if (todo is not null)
            await _cacheRepository.SetAsync(cacheKey, todo, cancellationToken);

        return todo;
    }
}
