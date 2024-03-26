
using NUnit.Framework;
using Math = TestApp.Fundamentals.Math;

namespace TestApp.UnitTests.Fundamentals
{
    [TestFixture]
    public class MathTests
    {
        [Test]
        public void Add_WhenExecuted_ReturnsSumOfArguments()
        {
            var math = new Math(); // Arrange

            int result = math.Add(1, 2); // Act

            Assert.That(result, Is.EqualTo(3)); // Assert
        }

        [Test]
        public void Subtract_WhenExecuted_ReturnsDifferenceOfArguments()
        {
            var math = new Math(); // Arrange

            var result = math.Subtract(4, 1); // Act

            Assert.That(result, Is.EqualTo(3)); // Assert
        }
    }
}
