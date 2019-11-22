using System;
using Models;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Employee Henok = new Employee()
            {
                UID = Guid.NewGuid(),
                NumberOfYearsEmployed = 10,
                FirstName = "Henok",
                LastName = "Wondem"

            }; 
            Console.WriteLine(Henok);

            EmployeeDAO employeeDAO = new EmployeeDAO();
            //List<Employee> employees = employeeDAO.GetAllEmployees();
            Console.WriteLine("Employees are: " + employeeDAO.GetAllEmployees());

            Employee emp = employeeDAO.GetEmployee("4063349E-EB0C-4702-919C-EE63B8C5609D");
            Console.WriteLine($"Employee is {emp}");

            WorksheetBuilder builder = new WorksheetBuilder();
            builder.buildWorksheet();

        }
    }
}
