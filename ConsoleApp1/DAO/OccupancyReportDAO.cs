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
    public enum LocationCodes
    {
        IRC = 1,
        IKF = 3,
        WLR = 4
    };

    public static class OccupancyReportDAO
    {
        public static OccupancyRecord GetUnitsAvailableData(LocationCodes locationId, List<string> facilityTypeCodes)
        {
            int countOfAllUnits = GetCountOfAllUnits(locationId, facilityTypeCodes);
            OccupancyRecord record = new OccupancyRecord
            {
                January = countOfAllUnits,
                February = countOfAllUnits,
                March = countOfAllUnits,
                April = countOfAllUnits,
                May = countOfAllUnits,
                June = countOfAllUnits,
                July = countOfAllUnits,
                August = countOfAllUnits,
                September = countOfAllUnits,
                October = countOfAllUnits,
                November = countOfAllUnits,
                December = countOfAllUnits,
                TotalOrAverage = countOfAllUnits
            };
            return record;
        }

        public static int GetCountOfAllUnits(LocationCodes locationId, List<string> facilityTypeCodes)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            return conn.ExecuteScalar<int>("SELECT COUNT(UnitID) FROM ingUnits WHERE Location = @LocationId AND FacilityType IN @FacilityTypeCodes",
                new { LocationId = (int)locationId, FacilityTypeCodes = facilityTypeCodes });
        }

        public static Location GetLocation(LocationCodes id)
        {
            string sql = "SELECT * FROM ingLocations WHERE Id = @LocationId";
            using var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            connection.Open();

            using var multi = connection.QueryMultiple(sql, new { LocationId = (int)id });
            var Location = multi.Read<Location>().First();
            return Location;
        }

        public static List<FacilityType> GetFacilityTypesByLocation(LocationCodes locationId)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            return conn.Query<FacilityType>(
                new StringBuilder()
                .Append("SELECT Location, FacilityType AS FacilType, FacTypeCode, Title, DisplayOrder, ChartColor ")
                .Append("FROM ingLocations INNER JOIN ingFacilityTypes ON ingLocations.Id = ingFacilityTypes.Location ")
                .Append("WHERE ingLocations.Id = @LocationId ")
                .Append("   AND ingFacilityTypes.DisplayOrder > 0 ")
                .Append("ORDER BY ingFacilityTypes.DisplayOrder ")
                .ToString(), new { LocationId = (int)locationId, }).ToList();
        }
    }
}
