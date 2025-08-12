namespace Whyfate.Toolkit.Exceptions;

/// <summary>
/// error codes.
/// </summary>
public abstract class ErrorCodes
{
    /// <summary>
    /// invalid parameter.
    /// </summary>
    public const int InvalidParameter = 40000;
    
    /// <summary>
    /// unauthorized.
    /// </summary>
    public const int Unauthorized = 40001;
    
    /// <summary>
    /// forbidden.
    /// </summary>
    public const int Forbidden = 40003;
    
    /// <summary>
    /// resource not found.
    /// </summary>
    public const int ResourceNotFound = 40004;
    
    /// <summary>
    /// service unavailable.
    /// </summary>
    public const int ServiceUnavailable = 50003;
    
    /// <summary>
    /// server unknown error.
    /// </summary>
    public const int ServerUnknownError = 50000;
}