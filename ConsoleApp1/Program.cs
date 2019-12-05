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
            WLRCensusReportService builder = new WLRCensusReportService();
            builder.buildWorksheet(4, DateTime.Parse("Oct 1, 2019"), DateTime.Parse("Oct 30, 2019"), "CO");

        }
    }
}
