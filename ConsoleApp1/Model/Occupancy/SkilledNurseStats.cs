using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class SkilledNurseStats
    {
        public OccupancyRecord BedsAvailable { get; set; }
        public OccupancyRecord AverageLCFirst { get; set; }
        public OccupancyRecord AverageLCSecond { get; set; }
        public OccupancyRecord FFSDirectAdmit { get; set; }
        public OccupancyRecord AverageMemoryCare { get; set; }
        public OccupancyRecord AverageMedicare { get; set; }
        public OccupancyRecord AverageMedicaid { get; set; }
        public OccupancyRecord TotalAverageOccupancy { get; set; }
        public OccupancyRecord PercentOccupancy { get; set; }

    }
}
