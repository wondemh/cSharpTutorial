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
            using var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            connection.Open();

            using var multi = connection.QueryMultiple(sql, new { LocationId = id });
            var Location = multi.Read<Location>().First();
            return Location;
        }

        public FacilityType GetFacilityType(int locationId, string facilityTypeCode)
        {
            string sql = "SELECT Location, FacilityType AS FacilType, Title, DisplayOrder, ChartColor FROM ingFacilityTypes WHERE Location = @LocationId AND FacilityType = @FacilityTypeCode";
            using var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            connection.Open();

            using var multi = connection.QueryMultiple(sql, new { LocationId = locationId, FacilityTypeCode = facilityTypeCode });
            var facilityType = multi.Read<FacilityType>().First();
            return facilityType;
        }

        public List<FacilityType> GetFactilityTypesByLocation(int locationId)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            return conn.Query<FacilityType>(
                new StringBuilder()
                .Append("SELECT Location, FacilityType AS FacilType, FacTypeCode, Title, DisplayOrder, ChartColor ")
                .Append("FROM ingLocations INNER JOIN ingFacilityTypes ON ingLocations.Id = ingFacilityTypes.Location ")
                .Append("WHERE ingLocations.Id = @LocationId ")
                .Append("   AND ingFacilityTypes.DisplayOrder > 0 ")
                .Append("ORDER BY ingFacilityTypes.DisplayOrder ")
                .ToString(), new { LocationId = locationId, }).ToList();
        }

        public AdmissionStatusRecord GetAdmissionStatus(int locationId, string facilityTypeCode, string admissionStatusCode)
        {
            string sql = "SELECT * FROM ingAdmitCodes WHERE Location = @LocationId AND FacilityType = @FacilityTypeCode AND AdmissionStatus = @AdmissionStatusCode";
            using var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            connection.Open();
            using var multi = connection.QueryMultiple(sql, new { LocationId = locationId, FacilityTypeCode = facilityTypeCode, AdmissionStatusCode = admissionStatusCode });
            var admissionStatusRecord = multi.Read<AdmissionStatusRecord>().First();
            return admissionStatusRecord;
        }

        public List<CensusItem> GetCensusRecords(int locationId, DateTime startDate, DateTime endDate, string facilityTypeCode)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            return conn.Query<CensusItem>("ing_getWLRCensusRecords", new { LocationId = locationId, StartDate = startDate, EndDate = endDate, FacilityTypeCode = facilityTypeCode }, commandType: CommandType.StoredProcedure).ToList();
        }

        public List<Unit> GetVacantUnits(int locationId, string facilityTypeCode, DateTime date)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            return conn.Query<Unit>(
                new StringBuilder()
                .Append("SELECT * FROM ingUnits ") //
                .Append("WHERE ") //
                .Append("   Location = @LocationId ") //
                .Append("   AND FacilityType = @FacilityTypeCode ") //
                .Append("   AND (@DateParam BETWEEN ISNULL(AvailabilityStart, @DateParam - 1) AND ISNULL(AvailabilityEnd, @DateParam + 1))")
                .ToString(), 
                new { LocationId = locationId, FacilityTypeCode = facilityTypeCode, DateParam = date }).ToList();
        }

        public int GetCountOfAllUnits(int locationId, string facilityTypeCode)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            return conn.ExecuteScalar<int>("SELECT COUNT(UnitID) FROM ingUnits WHERE Location = @LocationId AND FacilityType = @FacilityTypeCode",
                new { LocationId = locationId, FacilityTypeCode = facilityTypeCode });
        }

        public int GetBeginningOccupancy(int locationId, string facilityTypeCode, int year, int month)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            return conn.ExecuteScalar<int>(
                new StringBuilder()
                .Append("SELECT StartOccupancy FROM ingOccupancyBase ") //
                .Append("WHERE Location = @LocationId ") //
                .Append("   AND FacilityType = @FacilityTypeCode ") //
                .Append("   AND Year = @Year ")
                .Append("   AND Month = @Month ")
                .ToString(), 
                new { LocationId = locationId, FacilityTypeCode = facilityTypeCode, Year = year, Month = month });
        }

        public int GetCountOfMoveIns(int locationId, string facilityTypeCode, int year, int month)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            return conn.ExecuteScalar<int>(
                new StringBuilder()
                .Append("SELECT COUNT(UnitID) ")
                .Append("FROM ingCensus ")
                .Append("WHERE Location = @LocationId ")
                .Append("   AND FacilityType = @FacilityTypeCode ")
                .Append("   AND AdmissionStatus IN ('A') ")
                .Append("   AND YEAR(CensusDate) = @Year ")
                .Append("   AND Month(CensusDate) = @Month ").ToString(),
                new { LocationId = locationId, FacilityTypeCode = facilityTypeCode, Year = year, Month = month });
        }

        public int GetCountOfMoveOuts(int locationId, string facilityTypeCode, int year, int month)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            return conn.ExecuteScalar<int>(
                new StringBuilder()
                .Append("SELECT COUNT(UnitID) ")
                .Append("FROM ingCensus ")
                .Append("WHERE Location = @LocationId ")
                .Append("   AND FacilityType = @FacilityTypeCode ")
                .Append("   AND AdmissionStatus IN ('PT', 'TT', 'D', 'DH', 'L') ")
                .Append("   AND YEAR(CensusDate) = @Year ")
                .Append("   AND Month(CensusDate) = @Month ").ToString(),
                new { LocationId = locationId, FacilityTypeCode = facilityTypeCode, Year = year, Month = month });
        }
       
    }
}
