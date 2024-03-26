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
    public class VideoService_With_Moq_Tests
    {
        [Test]
        public void ReadVideoTitle_WhenVideoIsNull_ReturnsErrorMessage()
        {
            // Arrange
            var fileReader = new Mock<IFileReader>();
            fileReader.Setup((fr) => fr.Read("video.txt")).Returns("");
            var videoService = new VideoService();

            // Act
            var result = videoService.ReadVideoTitle(fileReader.Object);

            // Assert
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}

/* This example takes testing classes that are dependent on other classes, a step forward. It does
    this by introducing a mocking framework. The mocking framework takes charge of now replacing our
    hard-coded FakeFileReader class with a flexible fileReader created using the Moq mocking framework

    The Moq framework does this by accepting a generic argumen of the type (interface or class) to be
    mocked, and the exposes a "Setup" method which would be used to properly configure our mocked
    class to our requirements. 

    The "Setup" method accepts a lambda expression as its argument, whoose own argument select one of
    the methods contained in the interface or class being used. It specifies an input for the method
    being mocked, and then an expected output can then be chained to the Setup method. The expected
    output may include return values to be expected, (Returns()), error to be thrown (Throws()), etc.
*/