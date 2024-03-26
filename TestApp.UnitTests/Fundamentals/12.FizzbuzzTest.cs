using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Fundamentals;

namespace TestApp.UnitTests.Fundamentals
{
    [TestFixture]
    public class FizzBuzzTest
    {
        [Test]
        [TestCase(15, "FizzBuzz")]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(30, "FizzBuzz")]
        [TestCase(6, "Fizz")]
        [TestCase(20, "Buzz")]
        [TestCase(2, "2")]
        public void GetOutput_WhenExecuted_ReturnsExpectedValue(int input, string expectedResult)
        {
            var result = FizzBuzz.GetOutput(input);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
