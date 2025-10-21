namespace OpenPantry.Domain.Common.Entities.Events;

public interface IEntityEvent<TEntity> where TEntity : Entity<TEntity>
{
    Guid Id { get; init; }
    DateTimeOffset Timestamp { get; init; }
    public TEntity DeriveNewState(TEntity? previousState);
}