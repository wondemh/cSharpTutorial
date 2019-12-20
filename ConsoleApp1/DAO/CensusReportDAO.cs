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
    public static class CensusReportDAO
    {
        public static Location GetLocation(int id)
        {
            string sql = "SELECT * FROM ingLocations WHERE Id = @LocationId";
            using var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            connection.Open();

            using var multi = connection.QueryMultiple(sql, new { LocationId = id });
            var Location = multi.Read<Location>().First();
            return Location;
        }

        public static FacilityType GetFacilityType(int locationId, string facilityTypeCode)
        {
            string sql = "SELECT Location, FacilityType AS FacilType, Title, DisplayOrder, ChartColor FROM ingFacilityTypes WHERE Location = @LocationId AND FacilityType = @FacilityTypeCode";
            using var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            connection.Open();

            using var multi = connection.QueryMultiple(sql, new { LocationId = locationId, FacilityTypeCode = facilityTypeCode });
            var facilityType = multi.Read<FacilityType>().First();
            return facilityType;
        }

        public static AdmissionStatusRecord GetAdmissionStatus(int locationId, string facilityTypeCode, string admissionStatusCode)
        {
            string sql = "SELECT * FROM ingAdmitCodes WHERE Location = @LocationId AND FacilityType = @FacilityTypeCode AND AdmissionStatus = @AdmissionStatusCode";
            using var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            connection.Open();
            using var multi = connection.QueryMultiple(sql, new { LocationId = locationId, FacilityTypeCode = facilityTypeCode, AdmissionStatusCode = admissionStatusCode });
            var admissionStatusRecord = multi.Read<AdmissionStatusRecord>().First();
            return admissionStatusRecord;
        }

        public static List<CensusItem> GetCensusRecords(int locationId, DateTime startDate, DateTime endDate, string facilityTypeCode)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            return conn.Query<CensusItem>("ing_getCensusRecords", new { LocationId = locationId, StartDate = startDate, EndDate = endDate, FacilityTypeCode = facilityTypeCode }, commandType: CommandType.StoredProcedure).ToList();
        }

        public static List<Unit> GetVacantUnits(int locationId, string facilityTypeCode, DateTime date)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            return conn.Query<Unit>(new StringBuilder()
                .Append("SELECT * FROM ingUnits ") //
                .Append("WHERE ") //
                .Append("   Location = @LocationId ") //
                .Append("   AND FacilityType = @FacilityTypeCode ") //
                .Append("   AND (@DateParam BETWEEN ISNULL(AvailabilityStart, @DateParam - 1) AND ISNULL(AvailabilityEnd, @DateParam + 1))")
                .ToString(), 
                new { LocationId = locationId, FacilityTypeCode = facilityTypeCode, DateParam = date }).ToList();
        }

        public static int GetCountOfAllUnits(int locationId, string facilityTypeCode)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            return conn.ExecuteScalar<int>("SELECT COUNT(UnitID) FROM ingUnits WHERE Location = @LocationId AND FacilityType = @FacilityTypeCode",
                new { LocationId = locationId, FacilityTypeCode = facilityTypeCode});
        }
    }
}
