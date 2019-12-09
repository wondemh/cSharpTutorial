using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Model
{
    public class FacilityType
    {
        public int LocationId { get; set; }
        public string FacilType { get; set; }
        public string FacilityTypeCode { get; set; }
        public string Title { get; set; }
        public string DisplayOrder { get; set; }
        public string ChartColor { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"LocationId: {LocationId}\nFacilityType: {FacilType}\nFacilityTypeCode: {FacilityTypeCode}\nTitle: {Title}";
        }
    }

}
