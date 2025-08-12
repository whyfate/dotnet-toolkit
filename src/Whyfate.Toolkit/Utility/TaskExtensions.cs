namespace Whyfate.Toolkit.Utility;

public static class TaskExtensions
{
    /// <summary>
    /// sync wait task result.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="task"></param>
    /// <returns></returns>
    public static T WaitResultExt<T>(this Task<T> task)
    {
        return task.ConfigureAwait(false).GetAwaiter().GetResult();
    }

    /// <summary>
    /// sync wait task.
    /// </summary>
    /// <param name="task"></param>
    /// <returns></returns>
    public static void WaitExt(this Task task)
    {
        task.ConfigureAwait(false).GetAwaiter().GetResult();
    }
}