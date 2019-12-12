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
        private readonly OccupancyReportDAO reportDAO;

        public OccupancyReportService()
        {
            reportDAO = new OccupancyReportDAO();
        }
        public void BuildReport(int locationId, DateTime reportDate)
        {
            using var p = new ExcelPackage();
            var ws = p.Workbook.Worksheets.Add("Occupancy Report");

            Location location = reportDAO.GetLocation(locationId);

            List<FacilityType> facilityTypes = reportDAO.GetFactilityTypesByLocation(locationId);
            List<string> independentLivingFacilityTypeCodes = new List<string> { "IL", "AP", "CO", "PS" };
            bool addedIndependentLivingSection = false;
            bool addedAssistedLivingSection = false;
            bool addedMemorySupportSection = false;
            bool addedSkilledNurseSection = false;

            foreach (var facilityType in facilityTypes)
            {
                //If IL, AP, CO, PS,  add Assisted Living section
                if (independentLivingFacilityTypeCodes.IndexOf(facilityType.FacilType) >= 0 && !addedIndependentLivingSection)
                {
                    AddIndependentLivingSection(ws, locationId, reportDate);
                    addedIndependentLivingSection = true;
                }

                //If AL, add Assisted Living section
                if (facilityType.FacilType.Equals("AL") && !addedAssistedLivingSection)
                {
                    AddAssistedLivingSection(ws, locationId, reportDate);
                    addedAssistedLivingSection = true;
                }

                //If MS, add Memory Support section
                if (facilityType.FacilType.Equals("MS") && !addedMemorySupportSection)
                {
                    AddMemorySupportSection(ws, locationId, reportDate);
                    addedMemorySupportSection = true;
                }

                //If MS, add Skilled Nurse section
                if (facilityType.FacilType.Equals("HC") && !addedSkilledNurseSection)
                {
                    AddSkilledNurseSection(ws, locationId, reportDate);
                    addedSkilledNurseSection = true;
                }
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

        private void AddIndependentLivingSection(ExcelWorksheet ws, int locationId, DateTime reportDate)
        {
            List<string> facilityTypeCodes = new List<string> { "IL", "AP", "CO", "PS" };
            IndependentLivingStats independentLivingStats = new IndependentLivingStats
            {
                UnitsAvailable = reportDAO.GetUnitsAvailableData(locationId, facilityTypeCodes),
                BeginningOccupancy = reportDAO.GetBeginningOccupancyData(locationId, facilityTypeCodes, reportDate.Year),
                MoveIns = reportDAO.GetCensusCountsByMonth("Move-ins", locationId, facilityTypeCodes, new List<string> { "A" }, reportDate.Year),
                MoveOuts = reportDAO.GetCensusCountsByMonth("Move-outs", locationId, facilityTypeCodes, new List<string> { "D", "DH", "L" }, reportDate.Year),
                Transfers = reportDAO.GetCensusCountsByMonth("Transfer to AL/HC", locationId, facilityTypeCodes, new List<string> { "PT", "TT" }, reportDate.Year)
            };
        }

        private void AddAssistedLivingSection(ExcelWorksheet ws, int locationId, DateTime reportDate)
        {

        }

        private void AddMemorySupportSection(ExcelWorksheet ws, int locationId, DateTime reportDate)
        {

        }

        private void AddSkilledNurseSection(ExcelWorksheet ws, int locationId, DateTime reportDate)
        {

        }
    }
}
