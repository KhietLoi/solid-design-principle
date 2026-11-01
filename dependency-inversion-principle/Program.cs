using System;

namespace DIP
{
    // ==================================================
    // MODEL
    // ==================================================

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Department: {Department}, Salary: {Salary}";
        }
    }

    // ==================================================
    // EXAMPLE 1: WITHOUT DIP
    // ==================================================

    #region Without DIP

    // Low-level module
    // Responsible for accessing employee data.
    public class EmployeeDataAccessLogic
    {
        public Employee GetEmployeeDetails(int id)
        {
            // In a real application, retrieve employee data from database.
            // For demonstration, we use hard-coded data.

            Employee emp = new Employee
            {
                ID = id,
                Name = "Pranaya",
                Department = "IT",
                Salary = 10000
            };

            return emp;
        }
    }

    // Factory creates a concrete EmployeeDataAccessLogic object.
    public class DataAccessFactory
    {
        public static EmployeeDataAccessLogic GetEmployeeDataAccessObj()
        {
            return new EmployeeDataAccessLogic();
        }
    }

    // High-level module
    // Directly depends on EmployeeDataAccessLogic.
    public class EmployeeBusinessLogic
    {
        private EmployeeDataAccessLogic _employeeDataAccessLogic;

        public EmployeeBusinessLogic()
        {
            _employeeDataAccessLogic = DataAccessFactory.GetEmployeeDataAccessObj();
        }

        public Employee GetEmployeeDetails(int id)
        {
            return _employeeDataAccessLogic.GetEmployeeDetails(id);
        }
    }

    #endregion

    // ==================================================
    // EXAMPLE 2: WITH DIP
    // ==================================================

    #region With DIP

    // Abstraction
    // Defines what employee data access should provide.
    public interface IEmployeeDataAccessLogic
    {
        Employee GetEmployeeDetails(int id);
    }

    // Low-level module
    // Implements the abstraction.
    public class EmployeeDataAccessLogicDIP : IEmployeeDataAccessLogic
    {
        public Employee GetEmployeeDetails(int id)
        {
            // In a real application, retrieve employee data from database.
            // For demonstration, we use hard-coded data.

            Employee emp = new Employee
            {
                ID = id,
                Name = "Pranaya",
                Department = "IT",
                Salary = 10000
            };

            return emp;
        }
    }

    // Factory returns an abstraction instead of a concrete class.
    public class DataAccessFactoryDIP
    {
        public static IEmployeeDataAccessLogic GetEmployeeDataAccessObj()
        {
            return new EmployeeDataAccessLogicDIP();
        }
    }

    // High-level module
    // Depends on abstraction instead of concrete implementation.
    public class EmployeeBusinessLogicDIP
    {
        private readonly IEmployeeDataAccessLogic _employeeDataAccessLogic;

        public EmployeeBusinessLogicDIP()
        {
            _employeeDataAccessLogic = DataAccessFactoryDIP.GetEmployeeDataAccessObj();
        }

        public Employee GetEmployeeDetails(int id)
        {
            return _employeeDataAccessLogic.GetEmployeeDetails(id);
        }
    }

    #endregion

    // ==================================================
    // PROGRAM
    // ==================================================

    class Program
    {
        static void Main(string[] args)
        {
            // ==========================================
            // CASE 1: WITHOUT DIP
            // ==========================================

            Console.WriteLine("======================================");
            Console.WriteLine("       CASE 1: WITHOUT DIP");
            Console.WriteLine("======================================");

            EmployeeBusinessLogic employeeBusinessLogic =
                new EmployeeBusinessLogic();

            Employee emp1 =
                employeeBusinessLogic.GetEmployeeDetails(1001);

            Console.WriteLine("\nEmployee Details:");
            Console.WriteLine(emp1);

            // ==========================================
            // CASE 2: WITH DIP
            // ==========================================

            Console.WriteLine("\n======================================");
            Console.WriteLine("       CASE 2: WITH DIP");
            Console.WriteLine("======================================");

            EmployeeBusinessLogicDIP employeeBusinessLogicDIP =
                new EmployeeBusinessLogicDIP();

            Employee emp2 =
                employeeBusinessLogicDIP.GetEmployeeDetails(1002);

            Console.WriteLine("\nEmployee Details:");
            Console.WriteLine(emp2);

            // ==========================================
            // END
            // ==========================================

            Console.WriteLine("\n======================================");
            Console.WriteLine("          PROGRAM FINISHED");
            Console.WriteLine("======================================");

            Console.ReadKey();
        }
    }
}
