namespace Ordering.Domain.Models;

public class OrderItem : Entity<Guid>
{
    internal OrderItem(Guid orderId, Guid orderItemId, int quantity, decimal price)
    {
        OrderId = orderId;
        OrderItemId = orderItemId;
        Quantity = quantity;
        Price = price;
    }

    public Guid OrderId { get; private set; }
    public Guid OrderItemId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
}