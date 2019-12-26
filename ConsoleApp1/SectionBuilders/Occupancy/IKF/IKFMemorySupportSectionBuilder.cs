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
    internal class IKFMemorySupportSectionBuilder : OccupancySectionBuilder
    {

        private readonly IKFMemorySupportActual memorySupportActual;
        private readonly IKFMemorySupportBudget memorySupportBudget;

        internal IKFMemorySupportSectionBuilder(DateTime reportDate)
        {
            this.ReportDate = reportDate;
            List<string> facilityTypeCodes = new List<string> { "MS" };
            memorySupportActual = new IKFMemorySupportActual
            {
                UnitsAvailable = OccupancyReportDAO.GetUnitsAvailableData(LocationCode.IKF, facilityTypeCodes),
                PrivateMCFirstPerson = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.IRC, facilityTypeCodes, reportDate, new List<string> { "ALMC" }),
                PrivateMCSecondPerson = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.IRC, facilityTypeCodes, reportDate, new List<string> { "ALMC" }),
            };

            memorySupportBudget = new IKFMemorySupportBudget
            {
                MemorySupportActual = memorySupportActual,
                PrivateMCFirstPerson = OccupancyReportDAO.GetBudgetData(LocationCode.IKF, "MS", "Private -MC - 1st Person", 2020),
                PrivateMCSecondPerson = OccupancyReportDAO.GetBudgetData(LocationCode.IKF, "MS", "Private -MC - 2nd Person", 2020)
            };
        }

        internal int BuildActualSection(ExcelWorksheet ws, int rowNumber)
        {

            rowNumber = BuildColumnHeaders(ws, rowNumber);
            int startRowNumber = rowNumber;
            DrawRowBottomBorder(ws, rowNumber - 1);
            rowNumber = BuildGridRow(ws, memorySupportActual.UnitsAvailable, "Units Available:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, IKFMemorySupportActual.LicensedFor, "Licensed For:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, memorySupportActual.PrivateMCFirstPerson, "Private - MC - 1st Person:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, memorySupportActual.PrivateMCSecondPerson, "Private - MC - 2nd Person:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, memorySupportActual.EndingAverageOccupancy, "Ending Avg.Occupancy:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, memorySupportActual.PercentAverageUnitOccupancy, "% Avg.Unit Occupancy:", rowNumber, "0.0\\%");
            rowNumber = BuildGridRow(ws, memorySupportActual.AverageUnoccupiedUnits, "Avg.Unoccupied Units:", rowNumber, "0");
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
            rowNumber = BuildGridRow(ws, memorySupportBudget.PrivateMCFirstPerson, "Private - MC - 1st Person:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, memorySupportBudget.PrivateMCSecondPerson, "Private - MC - 2nd Person:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, memorySupportBudget.EndingAverageOccupancy, "Ending Avg. Occupancy:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, memorySupportBudget.EndingAverageOccupancyVarianceFromBudget, "Variance from Budget:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, memorySupportBudget.EndingAveragePersonOccupancy, "Ending Avg. Person Occupancy:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, memorySupportBudget.EndingAvgPersonOccupancyVarianceFromBudget, "Variance from Budget:", rowNumber, "0.0");
            DrawRowBottomBorder(ws, rowNumber - 1);

            //This adds the sidebar
            BuildSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return ++rowNumber;
        }
    }
}
