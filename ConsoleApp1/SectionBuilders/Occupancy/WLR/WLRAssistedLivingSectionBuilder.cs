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
    public class WLRAssistedLivingSectionBuilder : OccupancySectionBuilder
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
           
            WLRAssistedLivingActual assistedLivingActual = new WLRAssistedLivingActual
            {
                UnitsAvailable = OccupancyReportDAO.GetUnitsAvailableData(locationId, facilityTypeCodes),
                AverageFFS = AssistedLivingDAO.GetAverageFFS(locationId, facilityTypeCodes, reportDate),
                AverageLC = AssistedLivingDAO.GetAverageLC(locationId, facilityTypeCodes, reportDate),
            };

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

        internal override int BuildBudgetSection(ExcelWorksheet ws, LocationCodes locationId, DateTime reportDate, List<string> facilityTypeCodes, int rowNumber)
        {
            WLRAssistedLivingBudget assistedLivingBudget = new WLRAssistedLivingBudget
            {
                AverageFFSFirst = new OccupancyRecord(),
                AverageLCFirst = new OccupancyRecord(),
                EndingAverageOccupance = new OccupancyRecord(),
                PercentOccupancy = new OccupancyRecord(),
                VarianceFromBudget = new OccupancyRecord()
            };

            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingBudget.AverageFFSFirst, "Average FFS 1st:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingBudget.AverageLCFirst, "Averaget LC 1st:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingBudget.EndingAverageOccupancy, "Ending Avg. Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingBudget.VarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = BuildGridRow(ws, assistedLivingBudget.PercentOccupancy, "% Occupancy:", rowNumber, "0%");

            //This adds the sidebar
            BuildSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return rowNumber;
        }

    }
}
