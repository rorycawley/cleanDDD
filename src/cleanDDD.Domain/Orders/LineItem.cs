using cleanDDD.Domain.Common;
using cleanDDD.Domain.Products;

namespace cleanDDD.Domain.Orders;

public class LineItem
{
    public Guid Id { get; } = Guid.NewGuid();
    public Guid OrderId { get; }
    public Guid ProductId { get; }
    public Money Price { get; private set; }

    internal LineItem(Guid orderId, Guid productId, Money price)
    {
        OrderId = orderId;
        ProductId = productId;
        Price = price ?? throw new ArgumentNullException(nameof(price));
    }

    internal void SetPrice(Money newPrice)
    {
        Price = newPrice ?? throw new ArgumentNullException(nameof(newPrice));
    }
}