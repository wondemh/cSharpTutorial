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
    public static class MemorySupportDAO
    {

        public static OccupancyRecord GetLicensedForData(LocationCode locationId, List<string> facilityTypeCodes)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.December;
            return record;
        }
        public static OccupancyRecord GetPrivateMCFirstPersonData(LocationCode locationId, List<string> facilityTypeCodes)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }
        public static OccupancyRecord GetPrivateMCSecondPersonData(LocationCode locationId, List<string> facilityTypeCodes)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverage = record.CalculateAverageValue();
            return record;
        }

        

        
    }
}
