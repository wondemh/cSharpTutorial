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
    public static class MemorySupportDAO
    {

        public static OccupancyRecord GetLicensedForData(int locationId, List<string> facilityTypeCodes)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverageValue = record.DecemberValue;
            return record;
        }
        public static OccupancyRecord GetPrivateMCFirstPersonData(int locationId, List<string> facilityTypeCodes)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverageValue = record.CalculateAverageValue();
            return record;
        }
        public static OccupancyRecord GetPrivateMCSecondPersonData(int locationId, List<string> facilityTypeCodes)
        {
            OccupancyRecord record = new OccupancyRecord();
            record.TotalOrAverageValue = record.CalculateAverageValue();
            return record;
        }

        

        
    }
}