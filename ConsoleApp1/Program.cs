using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            WLRReportService service = new WLRReportService();
            service.BuildReport(4, DateTime.Parse("Oct 1, 2019"), DateTime.Parse("Oct 3, 2019"), "CO");

        }
    }
}
