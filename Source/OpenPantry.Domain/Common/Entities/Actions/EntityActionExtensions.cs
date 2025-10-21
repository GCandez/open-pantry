using System.Diagnostics.CodeAnalysis;

namespace OpenPantry.Domain.Common.Entities.Actions;

public static class EntityActionExtensions
{
    public static void ThrowIfNull<TEntity>([NotNull] this TEntity? entity, IEntityAction<TEntity> action) where TEntity : Entity<TEntity>
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity), $"Cannot apply action {action.GetType().Name} to a null entity of type {typeof(TEntity).Name}.");
    }
}