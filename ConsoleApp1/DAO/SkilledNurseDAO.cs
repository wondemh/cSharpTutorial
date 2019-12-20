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
        internal OccupancyRecord GetBedsAvailableData(LocationCodes locationId, List<string> facilityTypeCodes, int year, int month)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.December;
            return record;
        }

        public OccupancyRecord GetAverageLCFirstData(LocationCodes locationId, List<string> facilityTypeCodes, int year, int month)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }

        public OccupancyRecord GetAverageLCSecondData(LocationCodes locationId, List<string> facilityTypeCodes, int year, int month)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }
        public OccupancyRecord GetFFSDirectAdmitData(LocationCodes locationId, List<string> facilityTypeCodes, int year, int month)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }

        public OccupancyRecord GetAverageMemoryCareData(LocationCodes locationId, List<string> facilityTypeCodes, int year, int month)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }

        internal OccupancyRecord GetAverageMedicareData(LocationCodes locationId, List<string> facilityTypeCodes, int year, int month)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }

        internal OccupancyRecord GetAverageMedicaidData(LocationCodes locationId, List<string> facilityTypeCodes, int year, int month)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }
    }
}
