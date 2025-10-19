namespace OpenPantry.Domain.Common.ValueObjects;

public interface IValueObject<T> : IEquatable<T> where T : IValueObject<T>
{
    public static abstract bool operator ==(T left, T right);
    public static abstract bool operator !=(T left, T right);
}