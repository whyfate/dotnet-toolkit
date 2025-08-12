namespace Whyfate.Toolkit.Exceptions.Security;

/// <summary>
/// unauthorized exception.
/// </summary>
public class UnauthorizedException : SecurityException
{
    public UnauthorizedException(int errorCode = ErrorCodes.Unauthorized, string message = "Unauthorized") : base(errorCode,
        message)
    {
    }

    public UnauthorizedException(int errorCode, string message, Exception innerException) : base(errorCode, message,
        innerException)
    {
    }
}