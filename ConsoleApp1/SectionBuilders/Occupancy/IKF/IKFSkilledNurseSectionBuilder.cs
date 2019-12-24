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
        private readonly IKFSkilledNurseActual skilledNurseActual;
        private readonly IKFSkilledNurseBudget skilledNurseBudget;

        internal IKFSkilledNurseSectionBuilder(DateTime reportDate)
        {
            this.ReportDate = reportDate;
            List<string> facilityTypeCodes = new List<string> { "HC" };

            skilledNurseActual = new IKFSkilledNurseActual
            {
                BedsAvailable = OccupancyReportDAO.GetUnitsAvailableData(LocationCode.IKF, facilityTypeCodes),
                AveragePrivatePay = OccupancyReportDAO.GetCensusCountDailyAveragesByPayorTypes(LocationCode.IKF, facilityTypeCodes, reportDate, new List<string> { "PRIV" }), //Private
                AveragePrivateMedicaidPending = OccupancyReportDAO.GetCensusCountDailyAveragesByPayorTypes(LocationCode.IKF, facilityTypeCodes, reportDate, new List<string> { "MDPD", "MPND" }),//Medicaid Pending
                AverageMedicare = OccupancyReportDAO.GetCensusCountDailyAveragesByPayorTypes(LocationCode.IKF, facilityTypeCodes, reportDate, new List<string> { "MCA", "MCB" }), //Medicare
                AverageMedicaid = OccupancyReportDAO.GetCensusCountDailyAveragesByPayorTypes(LocationCode.IKF, facilityTypeCodes, reportDate, new List<string> { "MCAD", "MCOA", "MCOB", "MHOS" }) //Medicaid
            };

            skilledNurseBudget = new IKFSkilledNurseBudget
            {
                SkilledNurseActual = skilledNurseActual,
                PrivatePay = new OccupancyRecord(),
                Medicare = new OccupancyRecord(),
                Medicaid = new OccupancyRecord(),
                PrivateMedicaidPending = new OccupancyRecord()
            };
        }

        internal int BuildActualSection(ExcelWorksheet ws, int rowNumber)
        {

            rowNumber = BuildColumnHeaders(ws, rowNumber);
            int startRowNumber = rowNumber;
            DrawRowBottomBorder(ws, rowNumber - 1);
            rowNumber = BuildGridRow(ws, skilledNurseActual.BedsAvailable, "Beds Available:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.AveragePrivatePay, "Avg. Private Pay:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseActual.AveragePrivateMedicaidPending, "Avg. Private-Medicaid Pending:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseActual.AverageMedicare, "Avg. Medicare:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseActual.AverageMedicaid, "Avg. Medicaid:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseActual.TotalAverageOccupancy, "Total Avg. Occupancy:", rowNumber, "0.0");
            rowNumber = BuildGridRow(ws, skilledNurseActual.PercentOccupancy, "% Occupancy:", rowNumber, "0.0\\%");
            DrawRowBottomBorder(ws, rowNumber - 1);

            //This adds the sidebar
            BuildSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);

            return ++rowNumber;
        }

        internal int BuildBudgetSection(ExcelWorksheet ws, int rowNumber)
        {
            
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            int startRowNumber = rowNumber;
            DrawRowBottomBorder(ws, rowNumber - 1);
            rowNumber = BuildGridRow(ws, skilledNurseBudget.PrivatePay, "Avg. LC 1st:", rowNumber, "0.00");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.PrivatePayVarianceFromBudget, "Variance from Budget:", rowNumber, "0.00");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.PrivateMedicaidPending, "Private-Medicaid Pending:", rowNumber, "0.00");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.PrivateMedicaidPendingVarianceFromBudget, "Variance from Budget:", rowNumber, "0.00");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.Medicare, "Medicare:", rowNumber, "0.00");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.MedicareVarianceFromBudget, "Variance from Budget:", rowNumber, "0.00");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.Medicaid, "Medicaid:", rowNumber, "0.00");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.MedicaidVarianceFromBudget, "Variance from Budget:", rowNumber, "0.00");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.TotalOccupancy, "Total Occupancy:", rowNumber, "0.00");
            rowNumber = BuildGridRow(ws, skilledNurseBudget.TotalOccupancyVarianceFromBudget, "Variance from Budget:", rowNumber, "0.00");
            DrawRowBottomBorder(ws, rowNumber - 1);

            //This adds the sidebar
            BuildSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return ++rowNumber;
        }
    }
}
