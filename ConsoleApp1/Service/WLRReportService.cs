using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;

using ConsoleApp1.Model;
using ConsoleApp1.DAO;

namespace ConsoleApp1
{
    public class WLRReportService
    {
        private readonly WLRReportDAO reportDAO;

        public WLRReportService()
        {
            reportDAO = new WLRReportDAO();

        }
        public void BuildReport(int locationId, DateTime startDate, DateTime endDate, string facilityTypeCode)
        {
            Location location = reportDAO.GetLocation(locationId);
            FacilityType facilityType = reportDAO.GetFacilityType(locationId, facilityTypeCode);
            List<CensusItem> listForDateRange = reportDAO.GetCensusRecords(4, startDate, endDate, facilityTypeCode);
            //Console.WriteLine($"Found {listForDateRange.Count} records");
            List<Unit> vacantUnits = reportDAO.GetVacantUnits(startDate);
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
            rowNumber++;//Add empty row above vacant rooms section
            rowNumber = VacantRoomsSectionBuilder.AddVacantRoomsSection(ws, vacantUnits, startDate, rowNumber);

            rowNumber++;//Add empty row above census history section
            List<CensusHistoryItem> censusHistoryRecords = reportDAO.GetCensusHistoryRecords(4, startDate, endDate, facilityTypeCode);
            rowNumber = HistorySectionBuilder.BuildHistorySection(ws, censusHistoryRecords, location, facilityType, startDate, endDate, rowNumber);

            ws.Cells["A:T"].AutoFitColumns();
            p.SaveAs(new FileInfo(@"C:\Users\wondemh\source\repos\cSharpTutorial\Census Report - WLR - " + facilityTypeCode + ".xlsx"));
        }

    }
}
