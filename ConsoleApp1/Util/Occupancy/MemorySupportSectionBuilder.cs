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
    public class MemorySupportSectionBuilder : OccupancySectionBuilder
    {

        public static int AddMemorySupportSection(ExcelWorksheet ws, int locationId, DateTime reportDate, int rowNumber)
        {
            AssistedLivingMemorySupportDAO dao = new AssistedLivingMemorySupportDAO();
            List<string> facilityTypeCodes = new List<string> { "MS" };
            AssistedLivingMemorySupportStats assistedLivingMemorySupport = new AssistedLivingMemorySupportStats
            {
                UnitsAvailable = dao.GetUnitsAvailableData(locationId, facilityTypeCodes),
                LicensedFor = null,
                PrivateMCFirstPerson = null,
                PrivateMCSecondPerson = null,
                EndingAverageOccupancy = null,
                PercentAverageUnitOccupancy = null,
                AverageUnoccupiedUnits = null,
                EndingAveragePersonOccupancy = null,
                PercentLicensedOccupancy = null
            };

            rowNumber = AddSectionHeader(ws, "Assisted Living Memory Support Occupancy Statistics", rowNumber);
            rowNumber = AddColumnHeaders(ws, rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingMemorySupport.UnitsAvailable, "Units Available:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingMemorySupport.LicensedFor, "Licensed For:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingMemorySupport.PrivateMCFirstPerson, "Private - MC - 1st Person:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingMemorySupport.PrivateMCSecondPerson, "Private - MC - 2nd Person:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingMemorySupport.EndingAverageOccupancy, "Ending Avg.Occupancy:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingMemorySupport.PercentAverageUnitOccupancy, "% Avg.Unit Occupancy:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingMemorySupport.AverageUnoccupiedUnits, "Avg.Unoccupied Units:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingMemorySupport.EndingAveragePersonOccupancy, "Ending Avg. Person Occupancy:", rowNumber);
            rowNumber = AddGridRow(ws, assistedLivingMemorySupport.PercentLicensedOccupancy, "% Licensed Occupancy:", rowNumber);

            return rowNumber;
        }

    }
}