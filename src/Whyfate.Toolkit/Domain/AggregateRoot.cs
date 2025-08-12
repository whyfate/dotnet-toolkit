namespace Whyfate.Toolkit.Domain;

/// <summary>
/// aggregate root.
/// </summary>
public abstract class AggregateRoot
{
    private List<DomainEvent> _domainEvents = new();
    private int _sort = 1;

    /// <summary>
    /// domain event.
    /// </summary>
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// add event.
    /// </summary>
    /// <param name="eventItem"></param>
    public void AddDomainEvent(DomainEvent eventItem)
    {
        eventItem.SetSort(_sort);
        _sort += 1;
        _domainEvents.Add(eventItem);
    }

    /// <summary>
    /// clear events.
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}

/// <summary>
/// aggregate root.
/// </summary>
/// <typeparam name="TId"></typeparam>
public abstract class AggregateRoot<TId> : AggregateRoot, IEntity<TId>
{
    /// <summary>
    /// id.
    /// </summary>
    public TId Id { get; set; }
}