using OpenPantry.Domain.Common.Results;
using OpenPantry.Domain.Common.ValueObjects;

namespace OpenPantry.Domain.UserManagement.Users.ValueObjects;

public readonly struct UserName : IValueObject<UserName>
{
    public bool Equals(UserName other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is UserName other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(UserName left, UserName right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(UserName left, UserName right)
    {
        return !left.Equals(right);
    }

    public readonly string Value;

    private UserName(string value)
    {
        Value = value;
    }

    public enum ValidationError
    {
        TooShort,
        TooLong
    }

    public static Result<UserName, ValidationError> Create(string value)
    {
        value = value.Trim();

        return value.Length switch
        {
            < 3 => ValidationError.TooShort,
            > 20 => ValidationError.TooLong,
            _ => new UserName(value)
        };
    }

    public static UserName From(string value)
    {
        var result = Create(value);

        return result.IsFailure
            ? throw new ValueObjectValidationException<UserName, ValidationError>(result.Error)
            : result.Value;
    }
}