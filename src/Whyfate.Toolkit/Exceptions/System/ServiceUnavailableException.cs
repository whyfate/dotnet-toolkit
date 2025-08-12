namespace Whyfate.Toolkit.Exceptions.System;

/// <summary>
/// service unavailable exception.
/// </summary>
public class ServiceUnavailableException : SystemException
{
    /// <summary>
    /// .
    /// </summary>
    /// <param name="targetSvc">target service.</param>
    /// <param name="message">message.</param>
    public ServiceUnavailableException(string targetSvc, string message="service unavailable") : base(ErrorCodes.ServiceUnavailable, message)
    {
        TargetSvc = targetSvc;
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="errorCode">error code.</param>
    /// <param name="targetSvc">target service.</param>
    /// <param name="message">message.</param>
    /// <param name="innerException">inner ex.</param>
    public ServiceUnavailableException(int errorCode, string targetSvc, string message, Exception innerException) :
        base(errorCode, message, innerException)
    {
        TargetSvc = targetSvc;
    }

    /// <summary>
    /// target service.
    /// </summary>
    public string TargetSvc { get; init; }
}