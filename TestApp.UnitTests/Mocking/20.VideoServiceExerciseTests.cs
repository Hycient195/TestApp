using Moq;
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
    public class VideoServiceExerciseTests
    {
        private Mock<IVideoRepository> _videoRepositoryMock;
        private VideoServiceExercise _videoService;

        [SetUp]
        public void Setup()
        {
            // Arrange (recursive)
            _videoRepositoryMock = new Mock<IVideoRepository>();
            _videoService = new VideoServiceExercise();
        }


        [Test]
        public void GetUnprocessedVideosAsCSV_AllVideosProcessed_ReturnsEmptyString()
        {
            // Arrange
            _videoRepositoryMock.Setup((vi) => vi.GetUnprocessedVideos()).Returns(new List<Video>());

            // Act
            var result = _videoService.GetUnprocessedVideosAsCsv(_videoRepositoryMock.Object);

            // Assert
            Assert.That(result, Is.EqualTo(""));
        }


        [Test]
        public void GetUnprocessedVideosAsCSV_AFewUnprocessedVideos_ReturnsAStringOfCommaSeparatedVideoIds()
        {
            // Arrange
            _videoRepositoryMock.Setup((vi) => vi.GetUnprocessedVideos()).Returns(new List<Video>
            {
                new Video { Id = 1 },
                new Video { Id = 2 },
                new Video { Id = 3 }
            });

            // Act
            var result = _videoService.GetUnprocessedVideosAsCsv(_videoRepositoryMock.Object);

            // Assert
            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}

/* In this test, the GetUnprocessedVideosAsCsv method of the VideoService class is dependent on
 * an external resource, which is a database from which the videos are loaded from. In order to
    test the GetUnprocessedVideosAsCsv method that returns the IDs of the unprocssed videos as
    a CSV string, the part of the method that gets the video from DB is extracted as an external component
    called "VideoRepository" when _videoService.GetUnprocessedVideosAsCsv() is tested, to prevent
    dependency and tight coupling to the VideoRepository, a dependency injection is created, from
    which a mock of the VideoRepository is injected for the testing of GetUnprocessedVideosAsCsv,
    to prevent tight coupling to the original VideoRepository, and the latency that originates
    from actually querying the database to get the videos, and the possibility of the event that
    the request to the database may fail.
*/