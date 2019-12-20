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
    public class IKFSkilledNurseSectionBuilder : OccupancySectionBuilder
    {

        //internal static int AddSkilledNurseSection(ExcelWorksheet ws, int locationId, DateTime reportDate, int rowNumber)
        //{
        //    List<string> facilityTypeCodes = new List<string> { "HC" };
        //    rowNumber = BuildSectionHeader(ws, "Skilled Nursing Occupancy Statistics", rowNumber);
        //    rowNumber = AddActualSection(ws, locationId, reportDate, facilityTypeCodes, rowNumber);
        //    rowNumber = AddBudgetSection(ws, locationId, reportDate, facilityTypeCodes, ++rowNumber);
        //    return rowNumber;
        //}

        internal override int BuildActualSection(ExcelWorksheet ws, LocationCodes locationId, DateTime reportDate, List<string> facilityTypeCodes, int rowNumber)
        {
            SkilledNurseDAO dao = new SkilledNurseDAO();

            IKFSkilledNurseActual ikfSkilledNurseStats = new IKFSkilledNurseActual
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
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, ikfSkilledNurseStats.BedsAvailable, "Beds Available:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfSkilledNurseStats.AverageLCFirst, "Avg. LC 1st:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfSkilledNurseStats.AverageLCSecond, "Avg. LC 2nd:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfSkilledNurseStats.FFSDirectAdmit, "FFS/Direct Admit:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfSkilledNurseStats.AverageMemoryCare, "Avg. Memory Care:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfSkilledNurseStats.AverageMedicare, "Avg Medicare:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfSkilledNurseStats.AverageMedicaid, "Avg Medicaid:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfSkilledNurseStats.TotalAverageOccupancy, "Total Avg. Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfSkilledNurseStats.PercentOccupancy, "% Occupancy:", rowNumber, "0%");

            //This adds the sidebar
            BuildSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);

            return rowNumber;
        }

        internal override int BuildBudgetSection(ExcelWorksheet ws, LocationCodes locationId, DateTime reportDate, List<string> facilityTypeCodes, int rowNumber)
        {
            IKFSkilledNurseBudget ikfSkilledNurseBudget = new IKFSkilledNurseBudget
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
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, ikfSkilledNurseBudget.AverageLCFirst, "Avg. LC 1st:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfSkilledNurseBudget.LCFirstVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfSkilledNurseBudget.AverageLCSecond, "Avg. LC 2nd:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfSkilledNurseBudget.LCSecondVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfSkilledNurseBudget.MemoryCare, "Memory Care:", rowNumber, "0%");
            rowNumber = BuildGridRow(ws, ikfSkilledNurseBudget.MemoryCareVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfSkilledNurseBudget.FFSDirectAdmit, "FFS/Direct Admit:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfSkilledNurseBudget.FFSDirectAdmitVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfSkilledNurseBudget.Medicare, "Medicare:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfSkilledNurseBudget.MedicareVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfSkilledNurseBudget.Medicaid, "Medicaid:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfSkilledNurseBudget.MedicaidVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfSkilledNurseBudget.TotalOccupancy, "Total Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, ikfSkilledNurseBudget.TotalOccupancyVarianceFromBudget, "Variance from Budget:", rowNumber);

            //This adds the sidebar
            BuildSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return rowNumber;
        }
    }
}
