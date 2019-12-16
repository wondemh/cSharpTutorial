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
    static class AssistedLivingDAO
    {
        public static OccupancyRecord GetAverageFFS(int locationId, List<string> facilityTypeCodes)
        {
            return new OccupancyRecord();
        }

        internal static OccupancyRecord GetAverageLC()
        {
            return new OccupancyRecord();
        }
    }
}
