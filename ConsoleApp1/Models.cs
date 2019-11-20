using System;

namespace Models
{
    public class Person
    {
        public Guid Uid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"UID: {Uid}\nFirstName: {FirstName}\nLastName; {LastName}\n";
        }

    }


    public class Employee : Person

    {
        public Guid EmployeeId { get; set; }
        public int NumberOfYearsEmployed { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"EmployeeId: {EmployeeId}\nNumberOfYearsEmployed: {NumberOfYearsEmployed}\n";
        }

    }
}