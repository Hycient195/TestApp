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
    public class HouseKeeperHelperTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<IStatementGenerator> _statementGeneratorMock;
        private Mock<IEmailSender> _emailSenderMock;
        private Mock<IMessageBox> _messageBoxMock;
        private DateTime _statementDate = new DateTime(2024, 03, 26, 12, 0, 0);
        private Housekeeper _houseKeeper;
        private HousekeeperHelper _houseKeeperInstance;

        [SetUp]
        public void Setup()
        {
            _emailSenderMock = new Mock<IEmailSender>();
            _messageBoxMock = new Mock<IMessageBox>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _statementGeneratorMock = new Mock<IStatementGenerator>();
            _houseKeeperInstance = new HousekeeperHelper(_unitOfWorkMock.Object, _statementGeneratorMock.Object, _emailSenderMock.Object, _messageBoxMock.Object);

            _houseKeeper = new Housekeeper
            {
                Oid = 1,
                Email = "a",
                FullName = "b",
                StatementEmailBody = "email body"
            };

            _unitOfWorkMock.Setup((uow) => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                _houseKeeper
            }.AsQueryable);
        }

        [Test]
        public void SendStatementEmails_WhenInvoked_SavesStatementDocument()
        {
            // Act
            _houseKeeperInstance.SendStatementEmails(_statementDate);

            // Assert
            _statementGeneratorMock.Verify((sg) => sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementEmails_HouseKeeperEmailIsNullWhitespaceOrEmpty_ShouldNotGenerateStatement(string arg)
        {
            // Arrange
            _houseKeeper.Email = arg;

            // Act
            _houseKeeperInstance.SendStatementEmails(_statementDate);

            // Assert
            _statementGeneratorMock.Verify(sg => sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate), Times.Never);
        }

        [Test]
        public void SendStatementEmails_WhenInvoked_SendEmailFile()
        {
            // Arrange
            _statementGeneratorMock.Setup((st) => st.SaveStatement(
                  _houseKeeper.Oid, _houseKeeper.FullName, _statementDate
              )).Returns("FileName");

            // Act
            _houseKeeperInstance.SendStatementEmails(_statementDate);

            // Assert
            _emailSenderMock.Verify(es => es.EmailFile(_houseKeeper.Email, _houseKeeper.StatementEmailBody, "FileName",
                string.Format("Sandpiper Statement {0:yyyy-MM} {1}", _statementDate, _houseKeeper.FullName)));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementEmails_StatementFileIsNullWhiteSpaceOrEmpty_ShouldNotSendEmail(string statementFile)
        {
            // Arrange
            _statementGeneratorMock.Setup((st) => st.SaveStatement(
                  _houseKeeper.Oid, _houseKeeper.FullName, _statementDate
              )).Returns(statementFile);

            // Act
            _houseKeeperInstance.SendStatementEmails(_statementDate);

            // Assert
            _emailSenderMock.Verify(es => es.EmailFile(_houseKeeper.Email, _houseKeeper.StatementEmailBody, statementFile,
                It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void SendStatementEmails_EmailSendingFails_DisplaysMessageBox()
        {
            // Arrange
            _statementGeneratorMock.Setup((st) => st.SaveStatement(
                _houseKeeper.Oid, _houseKeeper.FullName, _statementDate
            )).Returns("FileName");

            _emailSenderMock.Setup(es => es.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()
            )).Throws<Exception>();

            // Act
            _houseKeeperInstance.SendStatementEmails(_statementDate);

            // Assert
            _messageBoxMock.Verify(mb => mb.Show(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButtons.OK));
        }
    }
}
