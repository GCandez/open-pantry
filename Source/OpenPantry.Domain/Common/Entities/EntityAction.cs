using OpenPantry.Domain.Common.Results;

namespace OpenPantry.Domain.Common.Entities;

public abstract class EntityAction<TEntity, TEvent> where TEntity : Entity<TEntity> where TEvent : IEntityEvent<TEntity>
{
    public required DateTimeOffset Timestamp { get; init; }

    protected abstract (TEntity NewState, TEvent ResultingEvent) DeriveNewState(TEntity? previousState);

    public TEntity Apply(TEntity? previousState)
    {
        var (newState, resultingEvent) = DeriveNewState(previousState);
        newState.AddEvent(resultingEvent);
        return newState;
    }
}

public abstract class EntityAction<TEntity, TError, TEvent> where TEntity : Entity<TEntity> where TEvent : IEntityEvent<TEntity>
{
    public required DateTimeOffset Timestamp { get; init; }

    protected abstract Result<(TEntity NewState, TEvent ResultingEvent), TError> DeriveNewState(TEntity? previousState);

    public Result<TEntity, TError> Apply(TEntity? previousState)
    {
        var result = DeriveNewState(previousState);
        if (result.IsFailure)
            return result.Error;

        var (newState, resultingEvent) = result.Value;
        newState.AddEvent(resultingEvent);
        return newState;
    }
}
