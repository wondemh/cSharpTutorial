﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ReportApp
{
    class Program
    {
        static void Main()
        {
            
            //CensusReportService.BuildReport(4, DateTime.Parse("Oct 19, 2012", CultureInfo.CurrentCulture), DateTime.Parse("Oct 19, 2012", CultureInfo.CurrentCulture), "CO");

            //OccupancyReportService.BuildReport(DAO.LocationCode.IRC, DateTime.Parse("Oct 19, 2012"));
            //OccupancyReportService.BuildReport(DAO.LocationCode.IKF, DateTime.Parse("Oct 19, 2012"));
            OccupancyReportService.BuildReport(DAO.LocationCode.WLR, DateTime.Parse("Oct 19, 2019"));

        }
    }
}
