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
    class MemorySupportDAO : OccupancyReportDAO
    {
        public OccupancyRecord getPrivateMCSecondPersonData(int locationId, List<string> facilityTypeCodes)
        {
            return null;
        }

        public OccupancyRecord getPrivateMCFirstPersonData(int locationId, List<string> facilityTypeCodes)
        {
            return null;
        }

        public OccupancyRecord getLicensedForData(int locationId, List<string> facilityTypeCodes)
        {
            return null;
        }
    }
}
