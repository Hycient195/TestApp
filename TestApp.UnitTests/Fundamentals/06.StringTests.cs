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
    public class StringTests
    {
        [Test]
        public void EmboldenText_WhenExecuted_EncloseStringInStrongElement()
        {
            var stringUtil = new Strings(); // Arrange

            var result = stringUtil.EmboldenText("Hello");

            Assert.That(result, Is.EqualTo("<strong>Hello</strong>")); // A spedific assertion

            // More general assertions
            Assert.That(result, Does.StartWith("<strong>"));
            Assert.That(result, Does.Contain("Hello"));
            Assert.That(result, Does.EndWith("</strong>").IgnoreCase); // This is used when to make the3 assertion case insensitive
        }
    }
}

/* The example above explores the testing for strings. a a rule of thumb, tests writted for
 * strings should not be too specific, and not be too general. They should lie somewhere
   in-between for the best coverage. In a particular example above, a specific test could
   work fine, but in a case of test for an error message string, the general approach would
   work better, as little alterations like period (.), comma or exclamation marks could be 
   added to error message, and it would be better to check for certain key words in the error
   message instead of testing the string word for word. 
*/
