namespace Whyfate.Toolkit.Exceptions;

/// <summary>
/// business exception.
/// </summary>
public abstract class BusinessException : BaseException
{
    protected BusinessException(int errorCode, string message) : base(errorCode, message)
    {
    }

    protected BusinessException(int errorCode, string message, Exception innerException) : base(errorCode, message,
        innerException)
    {
    }
}