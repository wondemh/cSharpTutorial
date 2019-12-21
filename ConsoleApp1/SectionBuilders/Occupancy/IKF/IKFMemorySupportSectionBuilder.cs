﻿using System;
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
    internal class IKFMemorySupportSectionBuilder : OccupancySectionBuilder
    {

        private readonly IKFMemorySupportActual memorySupportActual;
        private readonly IKFMemorySupportBudget memorySupportBudget;

        internal IKFMemorySupportSectionBuilder(DateTime reportDate)
        {
            this.ReportDate = reportDate;
            List<string> facilityTypeCodes = new List<string> { "MS" };
            memorySupportActual = new IKFMemorySupportActual
            {
                UnitsAvailable = OccupancyReportDAO.GetUnitsAvailableData(LocationCodes.IKF, facilityTypeCodes),
                LicensedFor = MemorySupportDAO.GetLicensedForData(LocationCodes.IKF, facilityTypeCodes),
                PrivateMCFirstPerson = MemorySupportDAO.GetPrivateMCFirstPersonData(LocationCodes.IKF, facilityTypeCodes),
                PrivateMCSecondPerson = MemorySupportDAO.GetPrivateMCSecondPersonData(LocationCodes.IKF, facilityTypeCodes),
            };

            memorySupportBudget = new IKFMemorySupportBudget
            {
                MemorySupportActual = memorySupportActual,
                PrivateMCFirstPerson = new OccupancyRecord(),
                PrivateMCSecondPerson = new OccupancyRecord()
            };
        }

        internal int BuildActualSection(ExcelWorksheet ws, int rowNumber)
        {

            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportActual.UnitsAvailable, "Units Available:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportActual.LicensedFor, "Licensed For:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportActual.PrivateMCFirstPerson, "Private - MC - 1st Person:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportActual.PrivateMCSecondPerson, "Private - MC - 2nd Person:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportActual.EndingAverageOccupancy, "Ending Avg.Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportActual.PercentAverageUnitOccupancy, "% Avg.Unit Occupancy:", rowNumber, "0%");
            rowNumber = BuildGridRow(ws, memorySupportActual.AverageUnoccupiedUnits, "Avg.Unoccupied Units:", rowNumber);
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
            rowNumber = BuildGridRow(ws, memorySupportBudget.PrivateMCFirstPerson, "Private - MC - 1st Person:", rowNumber);
            rowNumber = BuildGridRow(ws, memorySupportBudget.PrivateMCSecondPerson, "Private - MC - 2nd Person:", rowNumber);
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
