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

        public List<WLRCensusRecord> GetWLRCensusRecords(int locationId, DateTime startDate, DateTime endDate, string facilityTypeCode)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["myConnectionString"];
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            return conn.Query<WLRCensusRecord>(getReportSQL(), new { LocationId = locationId, StartDate = startDate, EndDate = endDate, FacilityTypeCode = facilityTypeCode}).ToList();
        }

        private string getReportSQL()
        {
            StringBuilder b = new StringBuilder();
            b.Append("SELECT ") //
            .Append("   A.LastName, ") //
            .Append("   A.FirstName, ") //
            .Append("   A.MidInit, ") //
            .Append("   B.ResidentID, ") //
            .Append("   B.AdmissionNumber, ") //
            .Append("   B.PayorType, ") //
            .Append("   B.AdmissionStatus, ") //
            .Append("   '<<DischargeTo>>' AS DischargeTo, ") //
            .Append("   C.UnitNumber, ") //
            .Append("   C.UnitType, ") //
            .Append("   C.Building AS UnitLocation, ") //
            .Append("   A.LevelOfCare ") //
            .Append("FROM ") //
            .Append("   ingResidents A, ") //
            .Append("   ingCensus B, ") //
            .Append("   ingUnits C, ") //
            .Append("   ingFacilityTypes D ") //
            .Append("WHERE ") //
            .Append("   B.ResidentID = A.ResidentID ") //
            .Append("   AND C.UnitID = B.UnitID ") //
            .Append("   AND D.Location = c.Location ") //
            .Append("   AND D.FacilityType = C.FacilityType ") //
            .Append("   AND B.CensusDate BETWEEN @StartDate AND @EndDate ") //
            .Append("   AND D.FacilityType = @FacilityTypeCode ") //
            .Append("   AND D.Location = @LocationId ") //
            .Append("ORDER BY B.PayorType, B.AdmissionStatus ");
            return b.ToString();
        }
    }
}
