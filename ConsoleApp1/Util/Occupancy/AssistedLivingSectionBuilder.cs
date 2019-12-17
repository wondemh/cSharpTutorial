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

        internal static int AddAssistedLivingSection(ExcelWorksheet ws, int locationId, int rowNumber)
        {
            List<string> facilityTypeCodes = new List<string> { "AL" };
            AssistedLivingStats assistedLivingStats = new AssistedLivingStats
            {
                UnitsAvailable = OccupancyReportDAO.GetUnitsAvailableData(locationId, facilityTypeCodes),
                AverageFFS = AssistedLivingDAO.GetAverageFFS(locationId, facilityTypeCodes),
                AverageLC = AssistedLivingDAO.GetAverageLC(),
            };

            rowNumber = AddSectionHeader(ws, "Assisted Living Occupancy Statistics", rowNumber);
            rowNumber = AddColumnHeaders(ws, rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingStats.UnitsAvailable, "Units Available:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingStats.AverageFFS, "Average FFS:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingStats.AverageLC, "Average LC:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingStats.AverageOccupancy, "Average Occupancy:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingStats.PercentUnitOccupancy, "% Unit Occupancy:", rowNumber, "0%");
            rowNumber = AddGridRow(ws, assistedLivingStats.UnoccupiedUnits, "Unoccupied Units:", rowNumber);

            return rowNumber;
        }

    }
}
