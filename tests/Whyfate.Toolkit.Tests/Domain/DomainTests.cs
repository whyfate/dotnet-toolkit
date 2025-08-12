namespace Whyfate.Toolkit.Tests.Domain;

public class DomainTests
{
    [Fact]
    public void TestAggregateRoot()
    {
        var address = new Address("1", "1", "1", "1", "1");
        var order = new Order
        {
            Id = "1",
            Address = address,
        };
        
        order.AddItem("1","test",1,1);

        Assert.NotNull(order);

        order.Paid();

        Assert.Single(order.DomainEvents);
        Assert.Single(order.Items);
    }

    [Fact]
    public void TestAggregateRootClearEvents()
    {
        var address = new Address("1", "1", "1", "1", "1");
        var order = new Order
        {
            Id = "1",
            Address = address,
        };
        
        order.AddItem("1","test",1,1);

        Assert.NotNull(order);

        order.Paid();

        Assert.Single(order.DomainEvents);
        Assert.Single(order.Items);
        
        order.ClearDomainEvents();
        Assert.Empty(order.DomainEvents);
    }
    
    [Fact]
    public void TestValueObject()
    {
        var address1 = new Address("1", "1", "1", "1", "1");
        var address2 = new Address("1", "1", "1", "1", "1");
        Assert.Equal(address1, address2);
    }

    [Fact]
    public void TestConcurrentEvent()
    {
        var address = new Address("1", "1", "1", "1", "1");
        var order = new Order
        {
            Id = "1",
            Address = address,
        };
        order.AddItem("1","test",1,1);

        Assert.NotNull(order);

        order.Paid();
        order.Ship();

        Assert.Equal(2, order.DomainEvents.Count);
        Assert.Equal(1, order.DomainEvents.First().ConcurrentSort);
        Assert.Equal(2, order.DomainEvents.Last().ConcurrentSort);
    }
}