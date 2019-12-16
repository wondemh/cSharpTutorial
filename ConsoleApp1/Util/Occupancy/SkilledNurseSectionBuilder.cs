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
    public class SkilledNurseSectionBuilder : OccupancySectionBuilder
    {

        public static int AddSkilledNurseSection(ExcelWorksheet ws, int locationId, DateTime reportDate, int rowNumber)
        {
            SkilledNurseDAO dao = new SkilledNurseDAO();
            List<string> facilityTypeCodes = new List<string> { "HC" };
            SkilledNurseStats independentLivingStats = new SkilledNurseStats
            {
                BedsAvailable = dao.GetBedsAvailableData(locationId, facilityTypeCodes, reportDate.Year, reportDate.Month),
                AverageLCFirst = dao.GetAverageLCFirstData(locationId, facilityTypeCodes, reportDate.Year, reportDate.Month),
                AverageLCSecond = dao.GetAverageLCSecondData(locationId, facilityTypeCodes, reportDate.Year, reportDate.Month),
                FFSDirectAdmit = dao.GetFFSDirectAdmitData(locationId, facilityTypeCodes, reportDate.Year, reportDate.Month),
                AverageMemoryCare = dao.GetAverageMemoryDareData(locationId, facilityTypeCodes, reportDate.Year, reportDate.Month),
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
