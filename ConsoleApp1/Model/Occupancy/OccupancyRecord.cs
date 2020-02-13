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

        public float CalculateAverageValueExcludeNulls()
        {
            float sum = 0;
            int count = 0;
            if(January != null)
            {
                sum += (float)January;
                count++;
            }
            if (February != null)
            {
                sum += (float)February;
                count++;
            }
            if (March != null)
            {
                sum += (float)March;
                count++;
            }
            if (April != null)
            {
                sum += (float)April;
                count++;
            }
            if (May != null)
            {
                sum += (float)May;
                count++;
            }
            if (June != null)
            {
                sum += (float)June;
                count++;
            }
            if (July != null)
            {
                sum += (float)July;
                count++;
            }
            if (August != null)
            {
                sum += (float)August;
                count++;
            }
            if (September != null)
            {
                sum += (float)September;
                count++;
            }
            if (October != null)
            {
                sum += (float)October;
                count++;
            }
            if (November != null)
            {
                sum += (float)November;
                count++;
            }
            if (December != null)
            {
                sum += (float)December;
                count++;
            }
            if(count > 0)
            {
                float average = sum / count;
                float roundedAverage = (float)Math.Round(average, 1);
                return roundedAverage;
            }
            return 0;
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

        public void AddToMonthlyValues(OccupancyRecord record)
        {
            if(record != null)
            {
                January = ZeroIfNull(January) + ZeroIfNull(record.January);
                February = ZeroIfNull(February) + ZeroIfNull(record.February);
                March = ZeroIfNull(March) + ZeroIfNull(record.March);
                April = ZeroIfNull(April) + ZeroIfNull(record.April);
                May = ZeroIfNull(May) + ZeroIfNull(record.May);
                June = ZeroIfNull(June) + ZeroIfNull(record.June);
                July = ZeroIfNull(July) + ZeroIfNull(record.July);
                August = ZeroIfNull(August) + ZeroIfNull(record.August);
                September = ZeroIfNull(September) + ZeroIfNull(record.September);
                October = ZeroIfNull(October) + ZeroIfNull(record.October);
                November = ZeroIfNull(November) + ZeroIfNull(record.November);
                December = ZeroIfNull(December) + ZeroIfNull(record.December);
            }
            
        }

        public static float ZeroIfNull(float? value)
        {
            return value ?? 0;
        }

        public override string ToString()
        {
            return $"January: {January}, February: {February}, March: {March}, April: {April}, May: {May}, June: {June}, July: {July}, August: {August}" +
                $"September: {September}, October: {October}, November: {November}, December: {December}";
        }

    }
}
