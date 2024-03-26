using NUnit.Framework;
using TestApp.Mocking;

namespace TestApp.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTestsViaProperties
    {
        [Test]
        public void ReadVideoTitle_WhenVideoIsNull_ReturnsErrorMessage()
        {
            var videoService = new VideoService_DI_Property();
            videoService.FileReader = new FakeFileReader(); // The fake file reader uses in the testing is now injected here to replace the original file reader defined in the VideoService class
            var result = videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
/* In this approach, the VideoService class makes use of the FileReader class for execution in production
    but however, exposes the instance to the FileReader it makes use of as a public property.
    In this approach of dependency injection in testing, the FileReader being used, since it is 
    exposed as a property, can be substituted with the FakeFileReader class used in testing, thereby
    preventing tight coupling of the VideoService class to the FileReader class, ensuring that the
    VideoSercie class can be tested as a separate entity.
*/