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
}