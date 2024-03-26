using System.Data.Entity;

namespace TestApp.Mocking
{
    public class EmployeeController
    {
        private IEmployeeStorage _employee;

        public EmployeeController(IEmployeeStorage employeeStorage)
        {
            _employee = employeeStorage;
        }

        public ActionResult DeleteEmployee(int id)
        {
            _employee.DeleteEmployee(id);
            return RedirectToAction("Employees");
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }

    public class ActionResult { }
 
    public class RedirectResult : ActionResult { }
    
    public class EmployeeContext
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {
        }
    }

    public class Employee
    {
    }
}

/* In this exercise file, the DB layer has now been abstracted away from the controller layer
    such that all operations to the db are made in the db layer, and the controller not have
    any direction interraction with the db, hence, even allowing more room for testability,
    by allowing the controller to be tested individually from the db by plugging in mocks of
    the DB in the unit tests.
*/