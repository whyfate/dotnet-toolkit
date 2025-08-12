namespace Whyfate.Toolkit.Application;

/// <summary>
/// result dto.
/// </summary>
/// <typeparam name="T">data.</typeparam>
public class ResultDto<T> : ResultDto
{
    /// <summary>
    /// data.
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// succeed.
    /// </summary>
    /// <returns></returns>
    public static ResultDto<T> Succeed(T data)
    {
        return new ResultDto<T>
        {
            IsSuccess = true,
            Data = data
        };
    }

    /// <summary>
    /// failed.
    /// </summary>
    /// <param name="errorCode"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public new static ResultDto<T> Failed(string errorCode, string message)
    {
        return new ResultDto<T>
        {
            ErrorCode = errorCode,
            Message = message,
        };
    }
}