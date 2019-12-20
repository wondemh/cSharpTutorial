using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model
{
    public class OccupancyRecord
    {
        public float? January { get; set; }
        public float? February { get; set; }
        public float? March { get; set; }
        public float? April { get; set; }
        public float? May { get; set; }
        public float? June { get; set; }
        public float? July { get; set; }
        public float? August { get; set; }
        public float? September { get; set; }
        public float? October { get; set; }
        public float? November { get; set; }
        public float? December { get; set; }
        public float? TotalOrAverage { get; set; }

        public OccupancyRecord()
        {
            //default constructor
        }

        public OccupancyRecord(bool setAllToZero)
        {
            if (setAllToZero)
            {
                January = 0;
                February = 0;
                March = 0;
                April = 0;
                May = 0;
                June = 0;
                July = 0;
                August = 0;
                September = 0;
                October = 0;
                November = 0;
                December = 0;
            }
        }

        public float CalculateAverageValue()
        {
            float average = (ZeroIfNull(January) 
                + ZeroIfNull(February) 
                + ZeroIfNull(March) 
                + ZeroIfNull(April)
                + ZeroIfNull(May) 
                + ZeroIfNull(June) 
                + ZeroIfNull(July) 
                + ZeroIfNull(August) 
                + ZeroIfNull(September) 
                + ZeroIfNull(October) 
                + ZeroIfNull(November) 
                + ZeroIfNull(December)) / 12;
            float roundedAverage = (float)Math.Round(average, 1);
            return roundedAverage;
        }

        public float CalculateTotalValue()
        {
            return ZeroIfNull(January)
                + ZeroIfNull(February)
                + ZeroIfNull(March)
                + ZeroIfNull(April)
                + ZeroIfNull(May)
                + ZeroIfNull(June)
                + ZeroIfNull(July)
                + ZeroIfNull(August)
                + ZeroIfNull(September)
                + ZeroIfNull(October)
                + ZeroIfNull(November)
                + ZeroIfNull(December);
        }

        public static float ZeroIfNull(float? value)
        {
            return value ?? 0;
        }

        public static float Divide(float? num, float? denom)
        {
            if(num.HasValue && denom.HasValue)
            {
                return denom.Value > 0 ? num.Value / denom.Value : 0;
            }
            return 0;
        }
    }
}
