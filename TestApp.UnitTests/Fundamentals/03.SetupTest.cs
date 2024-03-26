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
    public class WorkingWithTestSetup
    {
        private Math _math;

        [SetUp]
        public void Setup()
        {
            _math = new Math();
        }

        [Test]
        public void Max_FirstArgumentIsGreater_ReturnsFirstArgument()
        {
            var result = _math.Max(2,1);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_SecondArgumentIsGreater_ReturnsSecondArgument()
        {
            var result = _math.Max(2, 1);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_BothArgumentsAreEqual_ReturnsSameArgument()
        {
            var result = _math.Max(1, 1);

            Assert.That(result, Is.EqualTo(1));
        }
    }
}

/* This exercise explores working with the NUnit [SetUp] decorator that is used to specify a certain
    action to be executed at the start of the execution of each test method.

    The [TearDown] decorator is the opposite for the Setup decorator. It specifies actions to be carries
    out after the execution of each individual test method.
*/