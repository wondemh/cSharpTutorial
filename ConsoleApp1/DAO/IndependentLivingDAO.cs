﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

using ReportApp.Model;

namespace ReportApp.DAO
{
    public static class IndependentLivingDAO
    {
        

        public static OccupancyRecord GetBeginningOccupancyData(LocationCode locationId, List<string> facilityTypeCodes, DateTime reportDate)
        {
            OccupancyRecord record = new OccupancyRecord
            {
                January = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 1, 1),
                February = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 2, 1),
                March = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 3, 1),
                April = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 4, 1),
                May = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 5, 1),
                June = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 6, 1),
                July = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 7, 1),
                August = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 8, 1),
                September = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 9, 1),
                October = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 10, 1),
                November = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 11, 1),
                December = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 12, 1)
            };
            return record;
        }

        public static OccupancyRecord GetCensusCountsByAdmissionStatus(LocationCode locationId, List<string> facilityTypeCodes, List<String> admissionStatusCodes, int year, bool negate)
        {
            OccupancyRecord record = new OccupancyRecord
            {
                January = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 1) * (negate ? -1 : 1),
                February = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 2) * (negate ? -1 : 1),
                March = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 3) * (negate ? -1 : 1),
                April = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 4) * (negate ? -1 : 1),
                May = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 5) * (negate ? -1 : 1),
                June = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 6) * (negate ? -1 : 1),
                July = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 7) * (negate ? -1 : 1),
                August = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 8) * (negate ? -1 : 1),
                September = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 9) * (negate ? -1 : 1),
                October = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 10) * (negate ? -1 : 1),
                November = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 11) * (negate ? -1 : 1),
                December = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 12) * (negate ? -1 : 1)
            };
            return record;
        }

        public static OccupancyRecord GetCountsOfTransfersToOtherLevelOrFacility(LocationCode locationId, List<string> originalFacilityTypeCodes, List<string> transferedToFacilityTypeCodes, int year, bool negate)
        {
            OccupancyRecord record = new OccupancyRecord
            {
                January = GetCountOfTransfersToOtherLevelOrFacility(locationId, originalFacilityTypeCodes, transferedToFacilityTypeCodes, year, 1) * (negate ? -1 : 1),
                February = GetCountOfTransfersToOtherLevelOrFacility(locationId, originalFacilityTypeCodes, transferedToFacilityTypeCodes, year, 2) * (negate ? -1 : 1),
                March = GetCountOfTransfersToOtherLevelOrFacility(locationId, originalFacilityTypeCodes, transferedToFacilityTypeCodes, year, 3) * (negate ? -1 : 1),
                April = GetCountOfTransfersToOtherLevelOrFacility(locationId, originalFacilityTypeCodes, transferedToFacilityTypeCodes, year, 4) * (negate ? -1 : 1),
                May = GetCountOfTransfersToOtherLevelOrFacility(locationId, originalFacilityTypeCodes, transferedToFacilityTypeCodes, year, 5) * (negate ? -1 : 1),
                June = GetCountOfTransfersToOtherLevelOrFacility(locationId, originalFacilityTypeCodes, transferedToFacilityTypeCodes, year, 6) * (negate ? -1 : 1),
                July = GetCountOfTransfersToOtherLevelOrFacility(locationId, originalFacilityTypeCodes, transferedToFacilityTypeCodes, year, 7) * (negate ? -1 : 1),
                August = GetCountOfTransfersToOtherLevelOrFacility(locationId, originalFacilityTypeCodes, transferedToFacilityTypeCodes, year, 8) * (negate ? -1 : 1),
                September = GetCountOfTransfersToOtherLevelOrFacility(locationId, originalFacilityTypeCodes, transferedToFacilityTypeCodes, year, 9) * (negate ? -1 : 1),
                October = GetCountOfTransfersToOtherLevelOrFacility(locationId, originalFacilityTypeCodes, transferedToFacilityTypeCodes, year, 10) * (negate ? -1 : 1),
                November = GetCountOfTransfersToOtherLevelOrFacility(locationId, originalFacilityTypeCodes, transferedToFacilityTypeCodes, year, 11) * (negate ? -1 : 1),
                December = GetCountOfTransfersToOtherLevelOrFacility(locationId, originalFacilityTypeCodes, transferedToFacilityTypeCodes, year, 12) * (negate ? -1 : 1)
            };
            return record;
        }

        private static int GetOccupancyCount(LocationCode locationId, List<string> facilityTypeCodes, int year, int month, int day)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            return conn.ExecuteScalar<int>(
                new StringBuilder()
               .Append("SELECT COUNT(ingCensus.UnitID) ")
                .Append("FROM ")
                .Append("   ingLocations ")
                .Append("   INNER JOIN ingFacilityTypes ")
                .Append("       ON ingLocations.Id = ingFacilityTypes.Location ")
                .Append("   INNER JOIN ingUnits ")
                .Append("       ON ingFacilityTypes.Location = ingUnits.Location ")
                .Append("       AND ingFacilityTypes.FacilityType = ingUnits.FacilityType ")
                .Append("   LEFT OUTER JOIN ingCensus ")
                .Append("       ON ingUnits.UnitID = ingCensus.UnitID ")
                .Append("WHERE ingLocations.Id = @LocationId ")
                .Append("   AND ingFacilityTypes.FacilityType IN @FacilityTypeCodes ")
                .Append("   AND YEAR(ingCensus.CensusDate) = @Year ")
                .Append("   AND MONTH(ingCensus.CensusDate) = @Month ")
                .Append("   AND DAY(ingCensus.CensusDate) = @Day ")
                .ToString(),
                new { LocationId = (int)locationId, FacilityTypeCodes = facilityTypeCodes, Year = year, Month = month, Day = day });
        }

        private static int GetCensusCount(LocationCode locationId, List<string> facilityTypeCodes, List<string> admissionStatusCodes, int year, int month)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            return conn.ExecuteScalar<int>(
                new StringBuilder()
                .Append("SELECT COUNT(ingCensus.UnitID) ")
                .Append("FROM ")
                .Append("   ingLocations ")
                .Append("   INNER JOIN ingFacilityTypes ")
                .Append("       ON ingLocations.Id = ingFacilityTypes.Location ")
                .Append("   INNER JOIN ingUnits ")
                .Append("       ON ingFacilityTypes.Location = ingUnits.Location ")
                .Append("       AND ingFacilityTypes.FacilityType = ingUnits.FacilityType ")
                .Append("   LEFT OUTER JOIN ingCensus ")
                .Append("       ON ingUnits.UnitID = ingCensus.UnitID ")
                .Append("WHERE ingLocations.Id = @LocationId ")
                .Append("   AND ingFacilityTypes.FacilityType IN @FacilityTypeCodes ")
                .Append("   AND ingCensus.AdmissionStatus IN @AdmissionStatusCodes ")
                .Append("   AND YEAR(ingCensus.CensusDate) = @Year ")
                .Append("   AND Month(ingCensus.CensusDate) = @Month ").ToString(),
                new { LocationId = (int)locationId, FacilityTypeCodes = facilityTypeCodes, AdmissionStatusCodes = admissionStatusCodes, Year = year, Month = month });
        }

        private static int GetCountOfTransfersToOtherLevelOrFacility(LocationCode locationId, List<string> originalFacilityTypeCodes, List<string> transferedToFacilityTypeCodes, int year, int month)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            return conn.ExecuteScalar<int>(
                new StringBuilder()
                .Append("SELECT COUNT(1) ")
                .Append("FROM ")
                .Append("   ingLocations ")
                .Append("   INNER JOIN ingFacilityTypes ")
                .Append("       ON ingLocations.Id = ingFacilityTypes.Location ")
                .Append("   INNER JOIN ingUnits ")
                .Append("       ON ingFacilityTypes.Location = ingUnits.Location ")
                .Append("       AND ingFacilityTypes.FacilityType = ingUnits.FacilityType ")
                .Append("   LEFT OUTER JOIN ingCensus A ")
                .Append("       ON ingUnits.UnitID = A.UnitID ")
                .Append("WHERE ingLocations.Id = @LocationId ")
                .Append("   AND ingFacilityTypes.FacilityType IN @FacilityTypeCodes ")
                .Append("   AND A.AdmissionStatus IN ('D', 'PT' ") //Discharged from current facility
                .Append("   AND YEAR(A.CensusDate) = @Year ")
                .Append("   AND Month(A.CensusDate) = @Month ")
                .Append("   AND EXISTS ")
                .Append("   ( ")
                .Append("       SELECT 1 ")
                .Append("       FROM ingCensus B, ingUnits C ")
                .Append("       WHERE B.ResidentID = A.ResidentID ")
                .Append("       AND B.AdmissionStatus IN('A') ")
                .Append("       AND YEAR(B.CensusDate) = @Year ")
                .Append("       AND Month(B.CensusDate) = @Month ")
                .Append("       AND(B.LevelOfCare != A.LevelOfCare OR B.UnitID != A.UnitID) ")  //New level of care or new unit
                .Append("       AND C.UnitID = B.UnitID ")
                .Append("       AND C.FacilityType IN @TransferedToFacilityTypeCodes ")
                .Append("   ) ")
                .ToString(),
                new { LocationId = (int)locationId, FacilityTypeCodes = originalFacilityTypeCodes, TransferedToFacilityTypeCodes = transferedToFacilityTypeCodes, Year = year, Month = month });
        }
    }
}
