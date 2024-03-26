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
    public class ExceptionTests
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string errorMessage)
        {
            var errorLogger = new ErrorLogger();

            // This approach is used where the exception is a popular exception contained in the NUnit assertion library
            Assert.That(() => errorLogger.Log(errorMessage), Throws.ArgumentNullException);

            // For cases where the exception does not exist in the suite, the approach below can be used the the particular exception can be provided as a generic argument
            Assert.That(() => errorLogger.Log(errorMessage), Throws.Exception.TypeOf<ArgumentNullException>());
        }
    }
}
