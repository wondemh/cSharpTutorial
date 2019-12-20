using Dapper;
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
    static class AssistedLivingDAO
    {
        public static OccupancyRecord GetAverageFFS(LocationCodes locationId, List<string> facilityTypeCodes, DateTime reportDate)
        {
            int year = reportDate.Year;
            OccupancyRecord record = new OccupancyRecord
            {
                January = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 1) / DateTime.DaysInMonth(year, 1),
                February = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 2) / DateTime.DaysInMonth(year, 2),
                March = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 3) / DateTime.DaysInMonth(year, 3),
                April = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 4) / DateTime.DaysInMonth(year, 4),
                May = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 5) / DateTime.DaysInMonth(year, 5),
                June = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 6) / DateTime.DaysInMonth(year, 6),
                July = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 7) / DateTime.DaysInMonth(year, 7),
                August = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 8) / DateTime.DaysInMonth(year, 8),
                September = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 9) / DateTime.DaysInMonth(year, 9),
                October = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 10) / DateTime.DaysInMonth(year, 10),
                November = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 11) / DateTime.DaysInMonth(year, 11),
                December = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 12) / DateTime.DaysInMonth(year, 12)
            };
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }

        internal static OccupancyRecord GetAverageLC(LocationCodes locationId, List<string> facilityTypeCodes, DateTime reportDate)
        {
            int year = reportDate.Year;
            OccupancyRecord record = new OccupancyRecord
            {
                January = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 1) / DateTime.DaysInMonth(year, 1),
                February = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 2) / DateTime.DaysInMonth(year, 2),
                March = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 3) / DateTime.DaysInMonth(year, 3),
                April = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 4) / DateTime.DaysInMonth(year, 4),
                May = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 5) / DateTime.DaysInMonth(year, 5),
                June = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 6) / DateTime.DaysInMonth(year, 6),
                July = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 7) / DateTime.DaysInMonth(year, 7),
                August = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 8) / DateTime.DaysInMonth(year, 8),
                September = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 9) / DateTime.DaysInMonth(year, 9),
                October = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 10) / DateTime.DaysInMonth(year, 10),
                November = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 11) / DateTime.DaysInMonth(year, 11),
                December = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 12) / DateTime.DaysInMonth(year, 12)
            };
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }

        private static int GetCensusCountForPayorType(LocationCodes locationId, List<string> facilityTypeCodes, string payorType, int year, int month)
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
                .Append("   AND ingCensus.PayorType = @PayorType ")
                .Append("   AND YEAR(ingCensus.CensusDate) = @Year ")
                .Append("   AND Month(ingCensus.CensusDate) = @Month ").ToString(),
                new { LocationId = (int)locationId, FacilityTypeCodes = facilityTypeCodes, PayorType = payorType, Year = year, Month = month });
        }

        private static int GetCensusCountForLevelOfCare(LocationCodes locationId, List<string> facilityTypeCodes, string levelOfCare, int year, int month)
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
                .Append("   AND ingCensus.LevelOfCare = @LevelOfCare ")
                .Append("   AND YEAR(ingCensus.CensusDate) = @Year ")
                .Append("   AND Month(ingCensus.CensusDate) = @Month ").ToString(),
                new { LocationId = (int)locationId, FacilityTypeCodes = facilityTypeCodes, LevelOfCare = levelOfCare, Year = year, Month = month });
        }
    }
}
