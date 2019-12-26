using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;

using ReportApp.Model;
using ReportApp.DAO;
using ReportApp.Model.Occupancy;

namespace ReportApp
{
    internal class IRCMemorySupportSectionBuilder : OccupancySectionBuilder
    {
        private readonly IRCMemorySupportActual memorySupportActual;
        private readonly IRCMemorySupportBudget memorySupportBudget;

        internal IRCMemorySupportSectionBuilder(DateTime reportDate)
        {
            this.ReportDate = reportDate;
            List<string> facilityTypeCodes = new List<string> { "MS" };

            memorySupportActual = new IRCMemorySupportActual
            {
                UnitsAvailable = OccupancyReportDAO.GetUnitsAvailableData(LocationCode.IKF, facilityTypeCodes),
                AverageMSFFSFirst = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.IRC, facilityTypeCodes, reportDate, new List<string> { "F11", "F21", "F31" }),
                AverageMSFFSSecond = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.IRC, facilityTypeCodes, reportDate, new List<string> { "F11", "F21", "F31" }),
                AverageMSLCFirst = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.IRC, facilityTypeCodes, reportDate, new List<string> { "L11", "L21", "L31", "M11", "M21", "M31" }),
                AverageMSLCSecond = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.IRC, facilityTypeCodes, reportDate, new List<string> { "L11", "L21", "L31", "M11", "M21", "M31" }),
            };

            memorySupportBudget = new IRCMemorySupportBudget
            {
                MemorySupportActual = memorySupportActual,
                AverageMSFFSFirst = OccupancyReportDAO.GetBudgetData(LocationCode.IRC, "MS", "Private -MC - 1st Person", 2020),
                AverageMSFFSSecond = OccupancyReportDAO.GetBudgetData(LocationCode.IRC, "MS", "Private -MC - 2nd Person", 2020),
                AverageMSLCFirst = OccupancyReportDAO.GetBudgetData(LocationCode.IRC, "MS", "Life Care - MC - 1st Person", 2020),
                AverageMSLCSecond = OccupancyReportDAO.GetBudgetData(LocationCode.IRC, "MS", "Life Care - MC - 2nd Person", 2020)
            };
        }

        internal int BuildActualSection(ExcelWorksheet ws, int rowNumber)
        {
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            int startRowNumber = rowNumber;
            DrawRowBottomBorder(ws, rowNumber - 1);
            rowNumber = BuildGridRow(ws, memorySupportActual.UnitsAvailable, "Units Available:", rowNumber);
            rowNumber = BuildGridRow(ws, IRCMemorySupportActual.LicensedFor, "Licensed For:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportActual.AverageMSFFSFirst, "Average MS FFS 1st:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, memorySupportActual.AverageMSFFSSecond, "Average MS FFS 2nd:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, memorySupportActual.AverageMSLCFirst, "Average MS LC 1st:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, memorySupportActual.AverageMSLCSecond, "Average MS LC 2nd:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, memorySupportActual.EndingAverageOccupancy, "Ending Avg. Occupancy:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, memorySupportActual.PercentUnitOccupancy, "% Unit Occupancy:", rowNumber, "0\\%");
            rowNumber = BuildGridRow(ws, memorySupportActual.UnoccupiedUnits, "Unoccupied Units:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, memorySupportActual.EndingAveragePersonOccupancy, "Ending Avg. Person Occupancy:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, memorySupportActual.PercentLicensedOccupancy, "% Licensed Occupancy:", rowNumber, "0\\%");
            DrawRowBottomBorder(ws, rowNumber - 1);

            //This adds the sidebar
            BuildSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);

            return ++rowNumber;
        }

        internal int BuildBudgetSection(ExcelWorksheet ws, int rowNumber)
        {
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            int startRowNumber = rowNumber;
            DrawRowBottomBorder(ws, rowNumber - 1);
            rowNumber = BuildGridRow(ws, memorySupportBudget.AverageMSFFSFirst, "Average MS FFS 1st:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, memorySupportBudget.AverageMSFFSSecond, "Average MS FFS 2nd:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, memorySupportBudget.AverageMSLCFirst, "Average MS LC 2st:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, memorySupportBudget.AverageMSLCSecond, "Average MS LC 2nd:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, memorySupportBudget.EndingAverageOccupancy, "Ending Avg. Occupancy:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, memorySupportBudget.EndingAverageOccupancyVarianceFromBudget, "Variance from Budget:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, memorySupportBudget.EndingAveragePersonOccupancy, "Ending Avg. Person Occupancy:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, memorySupportBudget.EndingAvgPersonOccupancyVarianceFromBudget, "Variance from Budget:", rowNumber, "0\\%");
            DrawRowBottomBorder(ws, rowNumber - 1);

            //This adds the sidebar
            BuildSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return ++rowNumber;
        }
    }
}
