namespace Whyfate.Toolkit.Exceptions;

/// <summary>
/// base exception.
/// </summary>
public abstract class BaseException : Exception
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="errorCode"></param>
    /// <param name="message"></param>
    protected BaseException(int errorCode, string message)
        : base(message)
    {
        ErrorCode = errorCode;
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="errorCode"></param>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    protected BaseException(int errorCode, string message, Exception innerException)
        : base(message, innerException)
    {
        ErrorCode = errorCode;
    }

    /// <summary>
    /// error code.
    /// </summary>
    public int ErrorCode { get; init; }
}