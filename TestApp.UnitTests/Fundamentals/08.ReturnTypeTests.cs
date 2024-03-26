using NUnit.Framework;
using TestApp.Fundamentals;

namespace TestApp.UnitTests.Fundamentals
{
    [TestFixture]
    public class ReturnTypeTests
    {
        DemoController _controllerInstance;

        [SetUp]
        public void Setup()
        {
            _controllerInstance = new DemoController();
        }

        [Test]
        public void GetUser_UserIdIsZero_ShouldReturnNotfound()
        {
            var result = _controllerInstance.GetUser(0);

            // The "TypeOf" assertion asserts that the generic argument passed is exatly the type of the result under test
            Assert.That(result, Is.TypeOf<NotFound>());

            // The "InstanceOf" assertion asserts that the generic argument passes is the type, or derivative of the argument under test
            Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetUser_UserIdIsNotZero_ShouldReturnOk()
        {
            var result = _controllerInstance.GetUser(15);

            Assert.That(result, Is.InstanceOf<Ok>());

            Assert.That(result, Is.TypeOf<Ok>());
        }
    }
}
