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
    public class IRCSkilledNurseSectionBuilder : OccupancySectionBuilder
    {
        private readonly IRCSkilledNurseActual skilledNurseActual;
        private readonly IRCSkilledNurseBudget skilledNurseBudget;

        internal IRCSkilledNurseSectionBuilder(DateTime reportDate)
        {
            this.ReportDate = reportDate;
            List<string> facilityTypeCodes = new List<string> { "HC" };

            OccupancyRecord ffsDirectAdmit = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.IRC, facilityTypeCodes, reportDate, new List<string> { "F33" }, "MC");
            ffsDirectAdmit.AddToMonthlyValues(OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.IRC, facilityTypeCodes, reportDate, new List<string> { "F33", "NF", "SNF" }, "PRIV"));

            skilledNurseActual = new IRCSkilledNurseActual
            {
                BedsAvailable = OccupancyReportDAO.GetUnitsAvailableData(LocationCode.IRC, facilityTypeCodes),
                AverageLCFirst = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.IRC, facilityTypeCodes, reportDate, new List<string> { "DB1", "L33", "M33", "TLC" }, "PRIV"),
                AverageLCSecond = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.IRC, facilityTypeCodes, reportDate, new List<string> { "L34" }, "PRIV"),
                FFSDirectAdmit = ffsDirectAdmit,
                AverageMedicare = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.IRC, facilityTypeCodes, reportDate, new List<string> { "SNF" }, "MCA"),
                AverageMedicaid = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.IRC, facilityTypeCodes, reportDate, new List<string> { "NF", "SNF", "MHOS", "MPND", "F33" }, "MCD"),
            };

            skilledNurseBudget = new IRCSkilledNurseBudget
            {
                SkilledNurseActual = skilledNurseActual,
                AverageLCFirst = new OccupancyRecord(),
                AverageLCSecond = new OccupancyRecord(),
                FFSDirectAdmit = new OccupancyRecord(),
                Medicare = new OccupancyRecord(),
                Medicaid = new OccupancyRecord()
            };

        }

        internal int BuildActualSection(ExcelWorksheet ws, int rowNumber)
        {
            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.BedsAvailable, "Beds Available:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.AverageLCFirst, "Avg. LC 1st:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.AverageLCSecond, "Avg. LC 2nd:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.FFSDirectAdmit, "FFS/Direct Admit:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.AverageMedicare, "Avg Medicare:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.AverageMedicaid, "Avg Medicaid:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.TotalAverageOccupancy, "Total Avg. Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.PercentOccupancy, "% Occupancy:", rowNumber, "0%");

            //This adds the sidebar
            BuildSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);

            return ++rowNumber;
        }

        internal int BuildBudgetSection(ExcelWorksheet ws, int rowNumber)
        {
            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseBudget.AverageLCFirst, "Avg. LC 1st:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseBudget.AverageLCFirstVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseBudget.AverageLCSecond, "Avg. LC 2nd:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseBudget.AverageLCSecondVarianceFromBudget, "Variance from Budget:", rowNumber);
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

            return ++rowNumber;
        }
    }
}
