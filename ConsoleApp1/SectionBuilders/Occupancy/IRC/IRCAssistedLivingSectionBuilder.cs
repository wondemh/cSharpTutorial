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
    public class IRCAssistedLivingSectionBuilder : OccupancySectionBuilder
    {

        //internal static int AddAssistedLivingSection(ExcelWorksheet ws, LocationCodes locationId, DateTime reportDate, int rowNumber)
        //{
        //    List<string> facilityTypeCodes = new List<string> { "AL" };
        //    rowNumber = BuildSectionHeader(ws, "Assisted Living Occupancy Statistics", rowNumber);
        //    rowNumber = BuildActualSection(ws, locationId, reportDate, facilityTypeCodes, rowNumber);
        //    rowNumber = BuildBudgetSection(ws, locationId, reportDate, facilityTypeCodes, ++rowNumber);
        //    return rowNumber;
        //}

        internal override int BuildActualSection(ExcelWorksheet ws, LocationCodes locationId, DateTime reportDate, List<string> facilityTypeCodes, int rowNumber)
        {
           
            IRCAssistedLivingActual ircAssistedLivingStats = new IRCAssistedLivingActual
            {
                UnitsAvailable = OccupancyReportDAO.GetUnitsAvailableData(locationId, facilityTypeCodes),
                AverageFFS = AssistedLivingDAO.GetAverageFFS(locationId, facilityTypeCodes, reportDate),
                AverageLC = AssistedLivingDAO.GetAverageLC(locationId, facilityTypeCodes, reportDate),
            };

            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, ircAssistedLivingStats.UnitsAvailable, "Units Available:", rowNumber);
            rowNumber = BuildGridRow(ws, ircAssistedLivingStats.AverageFFS, "Average FFS:", rowNumber);
            rowNumber = BuildGridRow(ws, ircAssistedLivingStats.AverageLC, "Average LC:", rowNumber);
            rowNumber = BuildGridRow(ws, ircAssistedLivingStats.AverageOccupancy, "Average Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, ircAssistedLivingStats.PercentUnitOccupancy, "% Unit Occupancy:", rowNumber, "0%");
            rowNumber = BuildGridRow(ws, ircAssistedLivingStats.UnoccupiedUnits, "Unoccupied Units:", rowNumber);

            //This adds the sidebar
            BuildSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);

            return ++rowNumber;
        }

        internal override int BuildBudgetSection(ExcelWorksheet ws, LocationCodes locationId, DateTime reportDate, List<string> facilityTypeCodes, int rowNumber)
        {
            IRCAssistedLivingBudget ircAssistedLivingBudget = new IRCAssistedLivingBudget
            {
                AverageFFSFirst = new OccupancyRecord(),
                AverLCFirst = new OccupancyRecord(),
                EndingAverageOccupance = new OccupancyRecord(),
                PercentOccupancy = new OccupancyRecord(),
                VarianceFromBudget = new OccupancyRecord()
            };

            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, ircAssistedLivingBudget.AverageFFSFirst, "Average FFS 1st:", rowNumber);
            rowNumber = BuildGridRow(ws, ircAssistedLivingBudget.AverLCFirst, "Averaget LC 1st:", rowNumber);
            rowNumber = BuildGridRow(ws, ircAssistedLivingBudget.EndingAverageOccupance, "Ending Avg. Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, ircAssistedLivingBudget.VarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = BuildGridRow(ws, ircAssistedLivingBudget.PercentOccupancy, "% Occupancy:", rowNumber, "0%");

            //This adds the sidebar
            BuildSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return rowNumber;
        }

    }
}
