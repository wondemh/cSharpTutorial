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
    internal class WLRSkilledNurseSectionBuilder : OccupancySectionBuilder
    {
        private readonly WLRSkilledNurseActual skilledNurseActual;
        private readonly WLRSkilledNurseBudget skilledNurseBudget;

        internal WLRSkilledNurseSectionBuilder(DateTime reportDate)
        {
            this.ReportDate = reportDate;
            List<string> facilityTypeCodes = new List<string> { "HC" };
            skilledNurseActual = new WLRSkilledNurseActual
            {
                BedsAvailable = OccupancyReportDAO.GetUnitsAvailableData(LocationCode.WLR, facilityTypeCodes),
                AverageLCFirst = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.WLR, facilityTypeCodes, reportDate, new List<string> { "A11", "A12", "A12D", "A1DL", "A1DN", "C11", "C12", "C12D", "FREE", "LIF1", "RESP", "TLC1" }, "PRIV"),
                AverageLCSecond = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.WLR, facilityTypeCodes, reportDate, new List<string> { "LIF2", "TLC2" }, "PRIV"),
                FFSDirectAdmit = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.WLR, facilityTypeCodes, reportDate, new List<string> { "FFH1", "FFS1", "FFS2", "NF" }, "PRIV"),
                AverageMemoryCare = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.WLR, facilityTypeCodes, reportDate, new List<string> { "MC" }, "PRIV"),
                AverageMedicare = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.WLR, facilityTypeCodes, reportDate, new List<string> { "SNF" }, "MCA"),
                AverageMedicaid = OccupancyReportDAO.GetCensusCountDailyAverages(LocationCode.WLR, facilityTypeCodes, reportDate, new List<string> { "NF" }, "MCD")
            };

            skilledNurseBudget = new WLRSkilledNurseBudget
            {
                SkilledNurseActual = skilledNurseActual,
                AverageLCFirst = OccupancyReportDAO.GetBudgetData(LocationCode.IRC, "HC", "Private - LC", 2020),
                AverageLCSecond = OccupancyReportDAO.GetBudgetData(LocationCode.IRC, "HC", "Private - LC", 2020),
                MemoryCare = OccupancyReportDAO.GetBudgetData(LocationCode.IRC, "HC", "Memory Care - LC", 2020),
                FFSDirectAdmit = OccupancyReportDAO.GetBudgetData(LocationCode.IRC, "HC", "Memory Care - FFS", 2020),
                Medicare = OccupancyReportDAO.GetBudgetData(LocationCode.IRC, "HC", "Medicare A", 2020),
                Medicaid = OccupancyReportDAO.GetBudgetData(LocationCode.IRC, "HC", "Medicaid", 2020)
            };
        }

        internal int BuildActualSection(ExcelWorksheet ws, int rowNumber)
        {
            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.BedsAvailable, "Beds Available:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, skilledNurseActual.AverageLCFirst, "Avg. LC 1st:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseActual.AverageLCSecond, "Avg. LC 2nd:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseActual.FFSDirectAdmit, "FFS/Direct Admit:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseActual.AverageMemoryCare, "Avg. Memory Care:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseActual.AverageMedicare, "Avg Medicare:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseActual.AverageMedicaid, "Avg Medicaid:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseActual.TotalAverageOccupancy, "Total Avg. Occupancy:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseActual.PercentOccupancy, "% Occupancy:", rowNumber, "0\\%");

            //This adds the sidebar
            BuildSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);

            return ++rowNumber;
        }

        internal int BuildBudgetSection(ExcelWorksheet ws, int rowNumber)
        {
            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseBudget.AverageLCFirst, "Avg. LC 1st:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.AverageLCFirstVarianceFromBudget, "Variance from Budget:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.AverageLCSecond, "Avg. LC 2nd:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.AverageLCSecondVarianceFromBudget, "Variance from Budget:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.MemoryCare, "Memory Care:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.MemoryCareVarianceFromBudget, "Variance from Budget:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.FFSDirectAdmit, "FFS/Direct Admit:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.FFSDirectAdmitVarianceFromBudget, "Variance from Budget:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.Medicare, "Medicare:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.MedicareVarianceFromBudget, "Variance from Budget:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.Medicaid, "Medicaid:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.MedicaidVarianceFromBudget, "Variance from Budget:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.TotalOccupancy, "Total Occupancy:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.TotalOccupancyVarianceFromBudget, "Variance from Budget:", rowNumber, "0.0");

            //This adds the sidebar
            BuildSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return ++rowNumber;
        }
    }
}
