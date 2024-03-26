using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Math = TestApp.Fundamentals.Math;

namespace TestApp.UnitTests.Fundamentals
{
    [TestFixture]
    public class CollectionTests
    {
        [Test]
        public void GetOddNumbersWithinLimit_WhenExecuted_ReturnsAllOddNumbersWithinLimit()
        {
            var math = new Math();

            var result = math.GetOddNumbersWithinLimit(7);

            Assert.That(result, Is.Not.Empty);

            // Specific tests
            Assert.That(result, Does.Contain(1));
            Assert.That(result, Does.Contain(3));
            Assert.That(result, Does.Contain(5));
            Assert.That(result, Does.Contain(7));


            // A more concise way to perform the above.
            Assert.That(result, Is.EquivalentTo(new List<int>() { 1, 3, 5, 7 })); // Checks for sameness in values contained in result irrespective of type

            Assert.That(result, Is.EquivalentTo(new int[] { 1, 3, 5, 7 })); // Checks for sameness in values contained in result irrespective of their types

            Assert.That(result, Is.Ordered); // To assert if the result returned are in ascending or descending order
            Assert.That(result, Is.Unique); // To assert that the no value appears twice in the IEnumerable result
        }
    }
}
