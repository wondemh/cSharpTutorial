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
    public static class OccupancyReportDAO
    {
        public static OccupancyRecord GetUnitsAvailableData(int locationId, List<string> facilityTypeCodes)
        {
            int countOfAllUnits = GetCountOfAllUnits(locationId, facilityTypeCodes);
            OccupancyRecord record = new OccupancyRecord
            {
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

        public static int GetCountOfAllUnits(int locationId, List<string> facilityTypeCodes)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            return conn.ExecuteScalar<int>("SELECT COUNT(UnitID) FROM ingUnits WHERE Location = @LocationId AND FacilityType IN @FacilityTypeCodes",
                new { LocationId = locationId, FacilityTypeCodes = facilityTypeCodes });
        }

        public static Location GetLocation(int id)
        {
            string sql = "SELECT * FROM ingLocations WHERE Id = @LocationId";
            using var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            connection.Open();

            using var multi = connection.QueryMultiple(sql, new { LocationId = id });
            var Location = multi.Read<Location>().First();
            return Location;
        }

        public static List<FacilityType> GetFacilityTypesByLocation(int locationId)
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
    }
}
