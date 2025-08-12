namespace Whyfate.Toolkit.Domain;

/// <summary>
/// unit of work.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// SaveChangesAsync.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// begin a transaction.
    /// </summary>
    /// <param name="func"></param>
    /// <returns></returns>
    Task<bool> TransactionAsync(Func<Task> func);
}