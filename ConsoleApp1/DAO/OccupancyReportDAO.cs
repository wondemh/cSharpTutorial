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
    public enum LocationCode
    {
        IRC = 1,
        IKF = 3,
        WLR = 4
    };

    internal static class OccupancyReportDAO
    {

        internal static OccupancyRecord GetBudgetData(LocationCode locationId, string facilityTypeCode, string name, int year)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            Dictionary<int, int> results = conn.Query(
                new StringBuilder()
                .Append("SELECT Month, Value ")
                .Append("FROM ")
                .Append("   ingBudgetLookup ")
                .Append("WHERE Location = @LocationId ")
                .Append("   AND FacilityType = @FacilityTypeCode ")
                .Append("   AND Year = @Year ")
                .Append("   AND Name = @Name ").ToString(),
                new { LocationId = (int)locationId, FacilityTypeCode = facilityTypeCode, Year = year, Name = name, })
                .ToDictionary(
                    row => (int)row.Month,
                    row => (int)row.Value
                );
            OccupancyRecord record = new OccupancyRecord
            {
                January = results.GetValueOrDefault(1, 0),
                February = results.GetValueOrDefault(2, 0),
                March = results.GetValueOrDefault(3, 0),
                April = results.GetValueOrDefault(4, 0),
                May = results.GetValueOrDefault(5, 0),
                June = results.GetValueOrDefault(6, 0),
                July = results.GetValueOrDefault(7, 0),
                August = results.GetValueOrDefault(8, 0),
                September = results.GetValueOrDefault(9, 0),
                October = results.GetValueOrDefault(10, 0),
                November = results.GetValueOrDefault(11, 0),
                December = results.GetValueOrDefault(12, 0)
            };
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }

        public static OccupancyRecord GetUnitsAvailableData(LocationCode locationId, List<string> facilityTypeCodes)
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

        internal static int GetCountOfAllUnits(LocationCode locationId, List<string> facilityTypeCodes)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            return conn.ExecuteScalar<int>("SELECT COUNT(UnitID) FROM ingUnits WHERE Location = @LocationId AND FacilityType IN @FacilityTypeCodes",
                new { LocationId = (int)locationId, FacilityTypeCodes = facilityTypeCodes });
        }

        internal static Location GetLocation(LocationCode id)
        {
            string sql = "SELECT * FROM ingLocations WHERE Id = @LocationId";
            using var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            connection.Open();

            using var multi = connection.QueryMultiple(sql, new { LocationId = (int)id });
            var Location = multi.Read<Location>().First();
            return Location;
        }

        internal static OccupancyRecord GetCensusCountDailyAverages(LocationCode locationId, List<string> facilityTypeCodes, DateTime reportDate, List<string> levelsOfCare = null, string payorTypeCode = null)
        {
            int year = reportDate.Year;
            OccupancyRecord record = new OccupancyRecord
            {
                January = GetCensusCountDailyAverage(locationId, facilityTypeCodes, year, 1, levelsOfCare, payorTypeCode),
                February = GetCensusCountDailyAverage(locationId, facilityTypeCodes, year, 2, levelsOfCare, payorTypeCode),
                March = GetCensusCountDailyAverage(locationId, facilityTypeCodes, year, 3, levelsOfCare, payorTypeCode),
                April = GetCensusCountDailyAverage(locationId, facilityTypeCodes, year, 4, levelsOfCare, payorTypeCode),
                May = GetCensusCountDailyAverage(locationId, facilityTypeCodes, year, 5, levelsOfCare, payorTypeCode),
                June = GetCensusCountDailyAverage(locationId, facilityTypeCodes, year, 6, levelsOfCare, payorTypeCode),
                July = GetCensusCountDailyAverage(locationId, facilityTypeCodes, year, 7, levelsOfCare, payorTypeCode),
                August = GetCensusCountDailyAverage(locationId, facilityTypeCodes, year, 8, levelsOfCare, payorTypeCode),
                September = GetCensusCountDailyAverage(locationId, facilityTypeCodes, year, 9, levelsOfCare, payorTypeCode),
                October = GetCensusCountDailyAverage(locationId, facilityTypeCodes, year, 10, levelsOfCare, payorTypeCode),
                November = GetCensusCountDailyAverage(locationId, facilityTypeCodes, year, 11, levelsOfCare, payorTypeCode),
                December = GetCensusCountDailyAverage(locationId, facilityTypeCodes, year, 12, levelsOfCare, payorTypeCode)
            };
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }

        internal static OccupancyRecord GetCensusCountDailyAveragesByPayorTypes(LocationCode locationId, List<string> facilityTypeCodes, DateTime reportDate, List<string> payorTypeCodes)
        {
            int year = reportDate.Year;
            OccupancyRecord record = new OccupancyRecord
            {
                January = GetCensusCountDailyAverageByPayorTypes(locationId, facilityTypeCodes, year, 1, payorTypeCodes),
                February = GetCensusCountDailyAverageByPayorTypes(locationId, facilityTypeCodes, year, 2, payorTypeCodes),
                March = GetCensusCountDailyAverageByPayorTypes(locationId, facilityTypeCodes, year, 3, payorTypeCodes),
                April = GetCensusCountDailyAverageByPayorTypes(locationId, facilityTypeCodes, year, 4, payorTypeCodes),
                May = GetCensusCountDailyAverageByPayorTypes(locationId, facilityTypeCodes, year, 5, payorTypeCodes),
                June = GetCensusCountDailyAverageByPayorTypes(locationId, facilityTypeCodes, year, 6, payorTypeCodes),
                July = GetCensusCountDailyAverageByPayorTypes(locationId, facilityTypeCodes, year, 7, payorTypeCodes),
                August = GetCensusCountDailyAverageByPayorTypes(locationId, facilityTypeCodes, year, 8, payorTypeCodes),
                September = GetCensusCountDailyAverageByPayorTypes(locationId, facilityTypeCodes, year, 9, payorTypeCodes),
                October = GetCensusCountDailyAverageByPayorTypes(locationId, facilityTypeCodes, year, 10, payorTypeCodes),
                November = GetCensusCountDailyAverageByPayorTypes(locationId, facilityTypeCodes, year, 11, payorTypeCodes),
                December = GetCensusCountDailyAverageByPayorTypes(locationId, facilityTypeCodes, year, 12, payorTypeCodes)
            };
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }

        private static float GetCensusCountDailyAverage(LocationCode locationId, List<string> facilityTypeCodes, int year, int month, List<string> levelsOfCare = null, string payorTypeCode = null)
        {
            DynamicParameters parameters = new DynamicParameters(new { LocationId = (int)locationId, FacilityTypeCodes = facilityTypeCodes, Year = year, Month = month });
            if (levelsOfCare != null)
            {
                parameters.Add("LevelsOfCare", levelsOfCare);
            }
            if (payorTypeCode != null)
            {
                parameters.Add("PayorTypeCode", payorTypeCode);
            }

            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            Dictionary<DateTime, int> results = conn.Query(
                new StringBuilder()
                .Append("SELECT CensusDate, COUNT(1) as CountOfRecords ")
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
                .Append(levelsOfCare != null ? "   AND ingCensus.LevelOfCare IN @LevelsOfCare " : "")
                .Append("   AND YEAR(ingCensus.CensusDate) = @Year ")
                .Append("   AND Month(ingCensus.CensusDate) = @Month ")
                .Append(payorTypeCode != null ? "   AND PayorType = @PayorTypeCode " : "")
                .Append("   GROUP BY ingCensus.CensusDate ").ToString(), parameters)
                .ToDictionary(
                    row => (DateTime)row.CensusDate,
                    row => (int)row.CountOfRecords
                );
            float averageForMonth = results.Count > 0 ? results.Sum(x => x.Value) / results.Count : 0;
            return (float)Math.Round(averageForMonth, 1);
        }

        private static float GetCensusCountDailyAverageByPayorTypes(LocationCode locationId, List<string> facilityTypeCodes, int year, int month, List<string> payorTypeCodes)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            Dictionary<DateTime, int> results = conn.Query(
                new StringBuilder()
                .Append("SELECT CensusDate, COUNT(1) as CountOfRecords ")
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
                .Append("   AND Month(ingCensus.CensusDate) = @Month ")
                .Append("   AND PayorType IN @PayorTypeCodes ")
                .Append("   GROUP BY ingCensus.CensusDate ").ToString(),
                new { LocationId = (int)locationId, FacilityTypeCodes = facilityTypeCodes, Year = year, Month = month, PayorTypeCodes = payorTypeCodes })
                .ToDictionary(
                    row => (DateTime)row.CensusDate,
                    row => (int)row.CountOfRecords
                );
            float averageForMonth = results.Count > 0 ? results.Sum(x => x.Value) / results.Count : 0;
            return (float)Math.Round(averageForMonth, 1);
        }

    }
}
