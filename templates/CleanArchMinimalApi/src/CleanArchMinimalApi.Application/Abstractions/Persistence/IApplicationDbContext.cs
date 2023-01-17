using CleanArchMinimalApi.Domain.Features.Todo;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMinimalApi.Application.Abstractions.Persistence;

public interface IApplicationDbContext
{
    DbSet<TodoItem> TodoItems { get; set; }

    Task<int> SaveChangesAsync();
}
