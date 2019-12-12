using OfficeOpenXml;
using ReportApp.DAO;
using ReportApp.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReportApp
{
    public class OccupancyReportService
    {
        private readonly OccupancyReportDAO reportDAO;

        public OccupancyReportService()
        {
            reportDAO = new OccupancyReportDAO();
        }
        public void BuildReport(int locationId, DateTime reportDate)
        {
            Location location = reportDAO.GetLocation(locationId);

            List<FacilityType> facilityTypes = reportDAO.GetFactilityTypesByLocation(locationId);

            foreach (var facilityType in facilityTypes)
            {
                List<OccupancyRecord> occupancyRecords = new List<OccupancyRecord>
                {
                    GetUnitsAvailableData(locationId, facilityType.FacilType),
                    GetBeginningOccupancyData(locationId, facilityType.FacilType, reportDate.Year),
                    GetMoveInData(locationId, facilityType.FacilType, reportDate.Year),
                    GetMoveOutData(locationId, facilityType.FacilType, reportDate.Year)
                };
            }




            using var p = new ExcelPackage();
            var ws = p.Workbook.Worksheets.Add("Occupancy Report");


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

        private OccupancyRecord GetUnitsAvailableData(int locationId, string facilityTypeCode)
        {
            List<OccupancyRecord> unitsAvailable = new List<OccupancyRecord>();
            int countOfAllUnits = reportDAO.GetCountOfAllUnits(locationId, facilityTypeCode);
            OccupancyRecord record = new OccupancyRecord
            {
                RecordTypeDescription = "Units Available",
                JanuaryValue = countOfAllUnits,
                FebruaryValue = countOfAllUnits,
                MarchValue = countOfAllUnits,
                AprilValue = countOfAllUnits,
                MayValue = countOfAllUnits,
                JuneValue = countOfAllUnits,
                JulyValue = countOfAllUnits,
                AugustValue = countOfAllUnits,
                SeptemberValue = countOfAllUnits,
                OctoberValue = countOfAllUnits,
                NovemberValue = countOfAllUnits,
                DecemberValue = countOfAllUnits
            };
            return record;
        }

        private OccupancyRecord GetBeginningOccupancyData(int locationId, string facilityTypeCode, int year)
        {
            OccupancyRecord record = new OccupancyRecord
            {
                RecordTypeDescription = "Beginning Occupancy",
                JanuaryValue = reportDAO.GetBeginningOccupancy(locationId, facilityTypeCode, year, 1),
                FebruaryValue = reportDAO.GetBeginningOccupancy(locationId, facilityTypeCode, year, 2),
                MarchValue = reportDAO.GetBeginningOccupancy(locationId, facilityTypeCode, year, 3),
                AprilValue = reportDAO.GetBeginningOccupancy(locationId, facilityTypeCode, year, 4),
                MayValue = reportDAO.GetBeginningOccupancy(locationId, facilityTypeCode, year, 5),
                JuneValue = reportDAO.GetBeginningOccupancy(locationId, facilityTypeCode, year, 6),
                JulyValue = reportDAO.GetBeginningOccupancy(locationId, facilityTypeCode, year, 7),
                AugustValue = reportDAO.GetBeginningOccupancy(locationId, facilityTypeCode, year, 8),
                SeptemberValue = reportDAO.GetBeginningOccupancy(locationId, facilityTypeCode, year, 9),
                OctoberValue = reportDAO.GetBeginningOccupancy(locationId, facilityTypeCode, year, 10),
                NovemberValue = reportDAO.GetBeginningOccupancy(locationId, facilityTypeCode, year, 11),
                DecemberValue = reportDAO.GetBeginningOccupancy(locationId, facilityTypeCode, year, 12)
            };
            return record;
        }

        private OccupancyRecord GetMoveInData(int locationId, string facilityTypeCode, int year)
        {
            OccupancyRecord record = new OccupancyRecord
            {
                RecordTypeDescription = "Move-ins",
                JanuaryValue = reportDAO.GetCountOfMoveIns(locationId, facilityTypeCode, year, 1),
                FebruaryValue = reportDAO.GetCountOfMoveIns(locationId, facilityTypeCode, year, 2),
                MarchValue = reportDAO.GetCountOfMoveIns(locationId, facilityTypeCode, year, 3),
                AprilValue = reportDAO.GetCountOfMoveIns(locationId, facilityTypeCode, year, 4),
                MayValue = reportDAO.GetCountOfMoveIns(locationId, facilityTypeCode, year, 5),
                JuneValue = reportDAO.GetCountOfMoveIns(locationId, facilityTypeCode, year, 6),
                JulyValue = reportDAO.GetCountOfMoveIns(locationId, facilityTypeCode, year, 7),
                AugustValue = reportDAO.GetCountOfMoveIns(locationId, facilityTypeCode, year, 8),
                SeptemberValue = reportDAO.GetCountOfMoveIns(locationId, facilityTypeCode, year, 9),
                OctoberValue = reportDAO.GetCountOfMoveIns(locationId, facilityTypeCode, year, 10),
                NovemberValue = reportDAO.GetCountOfMoveIns(locationId, facilityTypeCode, year, 11),
                DecemberValue = reportDAO.GetCountOfMoveIns(locationId, facilityTypeCode, year, 12)
            };
            return record;
        }

        private OccupancyRecord GetMoveOutData(int locationId, string facilityTypeCode, int year)
        {
            OccupancyRecord record = new OccupancyRecord
            {
                RecordTypeDescription = "Move-ins",
                JanuaryValue = reportDAO.GetCountOfMoveOuts(locationId, facilityTypeCode, year, 1),
                FebruaryValue = reportDAO.GetCountOfMoveOuts(locationId, facilityTypeCode, year, 2),
                MarchValue = reportDAO.GetCountOfMoveOuts(locationId, facilityTypeCode, year, 3),
                AprilValue = reportDAO.GetCountOfMoveOuts(locationId, facilityTypeCode, year, 4),
                MayValue = reportDAO.GetCountOfMoveOuts(locationId, facilityTypeCode, year, 5),
                JuneValue = reportDAO.GetCountOfMoveOuts(locationId, facilityTypeCode, year, 6),
                JulyValue = reportDAO.GetCountOfMoveOuts(locationId, facilityTypeCode, year, 7),
                AugustValue = reportDAO.GetCountOfMoveOuts(locationId, facilityTypeCode, year, 8),
                SeptemberValue = reportDAO.GetCountOfMoveOuts(locationId, facilityTypeCode, year, 9),
                OctoberValue = reportDAO.GetCountOfMoveOuts(locationId, facilityTypeCode, year, 10),
                NovemberValue = reportDAO.GetCountOfMoveOuts(locationId, facilityTypeCode, year, 11),
                DecemberValue = reportDAO.GetCountOfMoveOuts(locationId, facilityTypeCode, year, 12)
            };
            return record;
        }
    }
}
