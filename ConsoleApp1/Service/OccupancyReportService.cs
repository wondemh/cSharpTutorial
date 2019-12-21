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
        
        public void BuildReport(LocationCodes locationId, DateTime reportDate)
        {

            using var p = new ExcelPackage();
            var ws = p.Workbook.Worksheets.Add("Occupancy Report");

            Location location = OccupancyReportDAO.GetLocation(locationId);

            int rowNumber = 1;
            
            switch(locationId)
            {
                case LocationCodes.IKF:
                    buildIKFReport(location, reportDate);
                    break;
                case LocationCodes.IRC:
                    buildIRCReport(location, reportDate);
                    break;
                case LocationCodes.WLR:
                    buildWLRReport(location, reportDate);
                    break;
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

        private byte[] buildIKFReport(DateTime reportDate)
        {
            IndependentLivingSectionBuilder independentLivingSectionBuilder = new IndependentLivingSectionBuilder(LocationCodes.IKF, reportDate);
            IKFAssistedLivingSectionBuilder assistedLivingSectionBuilder = new IKFAssistedLivingSectionBuilder(reportDate);
            IKFMemorySupportSectionBuilder memorySupportSectionBuilder = new IKFMemorySupportSectionBuilder(reportDate);
            IKFSkilledNurseSectionBuilder skilledNursingSectionBuilder = new IKFSkilledNurseSectionBuilder(reportDate);

            using var p = new ExcelPackage();
            var ws = p.Workbook.Worksheets.Add("Occupancy Report");
            int rowNumber = 1;
            
            rowNumber = OccupancySectionBuilder.BuildPageHeader(ws, location.Name, reportDate, rowNumber);
            
            rowNumber = independentLivingSectionBuilder.BuildSectionHeader(ws, "Independent Living Occupancy Statistics", rowNumber);
            rowNumber = independentLivingSectionBuilder.BuildActualSection(ws, "Independent Living Occupancy Statistics", rowNumber);
            rowNumber = independentLivingSectionBuilder.BuildBudgetSection(ws, "Independent Living Occupancy Statistics", rowNumber);

            rowNumber = assistedLivingSectionBuilder.BuildActualSection(ws, "Independent Living Occupancy Statistics", rowNumber);
            rowNumber = assistedLivingSectionBuilder.BuildBudgetSection(ws, "Independent Living Occupancy Statistics", rowNumber);

            rowNumber = memorySupportSectionBuilder.BuildActualSection(ws, "Independent Living Occupancy Statistics", rowNumber);
            rowNumber = memorySupportSectionBuilder.BuildBudgetSection(ws, "Independent Living Occupancy Statistics", rowNumber);

            rowNumber = memorySupportSectionBuilder.BuildActualSection(ws, "Independent Living Occupancy Statistics", rowNumber);
            rowNumber = memorySupportSectionBuilder.BuildBudgetSection(ws, "Independent Living Occupancy Statistics", rowNumber);

            return null;

        }

        private byte[] buildIRCReport(Location location, DateTime reportDate)
        {
            return null;

        }

        private byte[] buildWLRReport(Location location, DateTime reportDate)
        {
            return null;

        }
    }
