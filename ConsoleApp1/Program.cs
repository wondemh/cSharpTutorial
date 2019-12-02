using System;
using System.Collections.Generic;
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

            //EmployeeDAO employeeDAO = new EmployeeDAO();
            ////List<Employee> employees = employeeDAO.GetAllEmployees();
            //Console.WriteLine("Employees are: " + employeeDAO.GetAllEmployees());

            //Employee emp = employeeDAO.GetEmployee("4063349E-EB0C-4702-919C-EE63B8C5609D");
            //Console.WriteLine($"Employee is {emp}");

            //WLRCensusReportBuilder builder = new WLRCensusReportBuilder();
            //builder.buildWorksheet();

            Location location = new WLRCensusDAO().GetLocation(4);
            Console.WriteLine($"Location is {location}");

            //AND B.CensusDate BETWEEN '2018-12-01' AND '2019-12-01'
            //AND D.FacilityType = 'CO'
            //AND D.Location = 4
            DateTime startDate = DateTime.Parse("Jan 1, 2018");
            DateTime endDate = DateTime.Parse("Dec 31, 2019");
            List<WLRCensusRecord> list = new WLRCensusDAO().GetWLRCensusRecords(4, startDate, endDate, "CO");
            Console.WriteLine($"Found {list.Count} records");

        }
    }
}
