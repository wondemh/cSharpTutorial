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
    internal class IRCMemorySupportSectionBuilder : OccupancySectionBuilder
    {
        private readonly IRCMemorySupportActual memorySupportActual;
        private readonly IRCMemorySupportBudget memorySupportBudget;

        internal IRCMemorySupportSectionBuilder(DateTime reportDate)
        {
            this.ReportDate = reportDate;

            memorySupportActual = new IRCMemorySupportActual
            {
                UnitsAvailable = new OccupancyRecord(),
                LicensedFor = new OccupancyRecord(),
                AverageMSFFSFirst = new OccupancyRecord(),
                AverageMSFFSSecond = new OccupancyRecord(),
                AverageMSLCFirst = new OccupancyRecord(),
                AverageMSLCSecond = new OccupancyRecord()
            };

            memorySupportBudget = new IRCMemorySupportBudget
            {
                MemorySupportActual = memorySupportActual,
                AverageMSFFSFirst = new OccupancyRecord(),
                AverageMSFFSSecond = new OccupancyRecord(),
                AverageMSLCFirst = new OccupancyRecord(),
                AverageMSLCSecond = new OccupancyRecord()
            };
        }

        internal int BuildActualSection(ExcelWorksheet ws, int rowNumber)
        {
            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportActual.UnitsAvailable, "Units Available:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportActual.LicensedFor, "Licensed For:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportActual.AverageMSFFSFirst, "Average MS FFS 1st:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportActual.AverageMSFFSSecond, "Average MS FFS 2nd:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportActual.AverageMSLCFirst, "Average MS LC 1st:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportActual.AverageMSLCSecond, "Average MS LC 2nd:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportActual.EndingAverageOccupancy, "Ending Avg. Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportActual.PercentUnitOccupancy, "% Unit Occupancy:", rowNumber, "0%");
            rowNumber = BuildGridRow(ws, memorySupportActual.UnoccupiedUnits, "Unoccupied Units:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportActual.EndingAveragePersonOccupancy, "Ending Avg. Person Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportActual.PercentLicensedOccupancy, "% Licensed Occupancy:", rowNumber, "0%");

            //This adds the sidebar
            BuildSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);

            return ++rowNumber;
        }

        internal int BuildBudgetSection(ExcelWorksheet ws, int rowNumber)
        {
            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportBudget.AverageMSFFSFirst, "Average MS FFS 1st:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportBudget.AverageMSFFSSecond, "Average MS FFS 2nd:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportBudget.AverageMSLCFirst, "Average MS LC 2st:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportBudget.AverageMSLCSecond, "Average MS LC 2nd:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportBudget.EndingAverageOccupancy, "Ending Avg. Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportBudget.EndingAverageOccupancyVarianceFromBudget, "Variance from Budget:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportBudget.EndingAveragePersonOccupancy, "Ending Avg. Person Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportBudget.EndingAvgPersonOccupancyVarianceFromBudget, "Variance from Budget:", rowNumber, "0%");

            //This adds the sidebar
            BuildSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return ++rowNumber;
        }
    }
}
