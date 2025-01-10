namespace KoalaKit.Primitives.Results;

public sealed class KoalaError
{
    public static readonly KoalaError None = new("GeneralError", string.Empty, ErrorCategory.None);

    public string Code { get; private set; }
    public string Message { get; private set; }
    public ErrorCategory Category { get; }

    private KoalaError(
        string code,
        string message,
        ErrorCategory category)
    {
        Code = code;
        Message = message;
        Category = category;
    }

    public static KoalaError BadRequest(string code)
    {
        return new KoalaError(code, code.ToString(), ErrorCategory.BadRequest);
    }

    public static KoalaError NotFound(string code)
    {
        return new KoalaError(code, code.ToString(), ErrorCategory.NotFound);
    }

    public static KoalaError Unauthorized(string code)
    {
        return new KoalaError(code, code.ToString(), ErrorCategory.Unauthorized);
    }

    public static KoalaError Forbidden(string code)
    {
        return new KoalaError(code, code.ToString(), ErrorCategory.Forbidden);
    }

    public static KoalaError ServerError(string code)
    {
        return new KoalaError(code, code.ToString(), ErrorCategory.ServerError);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode() * 42;
    }

    public void SetMessage(string message)
    {
        Message = message;
    }

    public enum ErrorCategory
    {
        None = 0,
        BadRequest = 1,
        Unauthorized = 2,
        Forbidden = 3,
        NotFound = 4,
        ServerError = 5
    }
}