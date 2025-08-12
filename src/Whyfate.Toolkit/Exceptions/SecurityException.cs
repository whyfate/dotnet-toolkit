namespace Whyfate.Toolkit.Exceptions;

/// <summary>
/// security exception.
/// </summary>
public abstract class SecurityException : BaseException
{
    protected SecurityException(int errorCode, string message) : base(errorCode, message)
    {
    }

    protected SecurityException(int errorCode, string message, Exception innerException) : base(errorCode, message,
        innerException)
    {
    }
}