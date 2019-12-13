using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class AssistedLivingMemorySupportStats
    {
        public OccupancyRecord UnitsAvailable { get; set; }
        public OccupancyRecord LicensedFor { get; set; }
        public OccupancyRecord PrivateMCFirstPerson { get; set; }
        public OccupancyRecord PrivateMCSecondPerson { get; set; }
        public OccupancyRecord EndingAverageOccupancy { get; set; }
        public OccupancyRecord PercentAverageUnitOccupancy { get; set; }
        public OccupancyRecord AverageUnoccupiedUnits { get; set; }
        public OccupancyRecord EndingAveragePersonOccupancy { get; set; }
        public OccupancyRecord PercentLicensedOccupancy { get; set; }

    }
}
