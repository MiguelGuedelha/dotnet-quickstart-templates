using CleanArchMinimalApi.Domain.Shared.Entities;

namespace CleanArchMinimalApi.Domain.Features.Todo;

public record TodoItem : BaseEntity
{
    public required string Title { get; set; }
    public required string Note { get; set; }
    public required bool Done { get; set; }
}
