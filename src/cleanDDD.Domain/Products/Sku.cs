namespace cleanDDD.Domain.Products;

public record Sku
{
    // default length
    public const int DefaultLength = 15;

    private Sku(string value) => Value = value;

    public string Value { get; init; }

    public static Sku Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Sku cannot be empty", nameof(value));
        }

        if (value.Length != DefaultLength)
        {
            throw new ArgumentException($"Sku must be {DefaultLength} characters", nameof(value));
        }

        return new Sku(value);
    }
}