namespace OpenPantry.Domain.Common.Entities;

public abstract class EntityAction<TEntity, TEvent> where TEntity : Entity<TEntity> where TEvent : EntityEvent<TEntity>
{
    protected abstract (TEntity NewState, TEvent ResultingEvent) DeriveNewState(TEntity? previousState);

    public TEntity Apply(TEntity? previousState)
    {
        var (newState, resultingEvent) = DeriveNewState(previousState);
        newState.AddEvent(resultingEvent);
        return newState;
    }
}