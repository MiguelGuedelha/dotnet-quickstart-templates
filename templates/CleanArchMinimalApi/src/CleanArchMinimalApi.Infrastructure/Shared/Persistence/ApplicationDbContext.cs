using CleanArchMinimalApi.Domain.Features.Todo;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMinimalApi.Infrastructure.Shared.Persistence;

internal sealed class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public required DbSet<TodoItem> TodoItems { get; set; }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}
