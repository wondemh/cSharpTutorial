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
    public class MemorySupportSectionBuilder : OccupancySectionBuilder
    {

        internal static int AddMemorySupportSection(ExcelWorksheet ws, int locationId, DateTime reportDate, int rowNumber)
        {
            List<string> facilityTypeCodes = new List<string> { "MS" };
            rowNumber = AddSectionHeader(ws, "Assisted Living Memory Support Occupancy Statistics", rowNumber);
            rowNumber = AddActualSection(ws, locationId, reportDate, facilityTypeCodes, rowNumber);
            rowNumber = AddBudgetSection(ws, locationId, reportDate, facilityTypeCodes, ++rowNumber);
            return rowNumber;
        }

        private static int AddActualSection(ExcelWorksheet ws, int locationId, DateTime reportDate, List<string> facilityTypeCodes, int rowNumber)
        {
            MemorySupportActual assistedLivingMemorySupport = new MemorySupportActual
            {
                UnitsAvailable = OccupancyReportDAO.GetUnitsAvailableData(locationId, facilityTypeCodes),
                LicensedFor = MemorySupportDAO.GetLicensedForData(locationId, facilityTypeCodes),
                PrivateMCFirstPerson = MemorySupportDAO.GetPrivateMCFirstPersonData(locationId, facilityTypeCodes),
                PrivateMCSecondPerson = MemorySupportDAO.GetPrivateMCSecondPersonData(locationId, facilityTypeCodes),
            };

            int startRowNumber = rowNumber;
            rowNumber = AddColumnHeaders(ws, rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingMemorySupport.UnitsAvailable, "Units Available:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingMemorySupport.LicensedFor, "Licensed For:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingMemorySupport.PrivateMCFirstPerson, "Private - MC - 1st Person:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingMemorySupport.PrivateMCSecondPerson, "Private - MC - 2nd Person:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingMemorySupport.EndingAverageOccupancy, "Ending Avg.Occupancy:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingMemorySupport.PercentAverageUnitOccupancy, "% Avg.Unit Occupancy:", rowNumber, "0%");
            rowNumber = AddGridRow(ws, assistedLivingMemorySupport.AverageUnoccupiedUnits, "Avg.Unoccupied Units:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingMemorySupport.EndingAveragePersonOccupancy, "Ending Avg. Person Occupancy:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingMemorySupport.PercentLicensedOccupancy, "% Licensed Occupancy:", rowNumber, "0%");

            //This adds the sidebar
            AddSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);

            return rowNumber;
        }

        private static int AddBudgetSection(ExcelWorksheet ws, int locationId, DateTime reportDate, List<string> facilityTypeCodes, int rowNumber)
        {
            
            MemorySupportBudget memorySupportBudget = new MemorySupportBudget
            {
                PrivateMCFirstPerson = new OccupancyRecord(),
                PrivateMCSecondtPerson = new OccupancyRecord(),
                EndingAverageOccupancy = new OccupancyRecord(),
                EndingAverageOccupancyVarianceFromBudget = new OccupancyRecord(),
                EndingAvgPersonOccupancy = new OccupancyRecord(),
                EndingAvgPersonOccupancyVarianceFromBudget = new OccupancyRecord()
            };

            int startRowNumber = rowNumber;
            rowNumber = AddColumnHeaders(ws, rowNumber);
            rowNumber = AddGridRow(ws, memorySupportBudget.PrivateMCFirstPerson, "Private - MC - 1st Person:", rowNumber);
            rowNumber = AddGridRow(ws, memorySupportBudget.PrivateMCSecondtPerson, "Private - MC - 2nd Person:", rowNumber);
            rowNumber = AddGridRow(ws, memorySupportBudget.EndingAverageOccupancy, "Ending Avg. Occupancy:", rowNumber);
            rowNumber = AddGridRow(ws, memorySupportBudget.EndingAverageOccupancyVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = AddGridRow(ws, memorySupportBudget.EndingAvgPersonOccupancy, "Ending Avg. Person Occupancy:", rowNumber);
            rowNumber = AddGridRow(ws, memorySupportBudget.EndingAvgPersonOccupancyVarianceFromBudget, "Variance from Budget:", rowNumber, "0%");

            //This adds the sidebar
            AddSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return rowNumber;
        }
    }
}
