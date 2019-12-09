using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Model
{
    public class AdmissionStatusRecord
    {
        public int Location { get; set; }
        public string FacilityType { get; set; }
        public string AdmissionStatus { get; set; }
        public string AdmitCode { get; set; }
        public string Description { get; set; }
        public DateTime ModifiedOnDate { get; set; }
    }
}
