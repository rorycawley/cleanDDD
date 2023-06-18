namespace cleanDDD.DomainUnitTests.Customers;

using cleanDDD.Domain.Customers;

public class CustomerTests
{

    [Fact]
    public void Create_Should_CreateCustomerWithValidData()
    {
        // Arrange
        string email = "test@example.com";
        string name = "John Doe";

        // Act
        var customer = Customer.Create(email, name);

        // Assert
        Assert.NotNull(customer);
        Assert.Equal(email, customer.Email);
        Assert.Equal(name, customer.Name);
    }

    [Theory]
    [InlineData(null, "John Doe")]
    [InlineData("test@example.com", null)]
    [InlineData(null, null)]
    [InlineData("", "John Doe")]
    [InlineData("test@example.com", "")]
    [InlineData("", "")]
    [InlineData("invalid-email", "John Doe")]
    public void Create_Should_ThrowArgumentException_WhenDataIsInvalid(string email, string name)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => Customer.Create(email, name));
    }

    [Fact]
    public void UpdateEmail_Should_UpdateCustomerEmail()
    {
        // Arrange
        var customer = Customer.Create("test@example.com", "John Doe");
        string newEmail = "new-email@example.com";

        // Act
        customer.UpdateEmail(newEmail);

        // Assert
        Assert.Equal(newEmail, customer.Email);
    }

    [Fact]
    public void UpdateName_Should_UpdateCustomerName()
    {
        // Arrange
        var customer = Customer.Create("test@example.com", "John Doe");
        string newName = "Jane Doe";

        // Act
        customer.UpdateName(newName);

        // Assert
        Assert.Equal(newName, customer.Name);
    }

    [Fact]
    public void UpdateEmail_Should_ThrowArgumentException_WhenEmailIsInvalid()
    {
        // Arrange
        var customer = Customer.Create("test@example.com", "John Doe");
        string invalidEmail = "invalid-email";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => customer.UpdateEmail(invalidEmail));
    }

    [Fact]
    public void UpdateName_Should_ThrowArgumentException_WhenNameIsEmpty()
    {
        // Arrange
        var customer = Customer.Create("test@example.com", "John Doe");
        string emptyName = "";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => customer.UpdateName(emptyName));
    }
}
// internal class CustomerTests
// {
//     // [ThingUnderTest]_Should_[ExpectdResult]_[Conditions]

//     [Fact]
//     public void CreateCustomer_WithValidData_ShouldCreateCustomer()
//     {
//         // Arrange
//         var email = "