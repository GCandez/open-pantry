namespace OpenPantry.Domain.Common.Results;

public sealed class Result<TValue, TError>
{
    private readonly TError? _error;
    private readonly TValue? _value;
    public readonly bool IsSuccess;

    private Result(bool isSuccess, TValue? value, TError? error)
    {
        IsSuccess = isSuccess;
        _value = value;
        _error = error;
    }

    public bool IsFailure => !IsSuccess;

    public TValue Value => IsSuccess ? _value! : throw new InvalidOperationException("Cannot get value of failed result.");
    public TError Error => !IsSuccess ? _error! : throw new InvalidOperationException("Cannot get error of successful result.");

    private static Result<TValue, TError> Success(TValue value)
    {
        return new(true, value, default);
    }

    private static Result<TValue, TError> Failure(TError error)
    {
        return new(false, default, error);
    }

    public static implicit operator Result<TValue, TError>(TValue value)
    {
        return Success(value);
    }

    public static implicit operator Result<TValue, TError>(TError error)
    {
        return Failure(error);
    }
}