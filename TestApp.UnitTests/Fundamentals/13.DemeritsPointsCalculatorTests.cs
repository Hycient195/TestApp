using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestApp.UnitTests.Fundamentals
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _calculatorInstance;

        [SetUp]
        public void Setup()
        {
            _calculatorInstance = new DemeritPointsCalculator(); // Recureive Arrange step
        }

        [Test]
        [TestCase(-1)]
        [TestCase(350)]
        public void CalculateDemeritPoints_InputLessThan0OrMoreThan300_ReturnsOutOfRangeException(int input)
        {
            Assert.That(() => _calculatorInstance.CalculateDemeritPoints(input), Throws.Exception.TypeOf<ArgumentOutOfRangeException>()); // Assert
        }

        [Test]
        [TestCase(10)]
        [TestCase(30)]
        [TestCase(0)]
        [TestCase(65)]
        public void CalculateDemeritPoints_SpeedLessThanSpeedLimit_ReturnsZero(int input)
        {
            var result = _calculatorInstance.CalculateDemeritPoints(input);

            Assert.That(result, Is.Zero);
        }

        [Test]
        [TestCase(80, 3)]
        [TestCase(70, 1)]
        [TestCase(100, 7)]
        public void CalculateDemeritPoints_SpeedMoreThanMaxSpeedButLessThanSpeedLimit_ReturnsDemeritPoints(int input, int requiredOutput)
        {
            var result = _calculatorInstance.CalculateDemeritPoints(input);

            Assert.That(result, Is.EqualTo(requiredOutput));
        }
    }
}
