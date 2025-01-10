using System.Text.Json.Serialization;

namespace KoalaKit.Primitives.Results;

public class KoalaResult
{
    [JsonIgnore]
    public bool IsSuccess { get; }
    [JsonIgnore]
    public bool IsFailure => !IsSuccess;
    public bool Succeeded => IsSuccess;
    public KoalaError[] Errors { get; }

    protected internal KoalaResult(bool isSuccess, params KoalaError[] errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }

    public static implicit operator bool(KoalaResult result) => result.IsSuccess;
    public static implicit operator KoalaResult(KoalaError error) => Failure(error);
    public static implicit operator KoalaResult(KoalaError[] errors) => Failure(errors);
    public static KoalaResult Success() => new(true);
    public static KoalaResult<T> Success<T>(T data) => new(data, true);
    public static KoalaResult Failure(params KoalaError[] errors) => new(false, errors);
    public static KoalaResult<T> Failure<T>(params KoalaError[] errors) => new(default, false, errors);
}
public class KoalaResult<T> : KoalaResult
{
    private readonly T? _data;

    protected internal KoalaResult(T? data, bool isSuccess, params KoalaError[] errors) : base(isSuccess, errors)
    {
        _data = data;
    }

    public T? Data => _data;

    public static KoalaResult<T> WithErrors(KoalaError[] errors) => new(default, false, errors);
    public static implicit operator KoalaResult<T>(T data) => Success(data);
    public static implicit operator KoalaResult<T>(KoalaError[] errors) => Failure<T>(errors);
    public static implicit operator KoalaResult<T>(KoalaError error) => Failure<T>(error);
    public static implicit operator bool(KoalaResult<T> result) => result.IsSuccess;
}