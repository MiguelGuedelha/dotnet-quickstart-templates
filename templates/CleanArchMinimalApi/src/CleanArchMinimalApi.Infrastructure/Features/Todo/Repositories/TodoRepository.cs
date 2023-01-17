using CleanArchMinimalApi.Application.Abstractions.Persistence;
using CleanArchMinimalApi.Application.Features.Todo.Repositories;
using CleanArchMinimalApi.Domain.Features.Todo;

namespace CleanArchMinimalApi.Infrastructure.Features.Todo.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly IApplicationDbContext _applicationDbContext;

    public TodoRepository(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> CreateTodoItem(TodoItem item)
    {
        _applicationDbContext.TodoItems.Add(item);

        var result = await _applicationDbContext.SaveChangesAsync();

        return result == 1;
    }
}
