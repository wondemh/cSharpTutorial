﻿using Dapper;
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

    public static class OccupancyReportDAO
    {
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

        public static int GetCountOfAllUnits(LocationCode locationId, List<string> facilityTypeCodes)
        {
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            return conn.ExecuteScalar<int>("SELECT COUNT(UnitID) FROM ingUnits WHERE Location = @LocationId AND FacilityType IN @FacilityTypeCodes",
                new { LocationId = (int)locationId, FacilityTypeCodes = facilityTypeCodes });
        }

        public static Location GetLocation(LocationCode id)
        {
            string sql = "SELECT * FROM ingLocations WHERE Id = @LocationId";
            using var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ingAnalyticsConnection"].ConnectionString);
            connection.Open();

            using var multi = connection.QueryMultiple(sql, new { LocationId = (int)id });
            var Location = multi.Read<Location>().First();
            return Location;
        }

        public static OccupancyRecord GetCensusCountDailyAverages(LocationCode locationId, List<string> facilityTypeCodes, List<string> levelsOfCare, DateTime reportDate, string payorTypeCode = null)
        {
            int year = reportDate.Year;
            OccupancyRecord record = new OccupancyRecord
            {
                January = GetCensusCountDailyAverage(locationId, facilityTypeCodes, levelsOfCare, year, 1, payorTypeCode),
                February = GetCensusCountDailyAverage(locationId, facilityTypeCodes, levelsOfCare, year, 2, payorTypeCode),
                March = GetCensusCountDailyAverage(locationId, facilityTypeCodes, levelsOfCare, year, 3, payorTypeCode),
                April = GetCensusCountDailyAverage(locationId, facilityTypeCodes, levelsOfCare, year, 4, payorTypeCode),
                May = GetCensusCountDailyAverage(locationId, facilityTypeCodes, levelsOfCare, year, 5, payorTypeCode),
                June = GetCensusCountDailyAverage(locationId, facilityTypeCodes, levelsOfCare, year, 6, payorTypeCode),
                July = GetCensusCountDailyAverage(locationId, facilityTypeCodes, levelsOfCare, year, 7, payorTypeCode),
                August = GetCensusCountDailyAverage(locationId, facilityTypeCodes, levelsOfCare, year, 8, payorTypeCode),
                September = GetCensusCountDailyAverage(locationId, facilityTypeCodes, levelsOfCare, year, 9, payorTypeCode),
                October = GetCensusCountDailyAverage(locationId, facilityTypeCodes, levelsOfCare, year, 10, payorTypeCode),
                November = GetCensusCountDailyAverage(locationId, facilityTypeCodes, levelsOfCare, year, 11, payorTypeCode),
                December = GetCensusCountDailyAverage(locationId, facilityTypeCodes, levelsOfCare, year, 12, payorTypeCode)
            };
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }

        private static float GetCensusCountDailyAverage(LocationCode locationId, List<string> facilityTypeCodes, List<string> levelsOfCare, int year, int month, string payorTypeCode = null)
        {
            DynamicParameters parameters = new DynamicParameters(new { LocationId = (int)locationId, FacilityTypeCodes = facilityTypeCodes, LevelsOfCare = levelsOfCare, Year = year, Month = month });
            if (payorTypeCode != null)
            {
                parameters.Add("PayorType", payorTypeCode);
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
                .Append("   AND ingCensus.LevelOfCare IN @LevelsOfCare ")
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

    }
}
