using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ReportApp
{
    class Program
    {
        static void Main()
        {
            //CensusReportService service = new CensusReportService();
            //service.BuildReport(4, DateTime.Parse("Oct 19, 2012", CultureInfo.CurrentCulture), DateTime.Parse("Oct 19, 2012", CultureInfo.CurrentCulture), "CO");

            OccupancyReportService.BuildReport(1, DateTime.Now);

        }
    }
}
