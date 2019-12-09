using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Model
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
}
