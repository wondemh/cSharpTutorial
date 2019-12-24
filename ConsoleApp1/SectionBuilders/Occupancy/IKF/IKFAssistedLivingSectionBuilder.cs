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
    internal class IKFAssistedLivingSectionBuilder : OccupancySectionBuilder
    {
        private readonly IKFAssistedLivingActual assistedLivingActual;
        private readonly IKFAssistedLivingBudget assistedLivingBudget;

        internal IKFAssistedLivingSectionBuilder(DateTime reportDate)
        {
            ReportDate = reportDate;
            List<string> facilityTypeCodes = new List<string> { "AL" };

            assistedLivingActual = new IKFAssistedLivingActual
            {
                UnitsAvailable = OccupancyReportDAO.GetUnitsAvailableData(LocationCode.IKF, facilityTypeCodes),
                AverageLevelOne  = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.IRC, facilityTypeCodes, reportDate, new List<string> { "AL11" }),
                AverageLevelTwo = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.IRC, facilityTypeCodes, reportDate, new List<string> { "AL12" }),
                AverageLevelThree = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.IRC, facilityTypeCodes, reportDate, new List<string> { "AL13" }),
                AverageSecondPerson = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.IRC, facilityTypeCodes, reportDate, new List<string> { "AL23" })
            };

            assistedLivingBudget = new IKFAssistedLivingBudget
            {
                AssistedLivingActual = assistedLivingActual,
                AverageLevelOne = new OccupancyRecord(),
                AverageLevelTwo = new OccupancyRecord(),
                AverageLevelThree = new OccupancyRecord(),
                AverageSecondPerson = new OccupancyRecord()
            };
        }

        internal int BuildActualSection(ExcelWorksheet ws, int rowNumber)
        {
            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingActual.UnitsAvailable, "Units Available:", rowNumber);
            rowNumber = BuildGridRow(ws, IKFAssistedLivingActual.LicensedFor, "Licensed For:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingActual.AverageLevelOne, "Average Level 1:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, assistedLivingActual.AverageLevelTwo, "Average Level 2:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, assistedLivingActual.AverageLevelThree, "Average Level 3:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, assistedLivingActual.AverageSecondPerson, "Avg. 2nd Person:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, assistedLivingActual.EndingAverageOccupancy, "Ending Avg. Occupancy:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, assistedLivingActual.PercentAverageUnitOccupancy, "% Avg. Unit Occupancy:", rowNumber, "0\\%");
            rowNumber = BuildGridRow(ws, assistedLivingActual.AverageUnoccupiedUnits, "Avg. Unoccupied Units:", rowNumber, "0");
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
            rowNumber = BuildGridRow(ws, assistedLivingBudget.AverageLevelOne, "Avg. Level 1:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, assistedLivingBudget.AverageLevelTwo, "Avg. Level 2:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, assistedLivingBudget.AverageLevelThree, "Avg. Level 3:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, assistedLivingBudget.AverageSecondPerson, "Avg. 2nd Person:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, assistedLivingBudget.EndingAverageOccupancy, "Ending Avg. Occupancy:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, assistedLivingBudget.EndingAverageOccupancyVarianceFromBudget, "Variance from Budget:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, assistedLivingBudget.EndingAveragePersonOccupancy, "Ending Avg. Person Occupancy:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, assistedLivingBudget.EndingAveragePersonOccupancyVarianceFromBudget, "Variance from Budget:", rowNumber, "0.0");

            //This adds the sidebar
            BuildSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return ++rowNumber;
        }
    }
}
