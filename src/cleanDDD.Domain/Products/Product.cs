using cleanDDD.Domain.Common;

namespace cleanDDD.Domain.Products;



public class Product
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public Money Price { get; private set; }

    public Sku Sku { get; private set; }

    /// <summary>
    /// Factory method to create a new product.
    /// </summary>
    /// <param name="name">The name of the product.</param>
    /// <param name="price">The price of the product.</param>
    /// <param name="sku">The SKU of the product.</param>
    /// <returns>A new Product instance.</returns>
    public static Product Create(string name, Money price, Sku sku)
    {
        return new Product(name, price, sku);
    }

    private Product(string name, Money price, Sku sku)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Product name cannot be empty", nameof(name));
        }

        Id = Guid.NewGuid();
        Name = name;
        Price = price ?? throw new ArgumentNullException(nameof(price), "Product price cannot be null");
        Sku = sku ?? throw new ArgumentNullException(nameof(sku), "Product SKU cannot be null");
    }


    /// <summary>
    /// Updates the price of the product.
    /// </summary>
    /// <param name="newPrice">The new price.</param>
    public void UpdatePrice(Money newPrice)
    {
        if (newPrice == null)
        {
            throw new ArgumentNullException(nameof(newPrice), "New price cannot be null");
        }

        if (newPrice.Amount < 0)
        {
            throw new ArgumentException("Price must be greater than or equal to 0.", nameof(newPrice));
        }

        Price = newPrice;
    }
}