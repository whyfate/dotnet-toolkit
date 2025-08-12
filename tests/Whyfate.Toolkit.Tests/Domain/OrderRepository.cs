using Whyfate.Toolkit.Domain;

namespace Whyfate.Toolkit.Tests.Domain;

public class OrderRepository : IRepository<Order, string>
{
    private readonly List<Order> _container = new List<Order>();
    
    public IUnitOfWork UnitOfWork => throw new NotImplementedException();

    public void Add(Order entity)
    {
        _container.Add(entity);
    }

    public void Remove(Order t)
    {
        _container.Remove(t);
    }

    public Task<Order?> GetAsync(string id)
    {
        return Task.FromResult(_container.FirstOrDefault(c => c.Id == id));
    }
}