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

        internal static int AddSkilledNurseSection(ExcelWorksheet ws, int locationId, DateTime reportDate, int rowNumber)
        {
            SkilledNurseDAO dao = new SkilledNurseDAO();
            List<string> facilityTypeCodes = new List<string> { "HC" };
            SkilledNurseStats skilledNurseStats = new SkilledNurseStats
            {
                BedsAvailable = dao.GetBedsAvailableData(locationId, facilityTypeCodes, reportDate.Year, reportDate.Month),
                AverageLCFirst = dao.GetAverageLCFirstData(locationId, facilityTypeCodes, reportDate.Year, reportDate.Month),
                AverageLCSecond = dao.GetAverageLCSecondData(locationId, facilityTypeCodes, reportDate.Year, reportDate.Month),
                FFSDirectAdmit = dao.GetFFSDirectAdmitData(locationId, facilityTypeCodes, reportDate.Year, reportDate.Month),
                AverageMemoryCare = dao.GetAverageMemoryCareData(locationId, facilityTypeCodes, reportDate.Year, reportDate.Month),
                AverageMedicare = dao.GetAverageMedicareData(locationId, facilityTypeCodes, reportDate.Year, reportDate.Month),
                AverageMedicaid = dao.GetAverageMedicaidData(locationId, facilityTypeCodes, reportDate.Year, reportDate.Month),
            };

            rowNumber = AddSectionHeader(ws, "Skilled Nursing Occupancy Statistics", rowNumber);
            rowNumber = AddColumnHeaders(ws, rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseStats.BedsAvailable, "Beds Available:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseStats.AverageLCFirst, "Avg. LC 1st:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseStats.AverageLCSecond, "Avg. LC 2nd:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseStats.FFSDirectAdmit, "FFS/Direct Admit:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseStats.AverageMemoryCare, "Avg. Memory Care:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseStats.AverageMedicare, "Avg Medicare:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseStats.AverageMedicaid, "Avg Medicaid:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseStats.TotalAverageOccupancy, "Total Avg. Occupancy:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseStats.PercentOccupancy, "% Occupancy:", rowNumber);

            return rowNumber;
        }

    }
}
