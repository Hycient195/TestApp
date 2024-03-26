/* Interraction Test */

using Moq;
using NUnit.Framework;
using TestApp.Mocking;

namespace TestApp.UnitTests.Mocking
{
    [TestFixture]
    public class OrderServiceTests
    {
        [Test]
        public void PlaceOrder_WhenExecuted_StoresTheOrder()
        {
            // Arrange
            var storage = new Mock<IStorage>();
            var orderService = new OrderService(storage.Object);

            var order = new Order();

            orderService.PlaceOrder(order);

            storage.Verify((st) => st.Store(order));
        }
    }
}

/* This exercise tests the interraction between two classes or objects.
 
    In the example above, the "OrderService" class makes use of a "Storage" class to store
    orders any time an order is placed using the "PlaceOrder()" method. The interraction test
    performed above ensures that the "Store()" method in the in the storage class used in the
    order service is called any time an order is placed.

    To acheive this, a Mock of the storage class is created using its guiding interface "IStorage".

    A new OrderService is created, and the mock storage is passed to the constructor of the 
        order service

    A new order is then created, and then, used to place an order using the "PlaceOrder()" method

    Since the "PlaceOrder" method, under the hood is meant to call the "Store()" method in the
    storage, the storage mock created is now "Verified" (tested) that when the "PlaceOrder" method
    was called, the "Store()" method was also executed under the hood, with the correct input
    argument.


    CAVEAT
    It it good to note that even though mocks can be used for tests in classes that do not interract
    with other classes, it's best to only use them when the test is only for "interraction" between
    two objects or classes, to verify if one class calls the method in another class correctly.

    In cases where single value assertions are to be made, it's not advisable to use mocks, as they
    cause the needless creation of unnecessary interfaces for the class depended on, bloat up the
    test codebase and make the test less readable.
 */