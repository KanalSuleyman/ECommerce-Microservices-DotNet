namespace Ordering.Application.Dtos;

public record OrderDto(
    Guid OrderId,
    Guid CustomerId,
    string OrderName,
    AddressDto ShippingAddress,
    AddressDto BillingAddress,
    PaymentDto Payment,
    List<OrderItemDto> OrderItems);