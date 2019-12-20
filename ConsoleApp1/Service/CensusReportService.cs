using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;

using ReportApp.Model;
using ReportApp.DAO;

namespace ReportApp
{
    public static class CensusReportService
    {
        public static void BuildReport(int locationId, DateTime startDate, DateTime endDate, string facilityTypeCode)
        {
            Location location = CensusReportDAO.GetLocation(locationId);
            List<CensusItem> listForDateRange = CensusReportDAO.GetCensusRecords(4, startDate, endDate, facilityTypeCode);
            List<Unit> vacantUnits = CensusReportDAO.GetVacantUnits(locationId, facilityTypeCode, startDate);
            int countOfAllUnits = CensusReportDAO.GetCountOfAllUnits(locationId, facilityTypeCode);

            using var p = new ExcelPackage();
            var ws = p.Workbook.Worksheets.Add("Census Report");
            int rowNumber = RosterSectionBuilder.BuildRosterSection(ws, facilityTypeCode, listForDateRange, location, startDate, endDate);
            if (startDate.Date != endDate.Date)
            {
                List<CensusItem> listForSingleDate = CensusReportDAO.GetCensusRecords(4, startDate, startDate, facilityTypeCode);
                rowNumber = GrandTotalsSectionBuilder.AddGrandTotalsSection(ws, listForSingleDate, vacantUnits.Count, countOfAllUnits, rowNumber, startDate);
                rowNumber = GrandTotalsSectionBuilder.AddGrandTotalsSection(ws, listForDateRange, vacantUnits.Count, countOfAllUnits, rowNumber, startDate, endDate);
            }
            else
            {
                rowNumber = GrandTotalsSectionBuilder.AddGrandTotalsSection(ws, listForDateRange, vacantUnits.Count, countOfAllUnits, rowNumber, startDate);
            }

            //Add page break before vacant rooms section
            ws.Row(rowNumber).PageBreak = true;

            rowNumber += 4;//Add 4 empty rows above vacant rooms section
            VacantRoomsSectionBuilder.AddVacantRoomsSection(ws, vacantUnits, startDate, rowNumber);

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
            p.SaveAs(new FileInfo(@"C:\Users\wondemh\source\repos\cSharpTutorial\"+ location.Name +" Census - " + facilityTypeCode + ".xlsx"));
        }

    }
}
