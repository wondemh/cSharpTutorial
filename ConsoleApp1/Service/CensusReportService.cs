using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;

using CensusReportApp.Model;
using CensusReportApp.DAO;

namespace CensusReportApp
{
    public class CensusReportService
    {
        private readonly CensusReportDAO reportDAO;

        public CensusReportService()
        {
            reportDAO = new CensusReportDAO();

        }
        public void BuildReport(int locationId, DateTime startDate, DateTime endDate, string facilityTypeCode)
        {
            Location location = reportDAO.GetLocation(locationId);
            List<CensusItem> listForDateRange = reportDAO.GetCensusRecords(4, startDate, endDate, facilityTypeCode);
            List<Unit> vacantUnits = reportDAO.GetVacantUnits(locationId, facilityTypeCode, startDate);
            int countOfAllUnits = reportDAO.GetCountOfAllUnits();

            using var p = new ExcelPackage();
            var ws = p.Workbook.Worksheets.Add("Census Report");
            int rowNumber = RosterSectionBuilder.BuildRosterSection(ws, facilityTypeCode, listForDateRange, location, startDate, endDate);
            if (startDate.Date != endDate.Date)
            {
                List<CensusItem> listForSingleDate = reportDAO.GetCensusRecords(4, startDate, startDate, facilityTypeCode);
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
            p.SaveAs(new FileInfo(@"C:\Users\wondemh\source\repos\cSharpTutorial\Census Report - WLR - " + facilityTypeCode + ".xlsx"));
        }

    }
}
