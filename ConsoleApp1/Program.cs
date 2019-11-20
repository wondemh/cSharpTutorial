using System;
using Models;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee Henok = new Employee()
            {
                EmployeeId = Guid.NewGuid(),
                NumberOfYearsEmployed = 10,
                FirstName = "Henok",
                LastName = "Wondem"

            };
            Console.WriteLine(Henok);

            EmployeeDAO employeeDAO = new EmployeeDAO();
            //List<Employee> employees = employeeDAO.GetAllEmployees();
            Console.WriteLine("Employees are: " + employeeDAO.GetAllEmployees());
            //testConnectionString
        }
    }
}
