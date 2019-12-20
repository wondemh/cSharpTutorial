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
    public class IKFMemorySupportSectionBuilder : OccupancySectionBuilder
    {

        //internal static int AddMemorySupportSection(ExcelWorksheet ws, int locationId, DateTime reportDate, int rowNumber)
        //{
        //    List<string> facilityTypeCodes = new List<string> { "MS" };
        //    rowNumber = BuildSectionHeader(ws, "Assisted Living Memory Support Occupancy Statistics", rowNumber);
        //    rowNumber = AddActualSection(ws, locationId, reportDate, facilityTypeCodes, rowNumber);
        //    rowNumber = AddBudgetSection(ws, locationId, reportDate, facilityTypeCodes, ++rowNumber);
        //    return rowNumber;
        //}

        internal override int BuildActualSection(ExcelWorksheet ws, LocationCodes locationId, DateTime reportDate, List<string> facilityTypeCodes, int rowNumber)
        {
            IKFMemorySupportActual ikfMemorySupport = new IKFMemorySupportActual
            {
                UnitsAvailable = OccupancyReportDAO.GetUnitsAvailableData(locationId, facilityTypeCodes),
                LicensedFor = MemorySupportDAO.GetLicensedForData(locationId, facilityTypeCodes),
                PrivateMCFirstPerson = MemorySupportDAO.GetPrivateMCFirstPersonData(locationId, facilityTypeCodes),
                PrivateMCSecondPerson = MemorySupportDAO.GetPrivateMCSecondPersonData(locationId, facilityTypeCodes),
            };

            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, ikfMemorySupport.UnitsAvailable, "Units Available:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfMemorySupport.LicensedFor, "Licensed For:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfMemorySupport.PrivateMCFirstPerson, "Private - MC - 1st Person:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfMemorySupport.PrivateMCSecondPerson, "Private - MC - 2nd Person:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfMemorySupport.EndingAverageOccupancy, "Ending Avg.Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfMemorySupport.PercentAverageUnitOccupancy, "% Avg.Unit Occupancy:", rowNumber, "0%");
            rowNumber = BuildGridRow(ws, ikfMemorySupport.AverageUnoccupiedUnits, "Avg.Unoccupied Units:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfMemorySupport.EndingAveragePersonOccupancy, "Ending Avg. Person Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfMemorySupport.PercentLicensedOccupancy, "% Licensed Occupancy:", rowNumber, "0%");

            //This adds the sidebar
            BuildSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);

            return rowNumber;
        }

        internal override int BuildBudgetSection(ExcelWorksheet ws, LocationCodes locationId, DateTime reportDate, List<string> facilityTypeCodes, int rowNumber)
        {
            
            IKFMemorySupportBudget ikfMemorySupportBudget = new IKFMemorySupportBudget
            {
                PrivateMCFirstPerson = new OccupancyRecord(),
                PrivateMCSecondtPerson = new OccupancyRecord(),
                EndingAverageOccupancy = new OccupancyRecord(),
                EndingAverageOccupancyVarianceFromBudget = new OccupancyRecord(),
                EndingAvgPersonOccupancy = new OccupancyRecord(),
                EndingAvgPersonOccupancyVarianceFromBudget = new OccupancyRecord()
            };

            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, ikfMemorySupportBudget.PrivateMCFirstPerson, "Private - MC - 1st Person:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfMemorySupportBudget.PrivateMCSecondtPerson, "Private - MC - 2nd Person:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfMemorySupportBudget.EndingAverageOccupancy, "Ending Avg. Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfMemorySupportBudget.EndingAverageOccupancyVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfMemorySupportBudget.EndingAvgPersonOccupancy, "Ending Avg. Person Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfMemorySupportBudget.EndingAvgPersonOccupancyVarianceFromBudget, "Variance from Budget:", rowNumber, "0%");

            //This adds the sidebar
            BuildSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return rowNumber;
        }
    }
}
