using cleanDDD.Domain.Common;
using cleanDDD.Domain.Products;
using Xunit;

namespace cleanDDD.DomainUnitTests.Orders;

public class OrderTests
{
    // [Theory]
    // [ClassData(typeof(OrderCreateTestData))]
    // public void Create_Should_RaiseDomainEvent(CustomerId customerId)
    // {
    //     // Act
    //     var order = Order.Create(customerId);

    //     // Assert
    //     Assert.NotEmpty(order.GetDomainEvents.OfType<OrderCreatedDomainEvent>());
    // }
}

// strong typing and parameterized tests
// public class OrderCreateTestData : TheoryData<CustomerId>
// {
//     public OrderCreateTestData()
//     {
//         Add(new CustomerId(Guid.NewGuid()));
//     }
// }