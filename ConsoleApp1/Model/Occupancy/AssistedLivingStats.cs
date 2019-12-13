using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class AssistedLivingStats
    {
        public OccupancyRecord UnitsAvailable { get; set; }
        public OccupancyRecord AverageFFS { get; set; }
        public OccupancyRecord AverageLC { get; set; }
        public OccupancyRecord AverageOccupancy { get; set; }
        public OccupancyRecord PercentUnitOccupancy { get; set; }
        public OccupancyRecord UnoccupiedUnits { get; set; }

    }
}
