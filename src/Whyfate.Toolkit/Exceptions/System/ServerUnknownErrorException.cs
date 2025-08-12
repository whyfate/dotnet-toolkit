namespace Whyfate.Toolkit.Exceptions.System;

/// <summary>
/// 未知错误.
/// </summary>
public class ServerUnknownErrorException : SystemException
{
    public ServerUnknownErrorException(int errorCode = ErrorCodes.ServerUnknownError, string message = "Internal Server Error") :
        base(errorCode, message)
    {
    }

    public ServerUnknownErrorException(int errorCode, string message, Exception innerException) : base(errorCode,
        message, innerException)
    {
    }
}