using Whyfate.Toolkit.Domain;

namespace Whyfate.Toolkit.Tests.Domain;

public class OrderDomainEvent: DomainEvent
{
    public string OrderId { get; init; }
    public OrderDomainEvent(string orderId, DateTime occurTime)
        : base(orderId, occurTime)
    {
        OrderId = orderId;
    }
}