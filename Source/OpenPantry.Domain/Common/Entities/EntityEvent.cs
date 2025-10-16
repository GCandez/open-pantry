namespace OpenPantry.Domain.Common.Entities;

public abstract record EntityEvent<TEntity, TEventData> : IEntityEvent<TEntity>
    where TEntity : Entity<TEntity>
{
    public required Guid Id { get; init; }
    public required DateTimeOffset Timestamp { get; init; }
    public required TEventData Data { get; init; }

    public abstract TEntity Apply(TEntity? previousState);
}