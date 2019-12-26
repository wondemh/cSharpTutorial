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
                BeginningOccupancy = IndependentLivingDAO.GetBeginningOccupancyData(locationId, facilityTypeCodes, reportDate),
                MoveIns = IndependentLivingDAO.GetCensusCountsByAdmissionStatus(locationId, facilityTypeCodes, new List<string> { "A" }, reportDate.Year, false),
                MoveOuts = IndependentLivingDAO.GetCensusCountsByAdmissionStatus(locationId, facilityTypeCodes, new List<string> { "D" }, reportDate.Year, true),
                Transfers = IndependentLivingDAO.GetCensusCountsByAdmissionStatus(locationId, facilityTypeCodes, new List<string> { "PT" }, reportDate.Year, true)
            };
            independentLivingActual.SetEndingOccupancy(ReportDate.Month);
            independentLivingActual.BeginningOccupancy.TotalOrAverage = independentLivingActual.BeginningOccupancy.CalculateAverageValue();
            independentLivingActual.MoveIns.TotalOrAverage = independentLivingActual.MoveIns.CalculateTotalValue();
            independentLivingActual.MoveOuts.TotalOrAverage = independentLivingActual.MoveOuts.CalculateTotalValue();
            independentLivingActual.Transfers.TotalOrAverage = independentLivingActual.Transfers.CalculateTotalValue();
            independentLivingActual.SetUnoccupiedUnits(ReportDate.Month);


            //Budget data is location specific for IL section. So using current location here.
            independentLivingBudget = new IndependentLivingBudget
            {
                IndependentLivingActual = independentLivingActual,
                BeginningOccupancy = OccupancyReportDAO.GetBudgetData(Location, "IL", "Beginning Occupancy", 2020),
                MoveIns = OccupancyReportDAO.GetBudgetData(Location, "IL", "Move-ins", 2020),
                MoveOuts = OccupancyReportDAO.GetBudgetData(Location, "IL", "Move-Outs", 2020)
            };
            independentLivingBudget.SetVarianceFromBudget(ReportDate.Month);
        }

        internal int BuildActualSection(ExcelWorksheet ws, int rowNumber)
        {

            rowNumber = BuildColumnHeaders(ws, rowNumber);
            int startRowNumber = rowNumber;
            DrawRowBottomBorder(ws, rowNumber -1);
            rowNumber = BuildGridRow(ws, independentLivingActual.UnitsAvailable, "Units Available:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, independentLivingActual.BeginningOccupancy, "Beginning Occupancy:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, independentLivingActual.MoveIns, "Move-ins:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, independentLivingActual.MoveOuts, "Move-outs:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, independentLivingActual.Transfers, "Transfer to AL/HC:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, independentLivingActual.EndingOccupancy, "Ending Occupancy:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, independentLivingActual.PercentOccupancy, "% Occupancy:", rowNumber, "0\\%");
            rowNumber = BuildGridRow(ws, independentLivingActual.UnoccupiedUnits, "Unoccupied Units:", rowNumber, "0");
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
            rowNumber = BuildGridRow(ws, independentLivingBudget.BeginningOccupancy, "Beginning Occupancy:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, independentLivingBudget.MoveIns, "Move-ins:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, independentLivingBudget.MoveOuts, "Move-outs:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, independentLivingBudget.EndingOccupancy, "Ending Occupancy:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, independentLivingBudget.PercentOccupancy, "% Occupancy:", rowNumber, "0.0\\%");
            rowNumber = BuildGridRow(ws, independentLivingBudget.VarianceFromBudget, "Variance from Budget:", rowNumber, "0");
            DrawRowBottomBorder(ws, rowNumber - 1);

            //This adds the sidebar
            BuildSectionSideBar(ws, "Budget", startRowNumber, rowNumber - 1, BudgetSectionColor);

            return ++rowNumber;
        }

        internal int BuildApartmentsSection(ExcelWorksheet ws, int rowNumber)
        {
            List<string> apartmentFacilityTypes = new List<string> { "AP" };
            WLRApartmentsActual apartmentsActual = new WLRApartmentsActual
            {
                UnitsAvailable = OccupancyReportDAO.GetUnitsAvailableData(LocationCode.WLR, apartmentFacilityTypes),
                BeginningOccupancy = IndependentLivingDAO.GetBeginningOccupancyData(LocationCode.WLR, apartmentFacilityTypes, ReportDate),
                MoveIns = IndependentLivingDAO.GetCensusCountsByAdmissionStatus(LocationCode.WLR, apartmentFacilityTypes, new List<string> { "A" }, ReportDate.Year, false),
                MoveOuts = IndependentLivingDAO.GetCensusCountsByAdmissionStatus(LocationCode.WLR, apartmentFacilityTypes, new List<string> { "D" }, ReportDate.Year, true),
                TransferFromCottage = IndependentLivingDAO.GetCountsOfTransfersToOtherLevelOrFacility(LocationCode.WLR, new List<string> { "CO" }, apartmentFacilityTypes, ReportDate.Year, false),
                TransferToCottage = IndependentLivingDAO.GetCountsOfTransfersToOtherLevelOrFacility(LocationCode.WLR, apartmentFacilityTypes, new List<string> { "CO" }, ReportDate.Year, true),
                TransferToALHC = IndependentLivingDAO.GetCountsOfTransfersToOtherLevelOrFacility(LocationCode.WLR, apartmentFacilityTypes, new List<string> { "AL", "HC" }, ReportDate.Year, true),
            };
            apartmentsActual.SetEndingOccupancy(ReportDate.Month);
            apartmentsActual.SetUnoccupiedUnits(ReportDate.Month);

            rowNumber = BuildColumnHeaders(ws, rowNumber);
            int startRowNumber = rowNumber;
            DrawRowBottomBorder(ws, rowNumber - 1);
            rowNumber = BuildGridRow(ws, apartmentsActual.UnitsAvailable, "Units Available:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, apartmentsActual.BeginningOccupancy, "Units Available:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, apartmentsActual.MoveIns, "Move-ins:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, apartmentsActual.MoveOuts, "Move-outs:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, apartmentsActual.TransferFromCottage, "Transfer From Cottage:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, apartmentsActual.TransferToCottage, "Transfer To Cottage:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, apartmentsActual.TransferToALHC, "Transfer To AL/HC:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, apartmentsActual.EndingOccupancy, "Ending Occupancy:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, apartmentsActual.PercentOccupancy, "% Occupancy:", rowNumber, "0\\%");
            rowNumber = BuildGridRow(ws, apartmentsActual.UnoccupiedUnits, "Unoccupied Units:", rowNumber, "0");
            DrawRowBottomBorder(ws, rowNumber - 1);

            //This adds the sidebar
            BuildSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);

            return ++rowNumber;
        }

        internal int BuildCottagesSection(ExcelWorksheet ws, int rowNumber)
        {
            List<string> cottageFacilityTypes = new List<string> { "CO" };
            WLRCottagesActual cottagesActual = new WLRCottagesActual
            {
                UnitsAvailable = OccupancyReportDAO.GetUnitsAvailableData(LocationCode.WLR, cottageFacilityTypes),
                BeginningOccupancy = IndependentLivingDAO.GetBeginningOccupancyData(LocationCode.WLR, cottageFacilityTypes, ReportDate),
                MoveIns = IndependentLivingDAO.GetCensusCountsByAdmissionStatus(LocationCode.WLR, cottageFacilityTypes, new List<string> { "A" }, ReportDate.Year, false),
                MoveOuts = IndependentLivingDAO.GetCensusCountsByAdmissionStatus(LocationCode.WLR, cottageFacilityTypes, new List<string> { "D" }, ReportDate.Year, true),
                TransferFromApt = IndependentLivingDAO.GetCountsOfTransfersToOtherLevelOrFacility(LocationCode.WLR, new List<string> { "AP" }, cottageFacilityTypes, ReportDate.Year, false),
                TransferToApt = IndependentLivingDAO.GetCountsOfTransfersToOtherLevelOrFacility(LocationCode.WLR, cottageFacilityTypes, new List<string> { "AP" }, ReportDate.Year, true),
                TransferToALHC = IndependentLivingDAO.GetCountsOfTransfersToOtherLevelOrFacility(LocationCode.WLR, cottageFacilityTypes, new List<string> { "AL", "HC" }, ReportDate.Year, true),
            };
            cottagesActual.SetEndingOccupancy(ReportDate.Month);
            cottagesActual.SetUnoccupiedUnits(ReportDate.Month);

            rowNumber = BuildColumnHeaders(ws, rowNumber);
            int startRowNumber = rowNumber;
            DrawRowBottomBorder(ws, rowNumber - 1);
            rowNumber = BuildGridRow(ws, cottagesActual.UnitsAvailable, "Units Available:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, cottagesActual.BeginningOccupancy, "Units Available:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, cottagesActual.MoveIns, "Move-ins:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, cottagesActual.MoveOuts, "Move-outs:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, cottagesActual.TransferFromApt, "Transfer From Apt:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, cottagesActual.TransferToApt, "Transfer To Apt:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, cottagesActual.TransferToALHC, "Transfer To AL/HC:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, cottagesActual.EndingOccupancy, "Ending Occupancy:", rowNumber, "0");
            rowNumber = BuildGridRow(ws, cottagesActual.PercentOccupancy, "% Occupancy:", rowNumber, "0\\%");
            rowNumber = BuildGridRow(ws, cottagesActual.UnoccupiedUnits, "Unoccupied Units:", rowNumber, "0");
            DrawRowBottomBorder(ws, rowNumber - 1);

            //This adds the sidebar
            BuildSectionSideBar(ws, "Actual", startRowNumber, rowNumber - 1, ActualSectionColor);

            return ++rowNumber;
        }

    }
}
