using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model
{
    public class Unit
    {
        public Guid UnitID { get; set; }
        public int Location { get; set; }
        public string FactilityType { get; set; }
        public string UnitNumber { get; set; }
        public string UnitType { get; set; }
        public string Building { get; set; }
        public string Status { get; set; }
        public DateTime AvailabilityStart { get; set; }
        public DateTime AvailabilityEnd { get; set; }
        public DateTime ModifiedOnDate { get; set; }

    }
}
