namespace CleanArchMinimalApi.Domain.Shared.Entities;

public abstract record BaseEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required DateTime Created { get; init; }
    public DateTime? LastModified { get; init; }
}
