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
    internal class IndependentLivingSectionBuilder : OccupancySectionBuilder
    {
        private readonly IndependentLivingActual independentLivingActual;
        private readonly IndependentLivingBudget independentLivingBudget;

        internal IndependentLivingSectionBuilder(LocationCode locationId, DateTime reportDate)
        {
            this.Location = locationId;
            this.ReportDate = reportDate;

            List<string> facilityTypeCodes = new List<string> { "IL", "AP", "CO" };
            independentLivingActual = new IndependentLivingActual
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


            independentLivingBudget = new IndependentLivingBudget
            {
                BeginningOccupancy = new OccupancyRecord(),
                MoveIns = new OccupancyRecord(),
                MoveOuts = new OccupancyRecord(),
            };

        }

        internal int BuildActualSection(ExcelWorksheet ws, int rowNumber)
        {

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


            return ++rowNumber;
        }

        internal int BuildBudgetSection(ExcelWorksheet ws, int rowNumber)
        {

            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);
            rowNumber = BuildGridRow(ws, independentLivingBudget.BeginningOccupancy, "Beginning Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, independentLivingBudget.MoveIns, "Move-ins:", rowNumber);
            rowNumber = BuildGridRow(ws, independentLivingBudget.MoveOuts, "Move-outs:", rowNumber);
            rowNumber = BuildGridRow(ws, independentLivingBudget.EndingOccupancy, "Ending Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, independentLivingBudget.PercentOccupancy, "% Occupancy:", rowNumber, "0%");
            rowNumber = BuildGridRow(ws, independentLivingBudget.VarianceFromBudget, "Variance from Budget:", rowNumber);

            //This adds the sidebar
            BuildSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return ++rowNumber;
        }

        internal int BuildApartmentsSection(ExcelWorksheet ws, int rowNumber)
        {
            List<string> facilityTypeCodes = new List<string> { "AP" };
            WLRApartmentsActual apartmentsActual = new WLRApartmentsActual
            {
                UnitsAvailable = OccupancyReportDAO.GetUnitsAvailableData(LocationCode.WLR, facilityTypeCodes),
                BeginningOccupancy = IndependentLivingDAO.GetActualBeginningOccupancyData(LocationCode.WLR, facilityTypeCodes, ReportDate),
                MoveIns = IndependentLivingDAO.GetActualCensusCountsByMonth(LocationCode.WLR, facilityTypeCodes, new List<string> { "A" }, ReportDate.Year, false),
                MoveOuts = IndependentLivingDAO.GetActualCensusCountsByMonth(LocationCode.WLR, facilityTypeCodes, new List<string> { "D", "DH", "L" }, ReportDate.Year, true),
                TransferFromCottage = IndependentLivingDAO.GetActualCensusCountsByMonth(LocationCode.WLR, facilityTypeCodes, new List<string> { "PT", "TT" }, ReportDate.Year, true),
                TransferToCottage = IndependentLivingDAO.GetActualCensusCountsByMonth(LocationCode.WLR, facilityTypeCodes, new List<string> { "PT", "TT" }, ReportDate.Year, true),
                TransferToALHC = IndependentLivingDAO.GetActualCensusCountsByMonth(LocationCode.WLR, facilityTypeCodes, new List<string> { "PT", "TT" }, ReportDate.Year, true),
            };
            apartmentsActual.SetEndingOccupancy(ReportDate.Month);

            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);

            rowNumber = BuildGridRow(ws, apartmentsActual.UnitsAvailable, "Units Available:", rowNumber);
            rowNumber = BuildGridRow(ws, apartmentsActual.BeginningOccupancy, "Units Available:", rowNumber);
            rowNumber = BuildGridRow(ws, apartmentsActual.MoveIns, "Move-ins:", rowNumber);
            rowNumber = BuildGridRow(ws, apartmentsActual.MoveOuts, "Move-outs:", rowNumber);
            rowNumber = BuildGridRow(ws, apartmentsActual.TransferFromCottage, "Transfer From Cottage:", rowNumber);
            rowNumber = BuildGridRow(ws, apartmentsActual.TransferToCottage, "Transfer To Cottage:", rowNumber);
            rowNumber = BuildGridRow(ws, apartmentsActual.TransferToALHC, "Transfer To AL/HC:", rowNumber);
            rowNumber = BuildGridRow(ws, apartmentsActual.EndingOccupancy, "Ending Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, apartmentsActual.PercentOccupancy, "% Occupancy:", rowNumber, "0%");
            rowNumber = BuildGridRow(ws, apartmentsActual.UnoccupiedUnits, "Unoccupied Units:", rowNumber);

            //This adds the sidebar
            BuildSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);

            return ++rowNumber;
        }

        internal int BuildCottagesSection(ExcelWorksheet ws, int rowNumber)
        {
            List<string> facilityTypeCodes = new List<string> { "CO" };
            WLRCottagesActual cottagesActual = new WLRCottagesActual
            {
                UnitsAvailable = OccupancyReportDAO.GetUnitsAvailableData(LocationCode.WLR, facilityTypeCodes),
                BeginningOccupancy = IndependentLivingDAO.GetActualBeginningOccupancyData(LocationCode.WLR, facilityTypeCodes, ReportDate),
                MoveIns = IndependentLivingDAO.GetActualCensusCountsByMonth(LocationCode.WLR, facilityTypeCodes, new List<string> { "A" }, ReportDate.Year, false),
                MoveOuts = IndependentLivingDAO.GetActualCensusCountsByMonth(LocationCode.WLR, facilityTypeCodes, new List<string> { "D", "DH", "L" }, ReportDate.Year, true),
                TransferFromApt = IndependentLivingDAO.GetActualCensusCountsByMonth(LocationCode.WLR, facilityTypeCodes, new List<string> { "PT", "TT" }, ReportDate.Year, true),
                TransferToApt = IndependentLivingDAO.GetActualCensusCountsByMonth(LocationCode.WLR, facilityTypeCodes, new List<string> { "PT", "TT" }, ReportDate.Year, true),
                TransferToALHC = IndependentLivingDAO.GetActualCensusCountsByMonth(LocationCode.WLR, facilityTypeCodes, new List<string> { "PT", "TT" }, ReportDate.Year, true),
            };
            cottagesActual.SetEndingOccupancy(ReportDate.Month);

            int startRowNumber = rowNumber;
            rowNumber = BuildColumnHeaders(ws, rowNumber);

            rowNumber = BuildGridRow(ws, cottagesActual.UnitsAvailable, "Units Available:", rowNumber);
            rowNumber = BuildGridRow(ws, cottagesActual.BeginningOccupancy, "Units Available:", rowNumber);
            rowNumber = BuildGridRow(ws, cottagesActual.MoveIns, "Move-ins:", rowNumber);
            rowNumber = BuildGridRow(ws, cottagesActual.MoveOuts, "Move-outs:", rowNumber);
            rowNumber = BuildGridRow(ws, cottagesActual.TransferFromApt, "Transfer From Apt:", rowNumber);
            rowNumber = BuildGridRow(ws, cottagesActual.TransferToApt, "Transfer To Apt:", rowNumber);
            rowNumber = BuildGridRow(ws, cottagesActual.TransferToALHC, "Transfer To AL/HC:", rowNumber);
            rowNumber = BuildGridRow(ws, cottagesActual.EndingOccupancy, "Ending Occupancy:", rowNumber);
            rowNumber = BuildGridRow(ws, cottagesActual.PercentOccupancy, "% Occupancy:", rowNumber, "0%");
            rowNumber = BuildGridRow(ws, cottagesActual.UnoccupiedUnits, "Unoccupied Units:", rowNumber);

            //This adds the sidebar
            BuildSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);

            return ++rowNumber;
        }

    }
}
