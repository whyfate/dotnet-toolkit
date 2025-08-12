namespace Whyfate.Toolkit.Domain;

public interface IRepository<T, in TId> where T : AggregateRoot<TId>
{
    /// <summary>
    /// uow.
    /// </summary>
    IUnitOfWork UnitOfWork { get; }

    /// <summary>
    /// add entity.
    /// </summary>
    /// <param name="entity"></param>
    void Add(T entity);

    /// <summary>
    /// remove entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    void Remove(T entity);

    /// <summary>
    /// get entity.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T?> GetAsync(TId id);
}