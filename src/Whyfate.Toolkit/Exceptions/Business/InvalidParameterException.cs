namespace Whyfate.Toolkit.Exceptions.Business;

/// <summary>
/// invalid parameter exception.
/// </summary>
public class InvalidParameterException : BusinessException
{
    public InvalidParameterException(string message) : base(ErrorCodes.InvalidParameter, message)
    {
    }

    public InvalidParameterException(int errorCode, string message) : base(errorCode, message)
    {
    }

    public InvalidParameterException(int errorCode, string message, Exception innerException) : base(errorCode,
        message, innerException)
    {
    }
}