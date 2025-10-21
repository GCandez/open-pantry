using OpenPantry.Domain.Common.Entities.Events;

namespace OpenPantry.Domain.Common.Entities;

public abstract record Entity<TEntity>
    where TEntity : Entity<TEntity>
{
    public virtual bool Equals(Entity<TEntity>? other)
    {
        return other is not null && Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    private readonly Queue<IEntityEvent<TEntity>> _uncommittedEvents = [];

    public required Guid Id { get; init; }
    public required DateTimeOffset CreatedAt { get; init; }
    public required DateTimeOffset UpdatedAt { get; init; }

    internal void AddEvent(IEntityEvent<TEntity> @event)
    {
        _uncommittedEvents.Enqueue(@event);
    }

    public IReadOnlyCollection<IEntityEvent<TEntity>> GetUncommittedEvents()
    {
        return _uncommittedEvents;
    }

    public void ClearUncommittedEvents()
    {
        _uncommittedEvents.Clear();
    }
}