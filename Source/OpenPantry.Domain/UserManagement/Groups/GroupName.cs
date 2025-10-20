using OpenPantry.Domain.Common.Results;
using OpenPantry.Domain.Common.ValueObjects;

namespace OpenPantry.Domain.UserManagement.Groups;

public readonly struct GroupName : IValueObject<GroupName>
{
    public readonly string Value;

    private GroupName(string value)
    {
        Value = value;
    }

    public static Result<GroupName, ValidationError> Create(string value)
    {
        value = value.Trim();

        return value.Length switch
        {
            < 3 => ValidationError.TooShort,
            > 30 => ValidationError.TooLong,
            _ => new GroupName(value)
        };
    }

    public static GroupName From(string value)
    {
        var result = Create(value);

        return result.IsFailure
            ? throw new ValueObjectValidationException<GroupName, ValidationError>(result.Error)
            : result.Value;
    }

    public enum ValidationError
    {
        TooShort,
        TooLong
    }

    public bool Equals(GroupName other)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(GroupName left, GroupName right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(GroupName left, GroupName right)
    {
        throw new NotImplementedException();
    }
}