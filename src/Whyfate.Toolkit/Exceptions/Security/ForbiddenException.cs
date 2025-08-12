namespace Whyfate.Toolkit.Exceptions.Security;

/// <summary>
/// forbidden exception.
/// </summary>
public class ForbiddenException : SecurityException
{
    public ForbiddenException(int errorCode = ErrorCodes.Forbidden, string message = "Forbidden") : base(errorCode, message)
    {
    }

    public ForbiddenException(int errorCode, string message, Exception innerException) : base(errorCode, message,
        innerException)
    {
    }
}