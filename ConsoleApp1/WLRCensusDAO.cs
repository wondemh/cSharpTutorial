using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
    class WLRCensusDAO
    {
        public Location GetLocation(int id)
        {
            string sql = "SELECT * FROM ingLocations WHERE Id = @LocationId";
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                connection.Open();

                using (var multi = connection.QueryMultiple(sql, new { LocationId = id }))
                {
                    var Location = multi.Read<Location>().First();
                    return Location;
                }
            }
        }

        public AdmissionStatusRecord GetAdmissionStatus(int locationId, string facilityTypeCode, string admissionStatusCode)
        {
            string sql = "SELECT * FROM ingAdmitCodes WHERE Location = @LocationId AND FacilityType = @FacilityTypeCode AND AdmissionStatus = @AdmissionStatusCode";
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                connection.Open();
                using (var multi = connection.QueryMultiple(sql, new { LocationId = locationId, FacilityTypeCode = facilityTypeCode, AdmissionStatusCode = admissionStatusCode }))
                {
                    var admissionStatusRecord = multi.Read<AdmissionStatusRecord>().First();
                    return admissionStatusRecord;
                }
            }
        }

        public List<WLRCensusRecord> GetWLRCensusRecords(int locationId, DateTime startDate, DateTime endDate, string facilityTypeCode)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["myConnectionString"];
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            return conn.Query<WLRCensusRecord>("ing_getWLRCensusRecords", new { LocationId = locationId, StartDate = startDate, EndDate = endDate, FacilityTypeCode = facilityTypeCode }, commandType: CommandType.StoredProcedure).ToList();
        }

        public List<Unit> GetVacantUnits(DateTime date)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["myConnectionString"];
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            return conn.Query<Unit>(getVacantUnitsQuery(), new { DateParam = date }).ToList();
        }

        public int GetCountOfAllUnits()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["myConnectionString"];
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            return conn.ExecuteScalar<int>("SELECT COUNT(UnitID) FROM ingUnits");
        }

        private string getVacantUnitsQuery()
        {
            return new StringBuilder()
                .Append("SELECT * FROM ingUnits ") //
                .Append("WHERE @DateParam BETWEEN ISNULL(AvailabilityStart, @DateParam - 1) AND ISNULL(AvailabilityEnd, @DateParam + 1)")
                .ToString();
        }
    }
}
