namespace OpenPantry.Domain.Common.Entities;

public interface IEntityEvent<TEntity> where TEntity : Entity<TEntity>
{
    Guid Id { get; init; }
    DateTimeOffset Timestamp { get; init; }
    public TEntity Apply(TEntity? previousState);
}