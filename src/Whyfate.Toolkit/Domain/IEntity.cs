namespace Whyfate.Toolkit.Domain;

/// <summary>
/// IEntity.
/// </summary>
/// <typeparam name="TId"></typeparam>
public interface IEntity<TId>
{
    /// <summary>
    /// id.
    /// </summary>
    TId Id { get; set; }
}