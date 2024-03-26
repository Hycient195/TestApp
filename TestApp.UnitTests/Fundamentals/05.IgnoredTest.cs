using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Math = TestApp.Fundamentals.Math;

namespace TestApp.UnitTests.Fundamentals
{
    [TestFixture]
    public class IgnoredTests
    {
        [Test]
        [Ignore("Intentionally ignored for sample")]
        public void Adds_WhenExecuted_ReturnsSumOfArguments()
        {
            var math = new Math(); // Arrange

            int result = math.Add(1, 2); // Act

            Assert.That(result, Is.EqualTo(3)); // Assert
        }
    }
}
/* This exercise highlights how to ignore tests using the [Ignore()] decorator.
    The decorator takes a string as an argument, stating why the test was ignored.

    Ignoring a test is more beneficial than commenting it out, as it allows you to cut
    The whole test clutter, without you forgetting about the test as is often seen in
    commented out tests. 
*/