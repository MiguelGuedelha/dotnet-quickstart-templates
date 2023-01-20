using CleanArchMinimalApi.Domain.Features.Todo;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMinimalApi.Infrastructure.Shared.Persistence;

public interface IApplicationDbContext
{
    DbSet<TodoItem> TodoItems { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
