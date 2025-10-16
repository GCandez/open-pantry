namespace OpenPantry.Domain.Common.Results;

public sealed class UnitResult<TError>
{
    public readonly bool IsSuccess;
    public bool IsFailure => !IsSuccess;
    private readonly TError? _error;

    public TError Error => IsFailure ? _error! : throw new InvalidOperationException("Cannot get error of successful result.");

    private UnitResult(bool isSuccess, TError? error)
    {
        IsSuccess = isSuccess;
        _error = error;
    }

    private static UnitResult<TError> Success()
    {
        return new(true, default);
    }

    private static UnitResult<TError> Failure(TError error)
    {
        return new(false, error);
    }

    public static implicit operator UnitResult<TError>(TError error)
    {
        return Failure(error);
    }

    public static implicit operator UnitResult<TError>(UnitResult _)
    {
        return Success();
    }
}

public sealed class UnitResult
{
    public static readonly UnitResult Success = new();
}