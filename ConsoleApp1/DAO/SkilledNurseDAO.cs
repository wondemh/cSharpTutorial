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
        internal static OccupancyRecord GetBedsAvailableData(LocationCode locationId, List<string> facilityTypeCodes, int year, int month)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.December;
            return record;
        }

        public static OccupancyRecord GetAverageLCFirstData(LocationCode locationId, List<string> facilityTypeCodes, int year, int month)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }

        public static OccupancyRecord GetAverageLCSecondData(LocationCode locationId, List<string> facilityTypeCodes, int year, int month)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }
        public static OccupancyRecord GetFFSDirectAdmitData(LocationCode locationId, List<string> facilityTypeCodes, int year, int month)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }

        public static OccupancyRecord GetAverageMemoryCareData(LocationCode locationId, List<string> facilityTypeCodes, int year, int month)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }

        internal static OccupancyRecord GetAverageMedicareData(LocationCode locationId, List<string> facilityTypeCodes, int year, int month)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }

        internal static OccupancyRecord GetAverageMedicaidData(LocationCode locationId, List<string> facilityTypeCodes, int year, int month)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }
    }
}
