using OfficeOpenXml;
using ReportApp.DAO;
using ReportApp.Model;
using ReportApp.Model.Occupancy;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReportApp
{
    public static class OccupancyReportService
    {

        public static void BuildReport(int locationId, DateTime reportDate)
        {
            using var p = new ExcelPackage();
            var ws = p.Workbook.Worksheets.Add("Occupancy Report");

            Location location = OccupancyReportDAO.GetLocation(locationId);

            List<FacilityType> facilityTypes = OccupancyReportDAO.GetFacilityTypesByLocation(locationId);
            List<string> independentLivingFacilityTypeCodes = new List<string> { "IL", "AP", "CO", "PS" };
            bool addedIndependentLivingSection = false;
            bool addedAssistedLivingSection = false;
            bool addedMemorySupportSection = false;
            bool addedSkilledNurseSection = false;

            int rowNumber = 1;
            rowNumber = OccupancySectionBuilder.AddPageHeader(ws, location.Name, reportDate, rowNumber);
            foreach (var facilityType in facilityTypes)
            {
                //If IL, AP, CO, PS,  add Assisted Living section
                if (independentLivingFacilityTypeCodes.IndexOf(facilityType.FacilType) >= 0 && !addedIndependentLivingSection)
                {
                    rowNumber = IndependentLivingSectionBuilder.AddIndependentLivingSection(ws, locationId, reportDate, rowNumber);
                    addedIndependentLivingSection = true;
                }

                //If AL, add Assisted Living section
                if (facilityType.FacilType.Equals("AL", StringComparison.Ordinal) && !addedAssistedLivingSection)
                {
                    rowNumber = AssistedLivingSectionBuilder.AddAssistedLivingSection(ws, locationId, ++rowNumber);
                    addedAssistedLivingSection = true;
                }

                //If MS, add Memory Support section
                if (facilityType.FacilType.Equals("MS", StringComparison.Ordinal) && !addedMemorySupportSection)
                {
                    rowNumber = MemorySupportSectionBuilder.AddMemorySupportSection(ws, locationId, reportDate, ++rowNumber);
                    addedMemorySupportSection = true;
                }

                //If MS, add Skilled Nurse section
                if (facilityType.FacilType.Equals("HC", StringComparison.Ordinal) && !addedSkilledNurseSection)
                {
                    rowNumber = SkilledNurseSectionBuilder.AddSkilledNurseSection(ws, locationId, reportDate, ++rowNumber);
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
        
    }
}
