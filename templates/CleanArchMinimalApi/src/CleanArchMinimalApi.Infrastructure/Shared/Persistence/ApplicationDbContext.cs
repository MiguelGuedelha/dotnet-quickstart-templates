using CleanArchMinimalApi.Domain.Features.Todo;
using CleanArchMinimalApi.Infrastructure.Abstractions.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMinimalApi.Infrastructure.Shared.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    public DbSet<TodoItem> TodoItems { get; set; }
    
    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}
