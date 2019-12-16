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
    class SkilledNurseDAO
    {
        public OccupancyRecord GetBeginningOccupancyData(int locationId, List<string> facilityTypeCodes, int year)
        {
            OccupancyRecord record = new OccupancyRecord
            {
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

        internal OccupancyRecord GetAverageMedicaidData(int locationId, List<string> facilityTypeCodes, int year, int month)
        {
            return new OccupancyRecord();
        }

        internal OccupancyRecord GetAverageMedicareData(int locationId, List<string> facilityTypeCodes, int year, int month)
        {
            return new OccupancyRecord();
        }

        public OccupancyRecord GetAverageMemoryCareData(int locationId, List<string> facilityTypeCodes, int year, int month)
        {
            return new OccupancyRecord();
        }

        public OccupancyRecord GetFFSDirectAdmitData(int locationId, List<string> facilityTypeCodes, int year, int month)
        {
            return new OccupancyRecord();
        }

        public OccupancyRecord GetAverageLCSecondData(int locationId, List<string> facilityTypeCodes, int year, int month)
        {
            return new OccupancyRecord();
        }

        public OccupancyRecord GetAverageLCFirstData(int locationId, List<string> facilityTypeCodes, int year, int month)
        {
            return new OccupancyRecord();
        }

        internal OccupancyRecord GetBedsAvailableData(int locationId, List<string> facilityTypeCodes, int year, int month)
        {
            return new OccupancyRecord();
        }

        public OccupancyRecord GetCensusCountsByMonth(int locationId, List<string> facilityTypeCodes, List<String> admissionStatusCodes, int year)
        {
            OccupancyRecord record = new OccupancyRecord
            {
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

        private int GetBeginningOccupancy(int locationId, List<string> facilityTypeCodes, int year, int month)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            return conn.ExecuteScalar<int>(
                new StringBuilder()
                .Append("SELECT StartOccupancy FROM ingOccupancyBase ") //
                .Append("WHERE Location = @LocationId ") //
                .Append("   AND FacilityType IN @FacilityTypeCodes ") //
                .Append("   AND Year = @Year ")
                .Append("   AND Month = @Month ")
                .ToString(),
                new { LocationId = locationId, FacilityTypeCodes = facilityTypeCodes, Year = year, Month = month });
        }

        private int GetCensusCount(int locationId, List<string> facilityTypeCodes, List<string> admissionStatusCodes, int year, int month)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            return conn.ExecuteScalar<int>(
                new StringBuilder()
                .Append("SELECT COUNT(UnitID) ")
                .Append("FROM ingCensus ")
                .Append("WHERE Location = @LocationId ")
                .Append("   AND FacilityType IN @FacilityTypeCodes ")
                .Append("   AND AdmissionStatus IN @AdmissionStatusCodes ")
                .Append("   AND YEAR(CensusDate) = @Year ")
                .Append("   AND Month(CensusDate) = @Month ").ToString(),
                new { LocationId = locationId, FacilityTypeCodes = facilityTypeCodes, AdmissionStatusCodes = admissionStatusCodes, Year = year, Month = month });
        }
    }
}
