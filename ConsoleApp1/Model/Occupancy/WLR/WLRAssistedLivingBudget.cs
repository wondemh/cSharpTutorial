using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class WLRAssistedLivingBudget
    {
        public OccupancyRecord AverageFFSFirst { get; set; }
        public OccupancyRecord AverLCFirst { get; set; }
        public OccupancyRecord EndingAverageOccupance { get; set; }
        public OccupancyRecord VarianceFromBudget { get; set; }
        public OccupancyRecord PercentOccupancy { get; set; }
    }
}
