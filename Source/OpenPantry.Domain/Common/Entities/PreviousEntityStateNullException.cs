namespace OpenPantry.Domain.Common.Entities;

public sealed class PreviousEntityStateNullException<TAction>() : Exception($"Cannot apply {typeof(TAction).Name} to a null entity");