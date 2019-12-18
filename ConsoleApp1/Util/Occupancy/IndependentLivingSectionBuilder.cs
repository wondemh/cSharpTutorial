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
            rowNumber = AddSectionHeader(ws, "Independent Living Occupancy Statistics", rowNumber);
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
            independentLivingActual.BeginningOccupancy.TotalOrAverageValue = independentLivingActual.BeginningOccupancy.CalculateAverageValue();
            independentLivingActual.MoveIns.TotalOrAverageValue = independentLivingActual.MoveIns.CalculateTotalValue();
            independentLivingActual.MoveOuts.TotalOrAverageValue = independentLivingActual.MoveOuts.CalculateTotalValue();
            independentLivingActual.Transfers.TotalOrAverageValue = independentLivingActual.Transfers.CalculateTotalValue();

            int startRowNumber = rowNumber;
            rowNumber = AddColumnHeaders(ws, rowNumber);
            rowNumber = AddGridRow(ws, independentLivingActual.UnitsAvailable, "Units Available:", rowNumber);
            rowNumber = AddGridRow(ws, independentLivingActual.BeginningOccupancy, "Beginning Occupancy:", rowNumber);
            rowNumber = AddGridRow(ws, independentLivingActual.MoveIns, "Move-ins:", rowNumber);
            rowNumber = AddGridRow(ws, independentLivingActual.MoveOuts, "Move-outs:", rowNumber);
            rowNumber = AddGridRow(ws, independentLivingActual.Transfers, "Transfer to AL/HC:", rowNumber);
            rowNumber = AddGridRow(ws, independentLivingActual.EndingOccupancy, "Ending Occupancy:", rowNumber);
            rowNumber = AddGridRow(ws, independentLivingActual.PercentOccupancy, "% Occupancy:", rowNumber, "0%");
            rowNumber = AddGridRow(ws, independentLivingActual.UnoccupiedUnits, "Unoccupied Units:", rowNumber);

            //This adds the sidebar
            AddSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);


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
            rowNumber = AddColumnHeaders(ws, rowNumber);
            rowNumber = AddGridRow(ws, independentLivingBudget.BeginningOccupancy, "Beginning Occupancy:", rowNumber);
            rowNumber = AddGridRow(ws, independentLivingBudget.MoveIns, "Move-ins:", rowNumber);
            rowNumber = AddGridRow(ws, independentLivingBudget.MoveOuts, "Move-outs:", rowNumber);
            rowNumber = AddGridRow(ws, independentLivingBudget.EndingOccupancy, "Ending Occupancy:", rowNumber);
            rowNumber = AddGridRow(ws, independentLivingBudget.PercenOccupancy, "% Occupancy:", rowNumber, "0%");
            rowNumber = AddGridRow(ws, independentLivingBudget.VarianceFromBudget, "Variance from Budget:", rowNumber);

            //This adds the sidebar
            AddSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return rowNumber;
        }

    }
}
