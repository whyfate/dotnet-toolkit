namespace Whyfate.Toolkit.Exceptions;

/// <summary>
/// system exception.
/// </summary>
public abstract class SystemException : BaseException
{
    protected SystemException(int errorCode, string message) : base(errorCode, message)
    {
    }

    protected SystemException(int errorCode, string message, Exception innerException) : base(errorCode, message,
        innerException)
    {
    }
}