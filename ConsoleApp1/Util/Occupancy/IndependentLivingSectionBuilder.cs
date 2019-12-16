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
    public class IndependentLivingSectionBuilder : OccupancySectionBuilder
    {

        internal static int AddIndependentLivingSection(ExcelWorksheet ws, int locationId, DateTime reportDate, int rowNumber)
        {
            List<string> facilityTypeCodes = new List<string> { "IL", "AP", "CO", "PS" };
            IndependentLivingStats independentLivingStats = new IndependentLivingStats
            {
                UnitsAvailable = OccupancyReportDAO.GetUnitsAvailableData(locationId, facilityTypeCodes),
                BeginningOccupancy = IndependentLivingDAO.GetBeginningOccupancyData(locationId, facilityTypeCodes, reportDate.Year),
                MoveIns = IndependentLivingDAO.GetCensusCountsByMonth(locationId, facilityTypeCodes, new List<string> { "A" }, reportDate.Year),
                MoveOuts = IndependentLivingDAO.GetCensusCountsByMonth(locationId, facilityTypeCodes, new List<string> { "D", "DH", "L" }, reportDate.Year),
                Transfers = IndependentLivingDAO.GetCensusCountsByMonth(locationId, facilityTypeCodes, new List<string> { "PT", "TT" }, reportDate.Year)
            };

            rowNumber = AddSectionHeader(ws, "Independent Living Occupancy Statistics", rowNumber);
            rowNumber = AddColumnHeaders(ws, rowNumber);
            rowNumber = AddGridRow(ws, independentLivingStats.UnitsAvailable, "Units Available:", rowNumber);
            rowNumber = AddGridRow(ws, independentLivingStats.BeginningOccupancy, "Beginning Occupancy:", rowNumber);
            rowNumber = AddGridRow(ws, independentLivingStats.MoveIns, "Move-ins:", rowNumber);
            rowNumber = AddGridRow(ws, independentLivingStats.MoveOuts, "Move-outs:", rowNumber);
            rowNumber = AddGridRow(ws, independentLivingStats.Transfers, "Transfer to AL/HC:", rowNumber);
            rowNumber = AddGridRow(ws, independentLivingStats.EndingOccupancy, "Ending Occupancy:", rowNumber);
            rowNumber = AddGridRow(ws, independentLivingStats.PercentOccupancy, "% Occupancy:", rowNumber);
            rowNumber = AddGridRow(ws, independentLivingStats.UnoccupiedUnits, "Unoccupied Units:", rowNumber);

            return rowNumber;
        }

    }
}
