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
    class OccupancyReportDAO
    {
        public Location GetLocation(int id)
        {
            string sql = "SELECT * FROM ingLocations WHERE Id = @LocationId";
            using var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            connection.Open();

            using var multi = connection.QueryMultiple(sql, new { LocationId = id });
            var Location = multi.Read<Location>().First();
            return Location;
        }

        public List<FacilityType> GetFactilityTypesByLocation(int locationId)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            return conn.Query<FacilityType>(
                new StringBuilder()
                .Append("SELECT Location, FacilityType AS FacilType, FacTypeCode, Title, DisplayOrder, ChartColor ")
                .Append("FROM ingLocations INNER JOIN ingFacilityTypes ON ingLocations.Id = ingFacilityTypes.Location ")
                .Append("WHERE ingLocations.Id = @LocationId ")
                .Append("   AND ingFacilityTypes.DisplayOrder > 0 ")
                .Append("ORDER BY ingFacilityTypes.DisplayOrder ")
                .ToString(), new { LocationId = locationId, }).ToList();
        }

        public int GetCountOfAllUnits(int locationId, List<string> facilityTypeCodes)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            return conn.ExecuteScalar<int>("SELECT COUNT(UnitID) FROM ingUnits WHERE Location = @LocationId AND FacilityType IN @FacilityTypeCodes",
                new { LocationId = locationId, FacilityTypeCodes = facilityTypeCodes });
        }

        public OccupancyRecord GetUnitsAvailableData(int locationId, List<string> facilityTypeCodes)
        {
            List<OccupancyRecord> unitsAvailable = new List<OccupancyRecord>();
            int countOfAllUnits = GetCountOfAllUnits(locationId, facilityTypeCodes);
            OccupancyRecord record = new OccupancyRecord
            {
                RecordTypeDescription = "Units Available",
                JanuaryValue = countOfAllUnits,
                FebruaryValue = countOfAllUnits,
                MarchValue = countOfAllUnits,
                AprilValue = countOfAllUnits,
                MayValue = countOfAllUnits,
                JuneValue = countOfAllUnits,
                JulyValue = countOfAllUnits,
                AugustValue = countOfAllUnits,
                SeptemberValue = countOfAllUnits,
                OctoberValue = countOfAllUnits,
                NovemberValue = countOfAllUnits,
                DecemberValue = countOfAllUnits
            };
            return record;
        }

        public OccupancyRecord GetBeginningOccupancyData(int locationId, List<string> facilityTypeCodes, int year)
        {
            OccupancyRecord record = new OccupancyRecord
            {
                RecordTypeDescription = "Beginning Occupancy",
                JanuaryValue = GetBeginningOccupancy(locationId, facilityTypeCodes, year, 1),
                FebruaryValue = GetBeginningOccupancy(locationId, facilityTypeCodes, year, 2),
                MarchValue = GetBeginningOccupancy(locationId, facilityTypeCodes, year, 3),
                AprilValue = GetBeginningOccupancy(locationId, facilityTypeCodes, year, 4),
                MayValue = GetBeginningOccupancy(locationId, facilityTypeCodes, year, 5),
                JuneValue = GetBeginningOccupancy(locationId, facilityTypeCodes, year, 6),
                JulyValue = GetBeginningOccupancy(locationId, facilityTypeCodes, year, 7),
                AugustValue = GetBeginningOccupancy(locationId, facilityTypeCodes, year, 8),
                SeptemberValue = GetBeginningOccupancy(locationId, facilityTypeCodes, year, 9),
                OctoberValue = GetBeginningOccupancy(locationId, facilityTypeCodes, year, 10),
                NovemberValue = GetBeginningOccupancy(locationId, facilityTypeCodes, year, 11),
                DecemberValue = GetBeginningOccupancy(locationId, facilityTypeCodes, year, 12)
            };
            return record;
        }

        public OccupancyRecord GetCensusCountsByMonth(string description, int locationId, List<string> facilityTypeCodes, List<String> admissionStatusCodes, int year)
        {
            OccupancyRecord record = new OccupancyRecord
            {
                RecordTypeDescription = description,
                JanuaryValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 1),
                FebruaryValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 2),
                MarchValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 3),
                AprilValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 4),
                MayValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 5),
                JuneValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 6),
                JulyValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 7),
                AugustValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 8),
                SeptemberValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 9),
                OctoberValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 10),
                NovemberValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 11),
                DecemberValue = GetCensusCount(locationId, facilityTypeCodes, admissionStatusCodes, year, 12)
            };
            return record;
        }


        public int GetBeginningOccupancy(int locationId, List<string> facilityTypeCodes, int year, int month)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            return conn.ExecuteScalar<int>(
                new StringBuilder()
                .Append("SELECT StartOccupancy FROM ingOccupancyBase ") //
                .Append("WHERE Location = @LocationId ") //
                .Append("   AND FacilityType = @FacilityTypeCodes ") //
                .Append("   AND Year = @Year ")
                .Append("   AND Month = @Month ")
                .ToString(),
                new { LocationId = locationId, FacilityTypeCodes = facilityTypeCodes, Year = year, Month = month });
        }

        public int GetCensusCount(int locationId, List<string> facilityTypeCodes, List<string> admissionStatusCodes, int year, int month)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            return conn.ExecuteScalar<int>(
                new StringBuilder()
                .Append("SELECT COUNT(UnitID) ")
                .Append("FROM ingCensus ")
                .Append("WHERE Location = @LocationId ")
                .Append("   AND FacilityType = @FacilityTypeCodes ")
                .Append("   AND AdmissionStatus IN @AdmissionStatusCodes ")
                .Append("   AND YEAR(CensusDate) = @Year ")
                .Append("   AND Month(CensusDate) = @Month ").ToString(),
                new { LocationId = locationId, FacilityTypeCodes = facilityTypeCodes, AdmissionStatusCodes = admissionStatusCodes, Year = year, Month = month });
        }

    }
}
