using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Mocking;

namespace TestApp.UnitTests.Mocking
{
    [TestFixture]
    public class VideoService_DI_Constructor_Tests
    {
        [Test]
        public void ReadVideoTitle_WhenVideoIsNull_ReturnsErrorMessage()
        {
            var videoService = new VideoService_DI_Constructor(new FakeFileReader());

            var result = videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
/* In this exercise, the VideoService class which is dependent on the FileReader class is tested
    by injecting a fake or ideal FakeFileReader class via the constructor of the VideoService
    class hence, the name "Dependency injection via constructor". The VideoService class can now be
    tested withouht being tightly coupled to the FileReader class because the VideoService accepts
    an interface of IFileReader as argument, of which the original FileReader is used when running
    the code, and the FakeFileReader is injected into the constructor, when running it in the test
*/