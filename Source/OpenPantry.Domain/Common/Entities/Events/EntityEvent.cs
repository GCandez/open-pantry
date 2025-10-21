namespace OpenPantry.Domain.Common.Entities.Events;

public abstract record EntityEvent<TEntity, TEventData> : IEntityEvent<TEntity>
    where TEntity : Entity<TEntity>
{
    public required TEventData Data { get; init; }
    public required Guid Id { get; init; }
    public required DateTimeOffset Timestamp { get; init; }

    public abstract TEntity DeriveNewState(TEntity? previousState);

    public TEntity Apply(TEntity? previousState)
    {
        try
        {
            return DeriveNewState(previousState);
        }
        catch (Exception exception)
        {
            throw new EventApplyFailedException(GetType(), typeof(TEntity), exception);
        }
    }
}