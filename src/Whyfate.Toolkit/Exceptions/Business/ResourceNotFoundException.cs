namespace Whyfate.Toolkit.Exceptions.Business;

/// <summary>
/// resource not found exception.
/// </summary>
public class ResourceNotFoundException : BusinessException
{
    public ResourceNotFoundException(int errorCode = ErrorCodes.ResourceNotFound, string message = "资源不存在.") : base(
        errorCode, message)
    {
    }

    public ResourceNotFoundException(int errorCode, string message, Exception innerException) : base(errorCode,
        message, innerException)
    {
    }
}