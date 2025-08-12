namespace Whyfate.Toolkit.Initializer;

/// <summary>
/// application initial.
/// </summary>
public interface IApplicationInitializer
{
    /// <summary>
    /// priority.
    /// </summary>
    short Priority { get; }

    /// <summary>
    /// initial.
    /// </summary>
    Task InitialAsync();
}