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

            skilledNurseActual = new IKFSkilledNurseActual
            {
                BedsAvailable = new OccupancyRecord(),
                AveragePrivatePay = new OccupancyRecord(),
                AveragePrivateMedicaidPending = new OccupancyRecord(),
                AverageMedicare = new OccupancyRecord(),
                AverageMedicaid = new OccupancyRecord()
            };

            skilledNurseBudget = new IKFSkilledNurseBudget
            {
                SkilledNurseActual = skilledNurseActual,
                PrivatePay = new OccupancyRecord(),
                Medicare = new OccupancyRecord(),
                Medicaid = new OccupancyRecord()
            };

        }

        internal int BuildActualSection(ExcelWorksheet ws, int rowNumber)
        {

            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.BedsAvailable, "Beds Available:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.AveragePrivatePay, "Avg. Private Pay:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.AveragePrivateMedicaidPending, "Avg. Private-Medicaid Pending:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.AverageMedicare, "Avg. Medicare:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.AverageMedicaid, "Avg. Medicaid:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.TotalAverageOccupancy, "Total Avg. Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseActual.PercentOccupancy, "% Occupancy:", rowNumber, "0%");

            //This adds the sidebar
            BuildSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);

            return rowNumber;
        }

        internal int BuildBudgetSection(ExcelWorksheet ws, int rowNumber)
        {
            
            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseBudget.PrivatePay, "Avg. LC 1st:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseBudget.PrivatePayVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseBudget.PrivateMedicaidPending, "Private-Medicaid Pending:", rowNumber);
            rowNumber = BuildGridRow(ws, skilledNurseBudget.PrivateMedicaidPendingVarianceFromBudget, "Variance from Budget:", rowNumber);
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
