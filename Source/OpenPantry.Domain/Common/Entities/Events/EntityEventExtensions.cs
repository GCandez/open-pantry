using System.Diagnostics.CodeAnalysis;

namespace OpenPantry.Domain.Common.Entities.Events;

public static class EntityEventExtensions
{
    public static void ThrowIfNull<TEntity, TEvent>([NotNull] this TEntity? entity, TEvent @event)
        where TEntity : Entity<TEntity>
        where TEvent : IEntityEvent<TEntity>
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity), $"Cannot apply event {@event.GetType().Name} to a null entity of type {typeof(TEntity).Name}.");
    }
}