using System;
using System.Collections.Generic;
using System.Linq;
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

            WLRCensusReportService builder = new WLRCensusReportService();
            builder.buildWorksheet(4, DateTime.Parse("Oct 1, 2019"), DateTime.Parse("Dec 31, 2019"), "CO");

            //Location location = new WLRCensusDAO().GetLocation(4);
            //Console.WriteLine($"Location is {location}");

            //DateTime startDate = DateTime.Parse("Oct 1, 2019");
            //DateTime endDate = DateTime.Parse("Dec 31, 2019");
            //List<WLRCensusRecord> list = new WLRCensusDAO().GetWLRCensusRecords(4, startDate, endDate, "CO");
            //Console.WriteLine($"Found {list.Count} records");

            //var recordsGroupedByPayorType = list.GroupBy(record => record.PayorType);
            //foreach (var group in recordsGroupedByPayorType)
            //{
            //    Console.WriteLine("Records with Payor Type: " + group.Key + ":");
            //    var recordsGroupedByAdmissionStatus = group.GroupBy(item => item.AdmissionStatus);
            //    foreach (var group2 in recordsGroupedByAdmissionStatus)
            //    {
            //        Console.WriteLine("Records with Admission Status: " + group2.Key + ":");
            //        foreach (var record in group2)
            //            Console.WriteLine("* " + record.FirstName + " " + record.LastName);
            //    }
            //}


        }
    }
}
