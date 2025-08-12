using Whyfate.Toolkit.Domain;

namespace Whyfate.Toolkit.Tests.Domain;

/// <summary>
/// order.
/// </summary>
public class Order : AggregateRoot<string>
{
    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
    public Address Address { get; set; }
    
    public void AddItem(string productId,string productName, int quantity,decimal price)
    {
        var item = new OrderItem(productId, productName, quantity, price);
        _items.Add(item);
    }

    public void Paid()
    {
        AddDomainEvent(new OrderDomainEvent(Id, DateTime.Now));
    }

    public void Ship()
    {
        AddDomainEvent(new OrderDomainEvent(Id, DateTime.Now));
    }
    
}

/// <summary>
/// order item.
/// </summary>
public class OrderItem : Entity<string>
{
    public OrderItem()
    {
    }

    public OrderItem(string productId, string productName,int quantity,decimal unitPrice)
    {
        Id = Guid.NewGuid().ToString("N");
        ProductId = productId;
        ProductName = productName;
        Quantity = quantity;
        UnitPrice = unitPrice;    
    }
    
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

/// <summary>
/// address.
/// </summary>
public record Address : ValueObject
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }

    public Address()
    {
    }

    public Address(string street, string city, string state, string country, string zipcode)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipcode;
    }
}