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
            List<string> facilityTypeCodes = new List<string> { "HC" };
            rowNumber = AddSectionHeader(ws, "Skilled Nursing Occupancy Statistics", rowNumber);
            rowNumber = AddActualSection(ws, locationId, reportDate, facilityTypeCodes, rowNumber);
            rowNumber = AddBudgetSection(ws, locationId, reportDate, facilityTypeCodes, ++rowNumber);
            return rowNumber;
        }

        private static int AddActualSection(ExcelWorksheet ws, int locationId, DateTime reportDate, List<string> facilityTypeCodes, int rowNumber)
        {
            SkilledNurseDAO dao = new SkilledNurseDAO();
            
            SkilledNurseActual skilledNurseStats = new SkilledNurseActual
            {
                BedsAvailable = dao.GetBedsAvailableData(locationId, facilityTypeCodes, reportDate.Year, reportDate.Month),
                AverageLCFirst = dao.GetAverageLCFirstData(locationId, facilityTypeCodes, reportDate.Year, reportDate.Month),
                AverageLCSecond = dao.GetAverageLCSecondData(locationId, facilityTypeCodes, reportDate.Year, reportDate.Month),
                FFSDirectAdmit = dao.GetFFSDirectAdmitData(locationId, facilityTypeCodes, reportDate.Year, reportDate.Month),
                AverageMemoryCare = dao.GetAverageMemoryCareData(locationId, facilityTypeCodes, reportDate.Year, reportDate.Month),
                AverageMedicare = dao.GetAverageMedicareData(locationId, facilityTypeCodes, reportDate.Year, reportDate.Month),
                AverageMedicaid = dao.GetAverageMedicaidData(locationId, facilityTypeCodes, reportDate.Year, reportDate.Month),
            };

            int startRowNumber = rowNumber;
            rowNumber = AddColumnHeaders(ws, rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseStats.BedsAvailable, "Beds Available:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseStats.AverageLCFirst, "Avg. LC 1st:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseStats.AverageLCSecond, "Avg. LC 2nd:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseStats.FFSDirectAdmit, "FFS/Direct Admit:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseStats.AverageMemoryCare, "Avg. Memory Care:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseStats.AverageMedicare, "Avg Medicare:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseStats.AverageMedicaid, "Avg Medicaid:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseStats.TotalAverageOccupancy, "Total Avg. Occupancy:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseStats.PercentOccupancy, "% Occupancy:", rowNumber, "0%");

            //This adds the sidebar
            AddSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);

            return rowNumber;
        }

        private static int AddBudgetSection(ExcelWorksheet ws, int locationId, DateTime reportDate, List<string> facilityTypeCodes, int rowNumber)
        {
            SkilledNurseBudget skilledNurseBudget = new SkilledNurseBudget
            {
                AverageLCFirst = new OccupancyRecord(),
                LCFirstVarianceFromBudget = new OccupancyRecord(),
                AverageLCSecond = new OccupancyRecord(),
                LCSecondVarianceFromBudget = new OccupancyRecord(),
                MemoryCare = new OccupancyRecord(),
                MemoryCareVarianceFromBudget = new OccupancyRecord(),
                FFSDirectAdmit = new OccupancyRecord(),
                FFSDirectAdmitVarianceFromBudget = new OccupancyRecord(),
                Medicare = new OccupancyRecord(),
                MedicareVarianceFromBudget = new OccupancyRecord(),
                Medicaid = new OccupancyRecord(),
                MedicaidVarianceFromBudget = new OccupancyRecord(),
                TotalOccupancy = new OccupancyRecord(),
                TotalOccupancyVarianceFromBudget = new OccupancyRecord()
            };

            int startRowNumber = rowNumber;
            rowNumber = AddColumnHeaders(ws, rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseBudget.AverageLCFirst, "Avg. LC 1st:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseBudget.LCFirstVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseBudget.AverageLCSecond, "Avg. LC 2nd:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseBudget.LCSecondVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseBudget.MemoryCare, "Memory Care:", rowNumber, "0%");
            rowNumber = AddGridRow(ws, skilledNurseBudget.MemoryCareVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseBudget.FFSDirectAdmit, "FFS/Direct Admit:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseBudget.FFSDirectAdmitVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseBudget.Medicare, "Medicare:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseBudget.MedicareVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseBudget.Medicaid, "Medicaid:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseBudget.MedicaidVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseBudget.TotalOccupancy, "Total Occupancy:", rowNumber);
            rowNumber = AddGridRow(ws, skilledNurseBudget.TotalOccupancyVarianceFromBudget, "Variance from Budget:", rowNumber);

            //This adds the sidebar
            AddSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return rowNumber;
        }
    }
}
