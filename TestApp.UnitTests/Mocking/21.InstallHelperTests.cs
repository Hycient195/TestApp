using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestApp.Mocking;


namespace TestApp.UnitTests.Mocking
{
    [TestFixture]
    public class InstallHelperTests
    {
        private Mock<IFileDownloader> _fileDownloaderMock;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void Setup()
        {
            _fileDownloaderMock = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloaderMock.Object);
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnsFalse()
        {
            _fileDownloaderMock.Setup((fd) => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("customer", "installPath");

            Assert.That(result, Is.False);
        }

        [Test]
        public void DownloadInstaller_DownloadCompletes_ReturnsTrue()
        {
            var result = _installerHelper.DownloadInstaller("customer", "installPath");

            Assert.That(result, Is.True);
        }
    }
}

/* This test also explores the testing of a class which is dependent on another class. The
 *  "InstallerHelper" class being tested is refactored, that the part of it that downloads
    the file, is extracted into a new class called "FileDownloader". The FileDownloader
    class is then mocked using its interface "IFileDownloader"

    Two test cases are specified above for the "InstallerHelper's" "DownloadInstaller" method
    
    The first mocks "FileDownloader.DownloadFile" to throw a <WebException> error irrespective
    of whatever string argument is passed to it, and expects the "installerHelper.DownloadInstaller"
    method to return "false"

    The second test case on the other hand without specifying a mock for the fileDownloader.DownloadFile,
    expects the installerHelper.DownloadInstaller method to return true irrespective of what
    argument is passed to it.
*/