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
    public class IKFAssistedLivingSectionBuilder : OccupancySectionBuilder
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
           
            IKFAssistedLivingActual ikfAssistedLivingStats = new IKFAssistedLivingActual
            {
                UnitsAvailable = OccupancyReportDAO.GetUnitsAvailableData(locationId, facilityTypeCodes),
                AverageFFS = AssistedLivingDAO.GetAverageFFS(locationId, facilityTypeCodes, reportDate),
                AverageLC = AssistedLivingDAO.GetAverageLC(locationId, facilityTypeCodes, reportDate),
            };

            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, ikfAssistedLivingStats.UnitsAvailable, "Units Available:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfAssistedLivingStats.AverageFFS, "Average FFS:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfAssistedLivingStats.AverageLC, "Average LC:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfAssistedLivingStats.AverageOccupancy, "Average Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfAssistedLivingStats.PercentUnitOccupancy, "% Unit Occupancy:", rowNumber, "0%");
            rowNumber = BuildGridRow(ws, ikfAssistedLivingStats.UnoccupiedUnits, "Unoccupied Units:", rowNumber);

            //This adds the sidebar
            BuildSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);

            return ++rowNumber;
        }

        internal override int BuildBudgetSection(ExcelWorksheet ws, LocationCodes locationId, DateTime reportDate, List<string> facilityTypeCodes, int rowNumber)
        {
            IKFAssistedLivingBudget ikfAssistedLivingBudget = new IKFAssistedLivingBudget
            {
                AverageFFSFirst = new OccupancyRecord(),
                AverLCFirst = new OccupancyRecord(),
                EndingAverageOccupance = new OccupancyRecord(),
                PercentOccupancy = new OccupancyRecord(),
                VarianceFromBudget = new OccupancyRecord()
            };

            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, ikfAssistedLivingBudget.AverageFFSFirst, "Average FFS 1st:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfAssistedLivingBudget.AverLCFirst, "Averaget LC 1st:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfAssistedLivingBudget.EndingAverageOccupance, "Ending Avg. Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfAssistedLivingBudget.VarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfAssistedLivingBudget.PercentOccupancy, "% Occupancy:", rowNumber, "0%");

            //This adds the sidebar
            BuildSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return rowNumber;
        }

    }
}
