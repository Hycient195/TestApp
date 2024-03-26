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
    public class ParameterizedTests
    {
        private Math _math;

        [SetUp]
        public void Setup()
        {
            _math = new Math();
        }

        [Test]
        [TestCase(1,2,2)]
        [TestCase(2,1,2)]
        [TestCase(1,1,1)]
        public void Max_WhenExecuted_ReturnsGreaterNumber(int a, int b, int expectedValue)
        {
            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase(1,2,1)]
        [TestCase(2,1,1)]
        [TestCase(2,2,2)]
        public void Min_WhenExecuted_ReturnsLesserValue(int a, int b, int expectedValue)
        {
            var result = _math.Min(a, b);

            Assert.That(result, Is.EqualTo(expectedValue));
        }
    }
}
/* This exercise highlights the use of the [TestCase] decorator. This is used to make a test
    method polymorphic by allowing different values to be supplied to the test method, in other
    to test for different test cases associated with the method to be tested. 

        The tests used to test the "Max" method in exercise 03 has been combined into 1 polymorphic method
    That test for all the cases using the Polymorphic behaviour of the [TestCase()] decorator
*/