using OpenPantry.Domain.Common.Entities.Events;
using OpenPantry.Domain.Common.Results;

namespace OpenPantry.Domain.Common.Entities.Actions;

public abstract class EntityAction<TEntity, TEvent> : IEntityAction<TEntity> where TEntity : Entity<TEntity> where TEvent : IEntityEvent<TEntity>
{
    public required DateTimeOffset Timestamp { get; init; }

    protected abstract (TEntity NewState, TEvent ResultingEvent) DeriveNewState(TEntity? previousState);

    public TEntity Apply(TEntity? previousState)
    {
        try
        {
            var (newState, resultingEvent) = DeriveNewState(previousState);
            newState.AddEvent(resultingEvent);
            return newState;
        }
        catch (Exception exception)
        {
            throw new EventApplyFailedException(GetType(), typeof(TEntity), exception);
        }
    }
}

public abstract class EntityAction<TEntity, TError, TEvent> : IEntityAction<TEntity> where TEntity : Entity<TEntity> where TEvent : IEntityEvent<TEntity>
{
    public required DateTimeOffset Timestamp { get; init; }

    protected abstract Result<(TEntity NewState, TEvent ResultingEvent), TError> DeriveNewState(TEntity? previousState);

    public Result<TEntity, TError> Apply(TEntity? previousState)
    {
        try
        {
            var result = DeriveNewState(previousState);
            if (result.IsFailure)
                return result.Error;

            var (newState, resultingEvent) = result.Value;
            newState.AddEvent(resultingEvent);
            return newState;
        }
        catch (Exception exception)
        {
            throw new EventApplyFailedException(GetType(), typeof(TEntity), exception);
        }
    }
}