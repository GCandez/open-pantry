using OpenPantry.Domain.Common.Exceptions;

namespace OpenPantry.Domain.Common.Entities.Events;

public sealed class EventApplyFailedException(Type eventType, Type entityType, Exception innerException)
    : DomainException($"Failed to apply event {eventType.Name} to entity {entityType.Name}.", innerException);