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
    internal class IRCAssistedLivingSectionBuilder : OccupancySectionBuilder
    {
        private readonly IRCAssistedLivingActual assistedLivingActual;
        private readonly IRCAssistedLivingBudget assistedLivingBudget;

        internal IRCAssistedLivingSectionBuilder(DateTime reportDate)
        {
            this.ReportDate = reportDate;
            List<String> facilityTypeCodes = new List<string> { "AL" };

            assistedLivingActual = new IRCAssistedLivingActual
            {
                UnitsAvailable = OccupancyReportDAO.GetUnitsAvailableData(LocationCode.IRC, facilityTypeCodes),
                AverageFFSFirst = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.IRC, facilityTypeCodes, reportDate, new List<string> { "F11", "F21", "F31" }),
                AverageFFSSecond = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.IRC, facilityTypeCodes, reportDate, new List<string> { "F12", "F22", "F32" }),
                AverageLCFirst = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.IRC, facilityTypeCodes, reportDate, new List<string> { "L11", "L21", "L31", "M11", "M21", "M31" }),
                AverageLCSecond = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.IRC, facilityTypeCodes, reportDate, new List<string> { "L12", "L22", "L32", "M12", "M22", "M32" }),
            };

            assistedLivingBudget = new IRCAssistedLivingBudget
            {
                AssistedLivingActual = assistedLivingActual,
                AverageFFSFirst = new OccupancyRecord(),
                AverageFFSSecond = new OccupancyRecord(),
                AverageLCFirst = new OccupancyRecord(),
                AverageLCSecond = new OccupancyRecord()
            };
        }

        internal int BuildActualSection(ExcelWorksheet ws, int rowNumber)
        {
            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingActual.UnitsAvailable, "Units Available:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, IRCAssistedLivingActual.LicensedFor, "Licensed For:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, assistedLivingActual.AverageFFSFirst, "Average FFS 1st:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, assistedLivingActual.AverageFFSSecond, "Average FFS 2nd:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, assistedLivingActual.AverageLCFirst, "Average LC 1st:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, assistedLivingActual.AverageLCSecond, "Average LC 2nd:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, assistedLivingActual.EndingAverageOccupancy, "Ending Avg. Occupancy:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, assistedLivingActual.PercentUnitOccupancy, "% Unit Occupancy:", rowNumber, "0\\%");
            rowNumber = BuildGridRow(ws, assistedLivingActual.EndingAveragePersonOccupancy, "Ending Avg. Person Occupancy:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, assistedLivingActual.PercentLicensedOccupancy, "% Licensed Occupancy:", rowNumber, "0\\%");

            //This adds the sidebar
            BuildSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);

            return ++rowNumber;
        }

        internal int BuildBudgetSection(ExcelWorksheet ws, int rowNumber)
        {
            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingBudget.AverageFFSFirst, "Average FFS 1st:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, assistedLivingBudget.AverageFFSSecond, "Average FFS 2nd:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, assistedLivingBudget.AverageLCFirst, "Averaget LC 1st:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, assistedLivingBudget.AverageLCSecond, "Averaget LC 2nd:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, assistedLivingBudget.EndingAverageOccupancy, "Ending Avg. Occupancy:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, assistedLivingBudget.EndingAverageOccupancyVarianceFromBudget, "Variance from Budget:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, assistedLivingBudget.EndingAveragePersonOccupancy, "Ending Avg. Person Occupancy:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, assistedLivingBudget.EndingAveragePersonOccupancyVarianceFromBudget, "Variance from Budget:", rowNumber, "0");

            //This adds the sidebar
            BuildSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return ++rowNumber;
        }

    }
}
