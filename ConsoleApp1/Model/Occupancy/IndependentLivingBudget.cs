using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IndependentLivingBudget
    {
        public OccupancyRecord BeginningOccupancy { get; set; }
        public OccupancyRecord MoveIns { get; set; }
        public OccupancyRecord MoveOuts { get; set; }
        public OccupancyRecord EndingOccupancy { get; set; }
        public OccupancyRecord PercenOccupancy{ get; set; }
        public OccupancyRecord VarianceFromBudget { get; set; }
    }
}
