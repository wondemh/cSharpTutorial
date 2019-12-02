using System;
using System.Collections.Generic;

namespace Models
{
    public class Employee
    {
        public Guid UID { get; set; }
        public int NumberOfYearsEmployed { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<EmployeeReview> Reviews { get; set; }

        public override string ToString()
        {
            string value = base.ToString() + $"EmployeeId: {UID}\nNumberOfYearsEmployed: {NumberOfYearsEmployed}\nFirstName: {FirstName}\nLastName: {LastName}";
            if (Reviews != null)
            {
                value += "\nReviews: ";
                foreach (var review in Reviews)
                {
                    value += review.ToString() + "\n";
                }
            }
            return value;
        }
    }

    public class EmployeeReview
    {
        public Guid UID { get; set; }
        public Guid EmployeeUID { get; set; }
        public DateTime ReviewDate { get; set; }
        public string ReviewedBy { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"UID: {UID}\nEmployeeUID: {EmployeeUID}\nReviewDate: {ReviewDate}\nReviewedBy: {ReviewedBy}\nNotes: {Notes}";
        }
    }

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

    public class WLRCensusRecord
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MidInit { get; set; }
        public int ResidentID { get; set; }
        public int AdmissionNumber { get; set; }
        public string PayorType { get; set; }
        public string AdmissionStatus { get; set; }
        public string DischargeTo { get; set; }
        public string UnitNumber { get; set; }
        public string UnitType { get; set; }
        public string Building { get; set; }
        public string LevelOfCare { get; set; }

        //       A.LastName,
        //A.FirstName,
        //A.MidInit,
        //B.ResidentID,
        //B.AdmissionNumber,
        //B.PayorType,
        //B.AdmissionStatus,
        //'<<DischargeTo>>',
        //C.UnitNumber,
        //C.UnitType,
        //C.Building AS UnitLocation,
        //A.LevelOfCare
        
    }
}