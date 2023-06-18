using cleanDDD.Domain.Products;
using Xunit;

namespace cleanDDD.DomainUnitTests.Products;

public class CustomerTests
{

    // [ThingUnderTest]_Should_[ExpectdResult]_[Conditions]

    [Fact]
    public void Create_Should_ReturnSkuInstance_WhenValueIsValid()
    {
        // Arrange
        string value = "ABCDE12345FGHIJ";

        // Act
        var sku = Sku.Create(value);

        // Assert
        Assert.NotNull(sku);
        Assert.Equal(value, sku.Value);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("ABCDE")]
    [InlineData("ABCDE12345FGHIJK")]
    public void Create_Should_ThrowArgumentException_WhenValueIsInvalid(string? value)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => Sku.Create(value ?? string.Empty));
    }

    // public static IEnumerable<object[]> InvalideSkuLengthDataMethod() => new List<object[]>
    // {
    //     new object[] { null },
    //     new object[] { "" },
    //     new object[] { " " },
    //     new object[] { "ABCDE" },
    //     new object[] { "ABCDE12345FGHIJK" }
    // };

    // [Theory]
    // [MemberData(nameof(InvalideSkuLengthDataMethod))]
    // public void Create_Should_ThrowArgumentException_WhenValueIsInvalid2(string? value)
    // {
    //     // Act & Assert
    //     Assert.Throws<ArgumentException>(() => Sku.Create(value ?? string.Empty));
    // }
}