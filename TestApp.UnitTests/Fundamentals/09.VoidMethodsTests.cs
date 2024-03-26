using NUnit.Framework;
using TestApp.Fundamentals;

namespace TestApp.UnitTests.Fundamentals
{
    [TestFixture                
                
                ]
    public class VoidMethodTests
    {
        [Test]
        public void Log_WhenInvoked_SetsTheLastErrorProperty()
        {
            var log = new ErrorLogger();

            log.Log("error");

            Assert.That(log.LastError, Is.EqualTo("error"));
        }
    }
}

/* This exercise highlights the testing of void methods of methods that do not return any
    Value, but rather perform an action or change the state of an internal variable, or
    resource in memory. 
*/