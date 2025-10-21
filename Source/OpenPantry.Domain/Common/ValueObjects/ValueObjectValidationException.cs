using OpenPantry.Domain.Common.Exceptions;

namespace OpenPantry.Domain.Common.ValueObjects;

public sealed class ValueObjectValidationException<TValueObject, TError>(TError error) : DomainException(GetMessage(error))
    where TValueObject : IValueObject<TValueObject>
    where TError : Enum
{
    public TError Error { get; } = error;

    private static string GetMessage(TError error)
    {
        return $"Invalid value object of type {typeof(TValueObject).Name}: {error}";
    }
}