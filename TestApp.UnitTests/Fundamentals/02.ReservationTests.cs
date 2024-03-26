
using NUnit.Framework;
using TestApp.Fundamentals;

namespace TestApp.UnitTests.Fundamentals;

[TestFixture]
public class ReservationTests
{
    [Test]
    //public void MethodUnderTest_Scenario_ExpectedBehaviour()
    public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
    {
        // Each test method is divided in to 3 parts, popularly calles the 3 A's which are the
        // Arrange, Act, Assert

        var reservation = new Reservation();

        var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

        Assert.That(result, Is.True);
    }

    [Test]
    public void CanBeCancelledBy_UserIsReserver_ReturnsTrue()
    {
        var newUser = new User();
        var reservation = new Reservation { MadeBy = newUser };

        var result = reservation.CanBeCancelledBy(newUser);


        Assert.That(result, Is.True);
    }

    [Test]
    public void CanBeCancelledBy_UserIsNotReserver_ReturnsFalse()
    {
        var reservation = new Reservation { MadeBy = new User { IsAdmin = false } }; // Arrange

        var result = reservation.CanBeCancelledBy(new User { IsAdmin = false }); // Act

        Assert.That(result, Is.False); // Assert
    }
}





/* Tests Written With the MS Test Framework */

/*[TestClass]
public class ReservationTests
{
    [TestMethod]
    //public void MethodUnderTest_Scenario_ExpectedBehaviour()
    public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
    {
        // Each test method is divided in to 3 parts, popularly calles the 3 A's which are the
        // Arrange, Act, Assert

        var reservation = new Reservation();

        var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void CanBeCancelledBy_UserIsReserver_ReturnsTrue()
    {
        var newUser = new User();
        var reservation = new Reservation { MadeBy = newUser };
        
        var result = reservation.CanBeCancelledBy(newUser);
        

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void CanBeCancelledBy_UserIsNotReserver_ReturnsFalse()
    {
        var reservation = new Reservation { MadeBy = new User { IsAdmin = false} }; // Arrange

        var result = reservation.CanBeCancelledBy(new User { IsAdmin = false }); // Act

        Assert.IsFalse(result); // Assert
    }
}*/
