﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CensusReportApp
{
    class Program
    {
        static void Main()
        {
            CensusReportService service = new CensusReportService();
            service.BuildReport(4, DateTime.Parse("Oct 1, 2019"), DateTime.Parse("Oct 3, 2019"), "CO");

        }
    }
}
