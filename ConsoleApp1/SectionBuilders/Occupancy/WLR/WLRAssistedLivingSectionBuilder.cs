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
    internal class WLRAssistedLivingSectionBuilder : OccupancySectionBuilder
    {
        private readonly WLRAssistedLivingActual assistedLivingActual;
        private readonly WLRAssistedLivingBudget assistedLivingBudget;

        internal WLRAssistedLivingSectionBuilder(DateTime reportDate)
        {
            this.ReportDate = reportDate;
            List<String> facilityTypeCodes = new List<string> { "AL" };
            assistedLivingActual = new WLRAssistedLivingActual
            {
                UnitsAvailable = OccupancyReportDAO.GetUnitsAvailableData(LocationCode.WLR, facilityTypeCodes),
                AverageFFS = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.WLR, facilityTypeCodes, new List<string> { "FFH1", "FFS1", "FFS2", "RESP" }, reportDate),
                AverageLC = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.WLR, facilityTypeCodes, new List<string> { "A11", "A12", "A12D", "A1DL", "A1DN", "AL11", "C11", "C12", "C12D", "FREE", "LIF1", "LIF2", "TLC1", "TLC2" }, reportDate),
            };

            assistedLivingBudget = new WLRAssistedLivingBudget
            {
                AssistedLivingActual = assistedLivingActual,
                AverageFFSFirst = new OccupancyRecord(),
                AverageLCFirst = new OccupancyRecord(),
            };

        }

        internal int BuildActualSection(ExcelWorksheet ws, int rowNumber)
        {

            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingActual.UnitsAvailable, "Units Available:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingActual.AverageFFS, "Average FFS:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingActual.AverageLC, "Average LC:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingActual.AverageOccupancy, "Average Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingActual.PercentUnitOccupancy, "% Unit Occupancy:", rowNumber, "0%");
            rowNumber = BuildGridRow(ws, assistedLivingActual.UnoccupiedUnits, "Unoccupied Units:", rowNumber);

            //This adds the sidebar
            BuildSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);

            return ++rowNumber;
        }

        internal int BuildBudgetSection(ExcelWorksheet ws, int rowNumber)
        {
            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingBudget.AverageFFSFirst, "Average FFS 1st:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingBudget.AverageLCFirst, "Averaget LC 1st:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingBudget.EndingAverageOccupancy, "Ending Avg. Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingBudget.VarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingBudget.PercentOccupancy, "% Occupancy:", rowNumber, "0%");

            //This adds the sidebar
            BuildSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return ++rowNumber;
        }

    }
}
