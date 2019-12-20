using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IKFMemorySupportBudget
    {
        public OccupancyRecord PrivateMCFirstPerson { get; set; }
        public OccupancyRecord PrivateMCSecondtPerson { get; set; }
        public OccupancyRecord EndingAverageOccupancy { get; set; }
        public OccupancyRecord EndingAverageOccupancyVarianceFromBudget { get; set; }
        public OccupancyRecord EndingAvgPersonOccupancy { get; set; }
        public OccupancyRecord EndingAvgPersonOccupancyVarianceFromBudget { get; set; }

    }
}
