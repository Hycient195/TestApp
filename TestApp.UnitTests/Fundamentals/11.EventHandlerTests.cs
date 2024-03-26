using NUnit.Framework;
using TestApp.Fundamentals;

namespace TestApp.UnitTests.Fundamentals
{
    [TestFixture]
    public class EventHandlerTests
    {
        [Test]
        public void Log_ValidError_RaiseLoggedEvent()
        {
            var errorLogger = new ErrorLogger(); // Arrange
            var id = Guid.Empty; 

            errorLogger.ErrorLogged += (source, eventArguments) => { id = eventArguments; }; // Act
            errorLogger.Log("error message");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty)); // Assert
        }
    }
}

/* In the testing of the event handler above, first an instance of the class the raises the event is 
    created, a property which the event when invoked, would update is also created. After that
    a function, or lambda expression is then attached to the event. This is the method or lambda
    expression to be called when the event is triggered. Inside this method is an expression to
    assign the argument received by the event, to the empty variable created above.

    After that the event is then triggered bu calling the "Log" method

    After all of these, an assertion is then performed to ascertain that the empty value we created
    is no longer empty, and now contains the value assigned to it from the event handler.
*/