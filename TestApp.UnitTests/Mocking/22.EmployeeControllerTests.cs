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
    public class EmployerControllerTests
    {
        private Mock<IEmployeeStorage> _employeeMock;
        private EmployeeController _employeeController;

        [SetUp]
        public void Setup()
        {
            // General Arranage
            _employeeMock = new Mock<IEmployeeStorage>();
            _employeeController = new EmployeeController(_employeeMock.Object);
        }

        [Test]
        public void DeleteEmployee_WhenExecuted_DeletesEmployee()
        {
            // Act
            var result = _employeeController.DeleteEmployee(1);

            // Assert
            _employeeMock.Verify((em) => em.DeleteEmployee(1));
        }

        [Test]
        public void DeleteEmployee_WhenExecuted_ReturnsRedirectionAction()
        {
            // Act
            var result = _employeeController.DeleteEmployee(1);

            // Assert
            Assert.That(result, Is.TypeOf<RedirectResult>());
        }        
    }
}
