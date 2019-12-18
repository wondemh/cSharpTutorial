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
    public static class IndependentLivingDAO
    {
        

        public static OccupancyRecord GetActualBeginningOccupancyData(int locationId, List<string> facilityTypeCodes, DateTime reportDate)
        {
            OccupancyRecord record = new OccupancyRecord
            {
                JanuaryValue = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 1, 1),
                FebruaryValue = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 2, 1),
                MarchValue = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 3, 1),
                AprilValue = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 4, 1),
                MayValue = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 5, 1),
                JuneValue = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 6, 1),
                JulyValue = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 7, 1),
                AugustValue = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 8, 1),
                SeptemberValue = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 9, 1),
                OctoberValue = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 10, 1),
                NovemberValue = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 11, 1),
                DecemberValue = GetOccupancyCount(locationId, facilityTypeCodes, reportDate.Year, 12, 1)
            };
            return record;
        }

        public static OccupancyRecord GetActualCensusCountsByMonth(int locationId, List<string> facilityTypeCodes, List<String> admissionStatusCodes, int year, bool negate)
        {
            OccupancyRecord record = new OccupancyRecord
            {
                JanuaryValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 1) * (negate ? -1 : 1),
                FebruaryValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 2) * (negate ? -1 : 1),
                MarchValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 3) * (negate ? -1 : 1),
                AprilValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 4) * (negate ? -1 : 1),
                MayValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 5) * (negate ? -1 : 1),
                JuneValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 6) * (negate ? -1 : 1),
                JulyValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 7) * (negate ? -1 : 1),
                AugustValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 8) * (negate ? -1 : 1),
                SeptemberValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 9) * (negate ? -1 : 1),
                OctoberValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 10) * (negate ? -1 : 1),
                NovemberValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 11) * (negate ? -1 : 1),
                DecemberValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 12) * (negate ? -1 : 1)
            };
            return record;
        }

        private static int GetOccupancyCount(int locationId, List<string> facilityTypeCodes, int year, int month, int day)
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
                new { LocationId = locationId, FacilityTypeCodes = facilityTypeCodes, Year = year, Month = month, Day = day });
        }

        private static int GetCensusCount(int locationId, List<string> facilityTypeCodes, List<string> admissionStatusCodes, int year, int month)
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
                new { LocationId = locationId, FacilityTypeCodes = facilityTypeCodes, AdmissionStatusCodes = admissionStatusCodes, Year = year, Month = month });
        }
    }
}
