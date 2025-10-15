namespace OpenPantry.Domain.Common.Entities;

public abstract record EntityEvent<TEntity>
    where TEntity : Entity<TEntity>
{
    public required Guid Id { get; init; }
    public required DateTimeOffset Timestamp { get; init; }

    public abstract TEntity Apply(TEntity? previousState);
}