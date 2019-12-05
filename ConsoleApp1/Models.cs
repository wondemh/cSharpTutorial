using System;
using System.Collections.Generic;

namespace Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"Id: {Id}\nName: {Name}\nCode: {Code}\n";
        }
    }

    public class AdmissionStatusRecord
    {
        public int Location { get; set; }
        public string FacilityType { get; set; }
        public string AdmissionStatus { get; set; }
        public string AdmitCode { get; set; }
        public string Description { get; set; }
        public DateTime ModifiedOnDate { get; set; }
    }

    public class WLRCensusRecord
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MidInit { get; set; }
        public int ResidentID { get; set; }
        public int AdmissionNumber { get; set; }
        public string PayorType { get; set; }
        public string PayorTypeDescription { get; set; }
        public string AdmissionStatus { get; set; }
        public string AdmissionStatusDescription { get; set; }
        public string DischargeTo { get; set; }
        public string UnitNumber { get; set; }
        public string UnitType { get; set; }
        public string Building { get; set; }
        public string LevelOfCare { get; set; }
        public DateTime CensusDate { get; set; }
        public string Status { get; set; }

        public string getPayorTypeCodeAndDescription()
        {
            return this.PayorType + " - " + this.PayorTypeDescription;
        }
    }

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