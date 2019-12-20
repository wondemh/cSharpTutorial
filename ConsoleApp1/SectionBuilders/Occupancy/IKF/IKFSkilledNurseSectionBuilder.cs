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

            IKFSkilledNurseActual skilledNurseActual = new IKFSkilledNurseActual
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
            rowNumber = BuildGridRow(ws, skilledNurseActual.BedsAvailable, "Beds Available:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.AverageLCFirst, "Avg. LC 1st:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.AverageLCSecond, "Avg. LC 2nd:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.FFSDirectAdmit, "FFS/Direct Admit:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.AverageMemoryCare, "Avg. Memory Care:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.AverageMedicare, "Avg Medicare:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.AverageMedicaid, "Avg Medicaid:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.TotalAverageOccupancy, "Total Avg. Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.PercentOccupancy, "% Occupancy:", rowNumber, "0%");

            //This adds the sidebar
            BuildSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);

            return rowNumber;
        }

        internal override int BuildBudgetSection(ExcelWorksheet ws, LocationCodes locationId, DateTime reportDate, List<string> facilityTypeCodes, int rowNumber)
        {
            IKFSkilledNurseBudget skilledNurseBudget = new IKFSkilledNurseBudget
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
            rowNumber = BuildGridRow(ws, skilledNurseBudget.AverageLCFirst, "Avg. LC 1st:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseBudget.LCFirstVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseBudget.AverageLCSecond, "Avg. LC 2nd:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseBudget.LCSecondVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseBudget.MemoryCare, "Memory Care:", rowNumber, "0%");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.MemoryCareVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseBudget.FFSDirectAdmit, "FFS/Direct Admit:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseBudget.FFSDirectAdmitVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseBudget.Medicare, "Medicare:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseBudget.MedicareVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseBudget.Medicaid, "Medicaid:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseBudget.MedicaidVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseBudget.TotalOccupancy, "Total Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseBudget.TotalOccupancyVarianceFromBudget, "Variance from Budget:", rowNumber);

            //This adds the sidebar
            BuildSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return rowNumber;
        }
    }
}
