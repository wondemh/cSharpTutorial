using OfficeOpenXml;
using ReportApp.DAO;
using ReportApp.Model;
using ReportApp.Model.Occupancy;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReportApp
{
    public class OccupancyReportService
    {
        
        public static void BuildReport(LocationCodes locationId, DateTime reportDate)
        {

            using var p = new ExcelPackage();
            var ws = p.Workbook.Worksheets.Add("Occupancy Report");

            Location location = OccupancyReportDAO.GetLocation(locationId);

            int rowNumber = 1;
            
            switch(locationId)
            {
                case LocationCodes.IKF:

            }

            ws.PrinterSettings.PaperSize = ePaperSize.A4;
            ws.PrinterSettings.Orientation = eOrientation.Portrait;
            ws.PrinterSettings.HorizontalCentered = true;
            ws.PrinterSettings.LeftMargin = new decimal(0.5);
            ws.PrinterSettings.Scale = 200;
            ws.PrinterSettings.FitToPage = true;
            ws.PrinterSettings.FitToWidth = 1;
            ws.PrinterSettings.FitToHeight = 0;

            //Repeat title row on every page
            //ws.PrinterSettings.RepeatRows = new ExcelAddress("1:1");

            ws.Cells["A:N"].AutoFitColumns();
            p.SaveAs(new FileInfo(@"C:\Users\wondemh\source\repos\cSharpTutorial\OccupancyReport.xlsx"));
        }

        private byte[] buildIKFReport(Location location, DateTime reportDate)
        {
            using var p = new ExcelPackage();
            var ws = p.Workbook.Worksheets.Add("Occupancy Report");
            int rowNumber = 1;
            rowNumber = OccupancySectionBuilder.BuildPageHeader(ws, location.Name, reportDate, rowNumber);
            row
            return null;

        }
        
    }
}
