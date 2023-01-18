using CleanArchMinimalApi.Application.Features.Todo.GetTodo;
using CleanArchMinimalApi.Application.Features.Todo.Repositories;
using CleanArchMinimalApi.Application.Shared.Exceptions;
using CleanArchMinimalApi.Domain.Features.Todo;
using CleanArchMinimalApi.Infrastructure.Abstractions.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMinimalApi.Infrastructure.Features.Todo.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly IApplicationDbContext _applicationDbContext;

    public TodoRepository(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> CreateTodoItem(TodoItem item, CancellationToken cancellationToken)
    {
        _applicationDbContext.TodoItems.Add(item);
        
        var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
        
        return result == 1;
    }

    public async Task<GetTodoQueryResult> GetTodoById(Guid id, CancellationToken cancellationToken)
    {
        var todo = await _applicationDbContext.TodoItems
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (todo is null)
        {
            throw new NotFoundException($"Todo with Id={id} not found");
        }

        return GetTodoQueryResult.MapFromTodoItem(todo);
    }
}
