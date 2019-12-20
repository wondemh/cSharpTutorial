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
    public class AssistedLivingSectionBuilder : OccupancySectionBuilder
    {

        internal static int AddAssistedLivingSection(ExcelWorksheet ws, LocationCodes locationId, DateTime reportDate, int rowNumber)
        {
            List<string> facilityTypeCodes = new List<string> { "AL" };
            rowNumber = AddSectionHeader(ws, "Assisted Living Occupancy Statistics", rowNumber);
            rowNumber = AddActualSection(ws, locationId, reportDate, facilityTypeCodes, rowNumber);
            rowNumber = AddBudgetSection(ws, locationId, reportDate, facilityTypeCodes, ++rowNumber);
            return rowNumber;
        }

        private static int AddActualSection(ExcelWorksheet ws, LocationCodes locationId, DateTime reportDate, List<string> facilityTypeCodes, int rowNumber)
        {
           
            WLRAssistedLivingActual assistedLivingStats = new WLRAssistedLivingActual
            {
                UnitsAvailable = OccupancyReportDAO.GetUnitsAvailableData(locationId, facilityTypeCodes),
                AverageFFS = AssistedLivingDAO.GetAverageFFS(locationId, facilityTypeCodes, reportDate),
                AverageLC = AssistedLivingDAO.GetAverageLC(locationId, facilityTypeCodes, reportDate),
            };

            int startRowNumber = rowNumber;
            rowNumber = AddColumnHeaders(ws, rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingStats.UnitsAvailable, "Units Available:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingStats.AverageFFS, "Average FFS:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingStats.AverageLC, "Average LC:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingStats.AverageOccupancy, "Average Occupancy:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingStats.PercentUnitOccupancy, "% Unit Occupancy:", rowNumber, "0%");
            rowNumber = AddGridRow(ws, assistedLivingStats.UnoccupiedUnits, "Unoccupied Units:", rowNumber);

            //This adds the sidebar
            AddSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);

            return ++rowNumber;
        }

        private static int AddBudgetSection(ExcelWorksheet ws, int locationId, DateTime reportDate, List<string> facilityTypeCodes, int rowNumber)
        {
            WLRAssistedLivingBudget independentLivingBudget = new WLRAssistedLivingBudget
            {
                AverageFFSFirst = new OccupancyRecord(),
                AverLCFirst = new OccupancyRecord(),
                EndingAverageOccupance = new OccupancyRecord(),
                PercentOccupancy = new OccupancyRecord(),
                VarianceFromBudget = new OccupancyRecord()
            };

            int startRowNumber = rowNumber;
            rowNumber = AddColumnHeaders(ws, rowNumber);
            rowNumber = AddGridRow(ws, independentLivingBudget.AverageFFSFirst, "Average FFS 1st:", rowNumber);
            rowNumber = AddGridRow(ws, independentLivingBudget.AverLCFirst, "Averaget LC 1st:", rowNumber);
            rowNumber = AddGridRow(ws, independentLivingBudget.EndingAverageOccupance, "Ending Avg. Occupancy:", rowNumber);
            rowNumber = AddGridRow(ws, independentLivingBudget.VarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = AddGridRow(ws, independentLivingBudget.PercentOccupancy, "% Occupancy:", rowNumber, "0%");

            //This adds the sidebar
            AddSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return rowNumber;
        }

    }
}
