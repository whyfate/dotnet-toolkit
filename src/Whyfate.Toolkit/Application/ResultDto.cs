namespace Whyfate.Toolkit.Application;

/// <summary>
/// result dto.
/// </summary>
public class ResultDto
{
    /// <summary>
    /// is success.
    /// </summary>
    public bool IsSuccess { get; init; }

    /// <summary>
    /// error code.
    /// </summary>
    public string? ErrorCode { get; init; }
    
    /// <summary>
    /// message.
    /// </summary>
    public string? Message { get; init; }

    /// <summary>
    /// succeed.
    /// </summary>
    /// <returns></returns>
    public static ResultDto Succeed()
    {
        return new ResultDto
        {
            IsSuccess = true
        };
    }

    /// <summary>
    /// failed.
    /// </summary>
    /// <param name="errorCode"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static ResultDto Failed(string errorCode, string message)
    {
        return new ResultDto()
        {
            ErrorCode = errorCode,
            Message = message,
        };
    }
}