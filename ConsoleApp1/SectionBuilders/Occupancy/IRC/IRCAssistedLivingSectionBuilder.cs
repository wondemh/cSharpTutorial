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
            List<String> facilityTypeCodes = new List<string> { "HC" };

            assistedLivingActual = new IRCAssistedLivingActual
            {
                UnitsAvailable = OccupancyReportDAO.GetUnitsAvailableData(LocationCodes.IRC, facilityTypeCodes),
                LicensedFor = new OccupancyRecord(),
                AverageFFSFirst = AssistedLivingDAO.GetAverageFFS(LocationCodes.IRC, facilityTypeCodes, reportDate),
                AverageFFSSecond = AssistedLivingDAO.GetAverageFFS(LocationCodes.IRC, facilityTypeCodes, reportDate),
                AverageLCFirst = AssistedLivingDAO.GetAverageLC(LocationCodes.IRC, facilityTypeCodes, reportDate),
                AverageLCSecond = AssistedLivingDAO.GetAverageLC(LocationCodes.IRC, facilityTypeCodes, reportDate),
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
            rowNumber = BuildGridRow(ws, assistedLivingActual.UnitsAvailable, "Units Available:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingActual.LicensedFor, "Licensed For:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingActual.AverageFFSFirst, "Average FFS 1st:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingActual.AverageFFSSecond, "Average FFS 2nd:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingActual.AverageLCFirst, "Average LC 1st:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingActual.AverageLCSecond, "Average LC 2nd:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingActual.EndingAverageOccupancy, "Ending Avg. Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingActual.PercentUnitOccupancy, "% Unit Occupancy:", rowNumber, "0%");
            rowNumber = BuildGridRow(ws, assistedLivingActual.EndingAveragePersonOccupancy, "Ending Avg. Person Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingActual.PercentLicensedOccupancy, "% Licensed Occupancy:", rowNumber, "0%");

            //This adds the sidebar
            BuildSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);

            return ++rowNumber;
        }

        internal int BuildBudgetSection(ExcelWorksheet ws, int rowNumber)
        {
            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingBudget.AverageFFSFirst, "Average FFS 1st:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingBudget.AverageFFSSecond, "Average FFS 2nd:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingBudget.AverageLCFirst, "Averaget LC 1st:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingBudget.AverageLCSecond, "Averaget LC 2nd:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingBudget.EndingAverageOccupancy, "Ending Avg. Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingBudget.EndingAverageOccupancyVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingBudget.EndingAveragePersonOccupancy, "Ending Avg. Person Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingBudget.EndingAveragePersonOccupancyVarianceFromBudget, "Variance from Budget:", rowNumber);

            //This adds the sidebar
            BuildSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return rowNumber;
        }

    }
}
