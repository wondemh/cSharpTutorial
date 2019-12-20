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
        internal OccupancyRecord GetBedsAvailableData(int locationId, List<string> facilityTypeCodes, int year, int month)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.December;
            return record;
        }

        public OccupancyRecord GetAverageLCFirstData(int locationId, List<string> facilityTypeCodes, int year, int month)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }

        public OccupancyRecord GetAverageLCSecondData(int locationId, List<string> facilityTypeCodes, int year, int month)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }
        public OccupancyRecord GetFFSDirectAdmitData(int locationId, List<string> facilityTypeCodes, int year, int month)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }

        public OccupancyRecord GetAverageMemoryCareData(int locationId, List<string> facilityTypeCodes, int year, int month)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }
        internal OccupancyRecord GetAverageMedicareData(int locationId, List<string> facilityTypeCodes, int year, int month)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }
        internal OccupancyRecord GetAverageMedicaidData(int locationId, List<string> facilityTypeCodes, int year, int month)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }
    }
}
