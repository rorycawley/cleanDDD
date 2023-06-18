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
public class Order
    {
private readonly HashSet<LineItem> _lineItems = new();
        public IReadOnlyCollection<LineItem> LineItems => _lineItems;

        public Guid Id { get; } = Guid.NewGuid();
        public Guid CustomerId { get; }

        private Order(Guid customerId)
        {
            if (customerId == Guid.Empty)
            {
                throw new ArgumentException("Customer Id must not be empty.", nameof(customerId));
            }

            CustomerId = customerId;
        }

        public static Order Create(Guid customerId)
        {
            return new Order(customerId);
        }

        /// <summary>
        /// Adds a new line item to the order.
        /// </summary>
        public void AddLineItem(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            if (_lineItems.Any() && _lineItems.First().Price.Currency != product.Price.Currency)
            {
                throw new InvalidOperationException("All line items must have the same currency.");
            }
            var lineItem = new LineItem(Id, product.Id, product.Price);
            _lineItems.Add(lineItem);
        }

        /// <summary>
        /// Removes a line item from the order.
        /// </summary>
        public void RemoveLineItem(Guid lineItemId)
        {
            var lineItem = FindLineItem(lineItemId);
            _lineItems.Remove(lineItem);
        }

        /// <summary>
        /// Updates the price of a line item.
        /// </summary>
        public void UpdateLineItem(Guid lineItemId, Money newPrice)
        {
            var lineItem = FindLineItem(lineItemId);
            lineItem.SetPrice(newPrice);
        }

        private LineItem FindLineItem(Guid lineItemId)
        {
            var lineItem = _lineItems.SingleOrDefault(li => li.Id == lineItemId);
            return lineItem ?? throw new ArgumentException("Line item does not exist.", nameof(lineItemId));
        }

        /// <summary>
        /// Calculates the total amount of the order.
        /// </summary>
        public Money GetTotalAmount()
        {
            var currency = _lineItems.FirstOrDefault()?.Price.Currency ?? "Unknown";
            var totalAmount = _lineItems.Sum(lineItem => lineItem.Price.Amount);
            return new Money(currency, totalAmount);
        }
    }