using System.Text.Json.Serialization;

namespace Whyfate.Toolkit.Domain;

/// <summary>
/// domain event.
/// </summary>
public abstract class DomainEvent
{
    /// <summary>
    /// .
    /// </summary>
    /// <param name="identifier">identifier.</param>
    /// <param name="createTime">create time.</param>
    public DomainEvent(string identifier, DateTime createTime)
        : this(Guid.CreateVersion7().ToString("N"), identifier, createTime)
    {
    }

    /// <summary>
    /// 构造.
    /// </summary>
    /// <param name="id">id.</param>
    /// <param name="identifier">identifier.</param>
    /// <param name="createTime">create time.</param>
    public DomainEvent(string id, string identifier, DateTime createTime)
    {
        Id = id;
        Identifier = identifier;
        CreateTime = createTime;
    }

    /// <summary>
    /// id.
    /// </summary>
    [JsonInclude]
    public string Id { get; private set; }

    /// <summary>
    /// identifier.
    /// </summary>
    [JsonInclude]
    public string Identifier { get; private set; }

    /// <summary>
    /// create time.
    /// </summary>
    [JsonInclude]
    public DateTime CreateTime { get; private set; }

    /// <summary>
    /// concurrent sort.
    /// </summary>
    [JsonInclude]
    public int ConcurrentSort { get; private set; }

    /// <summary>
    /// set sort.
    /// </summary>
    /// <param name="sort"></param>
    public void SetSort(int sort)
    {
        this.ConcurrentSort = sort;
    }
}