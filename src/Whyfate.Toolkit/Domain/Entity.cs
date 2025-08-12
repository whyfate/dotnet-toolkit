namespace Whyfate.Toolkit.Domain;

/// <summary>
/// base entity.
/// </summary>
public abstract class Entity<TId> : IEntity<TId>
{
    /// <summary>
    /// id.
    /// </summary>
    public TId Id { get; set; }
}