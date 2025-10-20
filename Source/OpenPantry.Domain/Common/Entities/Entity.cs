namespace OpenPantry.Domain.Common.Entities;

public abstract class Entity<TEntity> : IEquatable<TEntity>
    where TEntity : Entity<TEntity>
{
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

    private bool Equals(Entity<TEntity> other)
    {
        return Id.Equals(other.Id);
    }

    public bool Equals(TEntity? other)
    {
        return other is not null && Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TEntity> other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Entity<TEntity>? left, Entity<TEntity>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TEntity>? left, Entity<TEntity>? right)
    {
        return !Equals(left, right);
    }
}