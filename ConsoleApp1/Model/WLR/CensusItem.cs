using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Model
{
    public class CensusItem
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

        public string GetPayorTypeCodeAndDescription()
        {
            return this.PayorType + " - " + this.PayorTypeDescription;
        }
    }
}
