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

        public static byte[] BuildReport(LocationCode locationId, DateTime reportDate)
        {

            using var p = new ExcelPackage();
            var ws = p.Workbook.Worksheets.Add("Occupancy");

            switch (locationId)
            {
                case LocationCode.IKF:
                    BuildIKFReport(reportDate, ws);
                    break;
                case LocationCode.IRC:
                    BuildIRCReport(reportDate, ws);
                    break;
                case LocationCode.WLR:
                    BuildWLRReport(reportDate, ws);
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

            ws.Cells["A:O"].AutoFitColumns();
            p.SaveAs(new FileInfo(@"C:\Users\wondemh\source\repos\cSharpTutorial\" + reportDate.ToString("MM-dd-yyyy") + "-" + locationId + " Campus Report.xlsx"));
            return p.GetAsByteArray();
        }

        private static void BuildIKFReport(DateTime reportDate, ExcelWorksheet ws)
        {
            IndependentLivingSectionBuilder independentLivingSectionBuilder = new IndependentLivingSectionBuilder(LocationCode.IKF, reportDate);
            IKFAssistedLivingSectionBuilder assistedLivingSectionBuilder = new IKFAssistedLivingSectionBuilder(reportDate);
            IKFMemorySupportSectionBuilder memorySupportSectionBuilder = new IKFMemorySupportSectionBuilder(reportDate);
            IKFSkilledNurseSectionBuilder skilledNursingSectionBuilder = new IKFSkilledNurseSectionBuilder(reportDate);

            int rowNumber = 1;

            Location location = OccupancyReportDAO.GetLocation(LocationCode.IKF);
            rowNumber = OccupancySectionBuilder.BuildPageHeader(ws, location.Name, reportDate, rowNumber);

            rowNumber = OccupancySectionBuilder.BuildSectionHeader(ws, "Independent Living Occupancy Statistics", rowNumber);
            rowNumber = independentLivingSectionBuilder.BuildActualSection(ws, rowNumber);
            rowNumber = independentLivingSectionBuilder.BuildBudgetSection(ws, rowNumber);

            rowNumber = OccupancySectionBuilder.BuildSectionHeader(ws, "Assisted Living Occupancy Statistics", rowNumber);
            rowNumber = assistedLivingSectionBuilder.BuildActualSection(ws, rowNumber);
            rowNumber = assistedLivingSectionBuilder.BuildBudgetSection(ws, rowNumber);

            rowNumber = OccupancySectionBuilder.BuildSectionHeader(ws, "Assisted Living Memory Support Occupancy Statistics", rowNumber);
            rowNumber = memorySupportSectionBuilder.BuildActualSection(ws, rowNumber);
            rowNumber = memorySupportSectionBuilder.BuildBudgetSection(ws, rowNumber);

            rowNumber = OccupancySectionBuilder.BuildSectionHeader(ws, "Skilled Nursing Occupancy Statistics", rowNumber);
            rowNumber = skilledNursingSectionBuilder.BuildActualSection(ws, rowNumber);
            skilledNursingSectionBuilder.BuildBudgetSection(ws, rowNumber);
        }

        private static void BuildIRCReport(DateTime reportDate, ExcelWorksheet ws)
        {
            IndependentLivingSectionBuilder independentLivingSectionBuilder = new IndependentLivingSectionBuilder(LocationCode.IKF, reportDate);
            IRCAssistedLivingSectionBuilder assistedLivingSectionBuilder = new IRCAssistedLivingSectionBuilder(reportDate);
            IRCMemorySupportSectionBuilder memorySupportSectionBuilder = new IRCMemorySupportSectionBuilder(reportDate);
            IRCSkilledNurseSectionBuilder skilledNursingSectionBuilder = new IRCSkilledNurseSectionBuilder(reportDate);

            int rowNumber = 1;

            Location location = OccupancyReportDAO.GetLocation(LocationCode.IRC);
            rowNumber = OccupancySectionBuilder.BuildPageHeader(ws, location.Name, reportDate, rowNumber);

            rowNumber = OccupancySectionBuilder.BuildSectionHeader(ws, "Independent Living Occupancy Statistics", rowNumber);
            rowNumber = independentLivingSectionBuilder.BuildActualSection(ws, rowNumber);
            rowNumber = independentLivingSectionBuilder.BuildBudgetSection(ws, rowNumber);

            rowNumber = OccupancySectionBuilder.BuildSectionHeader(ws, "Assisted Living Occupancy Statistics", rowNumber);
            rowNumber = assistedLivingSectionBuilder.BuildActualSection(ws, rowNumber);
            rowNumber = assistedLivingSectionBuilder.BuildBudgetSection(ws, rowNumber);
           
            rowNumber = OccupancySectionBuilder.BuildSectionHeader(ws, "Assisted Living Memory Support Occupancy Statistics", rowNumber);
            rowNumber = memorySupportSectionBuilder.BuildActualSection(ws, rowNumber);
            rowNumber = memorySupportSectionBuilder.BuildBudgetSection(ws, rowNumber);

            rowNumber = OccupancySectionBuilder.BuildSectionHeader(ws, "Skilled Nursing Occupancy Statistics", rowNumber);
            rowNumber = skilledNursingSectionBuilder.BuildActualSection(ws, rowNumber);
            skilledNursingSectionBuilder.BuildBudgetSection(ws, rowNumber);

        }

        private static void BuildWLRReport(DateTime reportDate, ExcelWorksheet ws)
        {
            IndependentLivingSectionBuilder independentLivingSectionBuilder = new IndependentLivingSectionBuilder(LocationCode.IKF, reportDate);
            WLRAssistedLivingSectionBuilder assistedLivingSectionBuilder = new WLRAssistedLivingSectionBuilder(reportDate);
            WLRSkilledNurseSectionBuilder skilledNursingSectionBuilder = new WLRSkilledNurseSectionBuilder(reportDate);

            int rowNumber = 1;

            Location location = OccupancyReportDAO.GetLocation(LocationCode.WLR);
            rowNumber = OccupancySectionBuilder.BuildPageHeader(ws, location.Name, reportDate, rowNumber);

            rowNumber = OccupancySectionBuilder.BuildSectionHeader(ws, "Independent Living Occupancy Statistics", rowNumber);
            rowNumber = independentLivingSectionBuilder.BuildActualSection(ws, rowNumber);

            rowNumber = OccupancySectionBuilder.BuildSectionHeader(ws, "Apartments", rowNumber);
            rowNumber = independentLivingSectionBuilder.BuildApartmentsSection(ws, rowNumber);

            rowNumber = OccupancySectionBuilder.BuildSectionHeader(ws, "Cottages", rowNumber);
            rowNumber = independentLivingSectionBuilder.BuildCottagesSection(ws, rowNumber);

            rowNumber = independentLivingSectionBuilder.BuildBudgetSection(ws, rowNumber);

            rowNumber = OccupancySectionBuilder.BuildSectionHeader(ws, "Assisted Living Occupancy Statistics", rowNumber);
            rowNumber = assistedLivingSectionBuilder.BuildActualSection(ws, rowNumber);
            rowNumber = assistedLivingSectionBuilder.BuildBudgetSection(ws, rowNumber);

            rowNumber = OccupancySectionBuilder.BuildSectionHeader(ws, "Skilled Nursing Occupancy Statistics", rowNumber);
            rowNumber = skilledNursingSectionBuilder.BuildActualSection(ws, rowNumber);
            skilledNursingSectionBuilder.BuildBudgetSection(ws, rowNumber);
        }
    }
}
