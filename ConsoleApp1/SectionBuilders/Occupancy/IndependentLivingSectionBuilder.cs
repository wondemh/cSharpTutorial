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
    public class IndependentLivingSectionBuilder : OccupancySectionBuilder
    {

        internal static int AddIndependentLivingSection(ExcelWorksheet ws, int locationId, DateTime reportDate, int rowNumber)
        {
            List<string> facilityTypeCodes = new List<string> { "IL", "AP", "CO", "PS" };
            rowNumber = BuildSectionHeader(ws, "Independent Living Occupancy Statistics", rowNumber);
            rowNumber = AddActualSection(ws, locationId, reportDate, facilityTypeCodes, rowNumber);
            rowNumber = AddBudgetSection(ws, locationId, reportDate, facilityTypeCodes, ++rowNumber);
            return rowNumber;
        }

        private static int AddActualSection(ExcelWorksheet ws, int locationId, DateTime reportDate, List<string> facilityTypeCodes, int rowNumber)
        {
           
            IndependentLivingActual independentLivingActual = new IndependentLivingActual
            {
                UnitsAvailable = OccupancyReportDAO.GetUnitsAvailableData(locationId, facilityTypeCodes),
                BeginningOccupancy = IndependentLivingDAO.GetActualBeginningOccupancyData(locationId, facilityTypeCodes, reportDate),
                MoveIns = IndependentLivingDAO.GetActualCensusCountsByMonth(locationId, facilityTypeCodes, new List<string> { "A" }, reportDate.Year, false),
                MoveOuts = IndependentLivingDAO.GetActualCensusCountsByMonth(locationId, facilityTypeCodes, new List<string> { "D", "DH", "L" }, reportDate.Year, true),
                Transfers = IndependentLivingDAO.GetActualCensusCountsByMonth(locationId, facilityTypeCodes, new List<string> { "PT", "TT" }, reportDate.Year, true)
            };
            independentLivingActual.BeginningOccupancy.TotalOrAverage = independentLivingActual.BeginningOccupancy.CalculateAverageValue();
            independentLivingActual.MoveIns.TotalOrAverage = independentLivingActual.MoveIns.CalculateTotalValue();
            independentLivingActual.MoveOuts.TotalOrAverage = independentLivingActual.MoveOuts.CalculateTotalValue();
            independentLivingActual.Transfers.TotalOrAverage = independentLivingActual.Transfers.CalculateTotalValue();

            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, independentLivingActual.UnitsAvailable, "Units Available:", rowNumber);
            rowNumber = BuildGridRow(ws, independentLivingActual.BeginningOccupancy, "Beginning Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, independentLivingActual.MoveIns, "Move-ins:", rowNumber);
            rowNumber = BuildGridRow(ws, independentLivingActual.MoveOuts, "Move-outs:", rowNumber);
            rowNumber = BuildGridRow(ws, independentLivingActual.Transfers, "Transfer to AL/HC:", rowNumber);
            rowNumber = BuildGridRow(ws, independentLivingActual.EndingOccupancy, "Ending Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, independentLivingActual.PercentOccupancy, "% Occupancy:", rowNumber, "0%");
            rowNumber = BuildGridRow(ws, independentLivingActual.UnoccupiedUnits, "Unoccupied Units:", rowNumber);

            //This adds the sidebar
            BuildSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);


            return rowNumber;
        }

        private static int AddBudgetSection(ExcelWorksheet ws, int locationId, DateTime reportDate, List<string> facilityTypeCodes, int rowNumber)
        {
            IndependentLivingBudget independentLivingBudget = new IndependentLivingBudget
            {
                BeginningOccupancy = new OccupancyRecord(),
                EndingOccupancy = new OccupancyRecord(),
                MoveIns = new OccupancyRecord(),
                MoveOuts = new OccupancyRecord(),
                PercenOccupancy = new OccupancyRecord(),
                VarianceFromBudget = new OccupancyRecord()
            };

            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, independentLivingBudget.BeginningOccupancy, "Beginning Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, independentLivingBudget.MoveIns, "Move-ins:", rowNumber);
            rowNumber = BuildGridRow(ws, independentLivingBudget.MoveOuts, "Move-outs:", rowNumber);
            rowNumber = BuildGridRow(ws, independentLivingBudget.EndingOccupancy, "Ending Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, independentLivingBudget.PercenOccupancy, "% Occupancy:", rowNumber, "0%");
            rowNumber = BuildGridRow(ws, independentLivingBudget.VarianceFromBudget, "Variance from Budget:", rowNumber);

            //This adds the sidebar
            BuildSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return rowNumber;
        }

    }
}
