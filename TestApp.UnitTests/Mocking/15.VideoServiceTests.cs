using NUnit.Framework;
using TestApp.Mocking;

namespace TestApp.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        [Test]
        public void ReadVideoTitle_WhenVideoIsNull_ReturnsErrorMessage()
        {
            var videoService = new VideoService();
            var result = videoService.ReadVideoTitle(new FakeFileReader());

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
       
    }
}