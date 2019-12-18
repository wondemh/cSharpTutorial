using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class SkilledNurseBudget
    {
        public OccupancyRecord AverageLCFirst { get; set; }
        public OccupancyRecord LCFirstVarianceFromBudget { get; set; }
        public OccupancyRecord AverageLCSecond { get; set; }
        public OccupancyRecord LCSecondVarianceFromBudget { get; set; }
        public OccupancyRecord MemoryCare { get; set; }
        public OccupancyRecord MemoryCareVarianceFromBudget { get; set; }
        public OccupancyRecord FFSDirectAdmit { get; set; }
        public OccupancyRecord FFSDirectAdmitVarianceFromBudget { get; set; }
        public OccupancyRecord Medicare { get; set; }
        public OccupancyRecord MedicareVarianceFromBudget { get; set; }
        public OccupancyRecord Medicaid { get; set; }
        public OccupancyRecord MedicaidVarianceFromBudget { get; set; }
        public OccupancyRecord TotalOccupancy { get; set; }
        public OccupancyRecord TotalOccupancyVarianceFromBudget { get; set; }
    }
}
