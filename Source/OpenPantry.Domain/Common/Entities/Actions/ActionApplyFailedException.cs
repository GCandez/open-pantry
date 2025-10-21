using OpenPantry.Domain.Common.Exceptions;

namespace OpenPantry.Domain.Common.Entities.Actions;

public sealed class ActionApplyFailedException(Type actionType, Type entityType, Exception innerException)
    : DomainException($"Failed to apply action {actionType.Name} to entity {entityType.Name}.", innerException);