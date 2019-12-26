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
                AverageFFS = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.WLR, facilityTypeCodes, reportDate, new List<string> { "FFH1", "FFS1", "FFS2", "RESP" }),
                AverageLC = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.WLR, facilityTypeCodes, reportDate, new List<string> { "A11", "A12", "A12D", "A1DL", "A1DN", "AL11", "C11", "C12", "C12D", "FREE", "LIF1", "LIF2", "TLC1", "TLC2" }),
            };

            assistedLivingBudget = new WLRAssistedLivingBudget
            {
                AssistedLivingActual = assistedLivingActual,
                AverageFFSFirst = OccupancyReportDAO.GetBudgetData(LocationCode.IRC, "AL", "Private - FFS Level 1", 2020),
                AverageLCFirst = OccupancyReportDAO.GetBudgetData(LocationCode.IRC, "AL", "Private - LC Level 1", 2020),
            };

        }

        internal int BuildActualSection(ExcelWorksheet ws, int rowNumber)
        {

            rowNumber = BuildColumnHeaders(ws, rowNumber);
            int startRowNumber = rowNumber;
            DrawRowBottomBorder(ws, rowNumber - 1);
            rowNumber = BuildGridRow(ws, assistedLivingActual.UnitsAvailable, "Units Available:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingActual.AverageFFS, "Average FFS:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, assistedLivingActual.AverageLC, "Average LC:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, assistedLivingActual.AverageOccupancy, "Average Occupancy:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, assistedLivingActual.PercentUnitOccupancy, "% Unit Occupancy:", rowNumber, "0\\%");
            rowNumber = BuildGridRow(ws, assistedLivingActual.UnoccupiedUnits, "Unoccupied Units:", rowNumber, "0");
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
            rowNumber = BuildGridRow(ws, assistedLivingBudget.AverageFFSFirst, "Average FFS 1st:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, assistedLivingBudget.AverageLCFirst, "Averaget LC 1st:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, assistedLivingBudget.EndingAverageOccupancy, "Ending Avg. Occupancy:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, assistedLivingBudget.VarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingBudget.PercentOccupancy, "% Occupancy:", rowNumber, "0.0\\%");
            DrawRowBottomBorder(ws, rowNumber - 1);

            //This adds the sidebar
            BuildSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return ++rowNumber;
        }

    }
}
