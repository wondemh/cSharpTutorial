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
        public static OccupancyRecord GetAverageFFS(int locationId, List<string> facilityTypeCodes, DateTime reportDate)
        {
            int year = reportDate.Year;
            OccupancyRecord record = new OccupancyRecord
            {
                JanuaryValue = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 1) / DateTime.DaysInMonth(year, 1),
                FebruaryValue = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 2) / DateTime.DaysInMonth(year, 2),
                MarchValue = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 3) / DateTime.DaysInMonth(year, 3),
                AprilValue = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 4) / DateTime.DaysInMonth(year, 4),
                MayValue = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 5) / DateTime.DaysInMonth(year, 5),
                JuneValue = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 6) / DateTime.DaysInMonth(year, 6),
                JulyValue = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 7) / DateTime.DaysInMonth(year, 7),
                AugustValue = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 8) / DateTime.DaysInMonth(year, 8),
                SeptemberValue = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 9) / DateTime.DaysInMonth(year, 9),
                OctoberValue = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 10) / DateTime.DaysInMonth(year, 10),
                NovemberValue = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 11) / DateTime.DaysInMonth(year, 11),
                DecemberValue = GetCensusCountForPayorType(locationId, facilityTypeCodes, "PRIV", year, 12) / DateTime.DaysInMonth(year, 12)
            };
            record.TotalOrAverageValue = record.CalculateAverageValue();
            return record;
        }

        internal static OccupancyRecord GetAverageLC(int locationId, List<string> facilityTypeCodes, DateTime reportDate)
        {
            int year = reportDate.Year;
            OccupancyRecord record = new OccupancyRecord
            {
                JanuaryValue = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 1) / DateTime.DaysInMonth(year, 1),
                FebruaryValue = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 2) / DateTime.DaysInMonth(year, 2),
                MarchValue = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 3) / DateTime.DaysInMonth(year, 3),
                AprilValue = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 4) / DateTime.DaysInMonth(year, 4),
                MayValue = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 5) / DateTime.DaysInMonth(year, 5),
                JuneValue = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 6) / DateTime.DaysInMonth(year, 6),
                JulyValue = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 7) / DateTime.DaysInMonth(year, 7),
                AugustValue = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 8) / DateTime.DaysInMonth(year, 8),
                SeptemberValue = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 9) / DateTime.DaysInMonth(year, 9),
                OctoberValue = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 10) / DateTime.DaysInMonth(year, 10),
                NovemberValue = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 11) / DateTime.DaysInMonth(year, 11),
                DecemberValue = GetCensusCountForLevelOfCare(locationId, facilityTypeCodes, "LC-A", year, 12) / DateTime.DaysInMonth(year, 12)
            };
            record.TotalOrAverageValue = record.CalculateAverageValue();
            return record;
        }

        private static int GetCensusCountForPayorType(int locationId, List<string> facilityTypeCodes, string payorType, int year, int month)
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
                new { LocationId = locationId, FacilityTypeCodes = facilityTypeCodes, PayorType = payorType, Year = year, Month = month });
        }

        private static int GetCensusCountForLevelOfCare(int locationId, List<string> facilityTypeCodes, string levelOfCare, int year, int month)
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
                new { LocationId = locationId, FacilityTypeCodes = facilityTypeCodes, LevelOfCare = levelOfCare, Year = year, Month = month });
        }
    }
}
