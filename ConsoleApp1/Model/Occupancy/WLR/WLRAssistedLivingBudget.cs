using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class WLRAssistedLivingBudget : OccupancyRecordsContainer
    {
        public WLRAssistedLivingActual AssistedLivingActual { get; set; }
        public OccupancyRecord AverageFFSFirst { get; set; }
        public OccupancyRecord AverageLCFirst { get; set; }
        public OccupancyRecord EndingAverageOccupancy 
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = ZeroIfNull(AverageFFSFirst.January) + ZeroIfNull(AverageLCFirst.January),
                    February = ZeroIfNull(AverageFFSFirst.February) + ZeroIfNull(AverageLCFirst.February),
                    March = ZeroIfNull(AverageFFSFirst.March) + ZeroIfNull(AverageLCFirst.March),
                    April = ZeroIfNull(AverageFFSFirst.April) + ZeroIfNull(AverageLCFirst.April),
                    May = ZeroIfNull(AverageFFSFirst.May) + ZeroIfNull(AverageLCFirst.May),
                    June = ZeroIfNull(AverageFFSFirst.June) + ZeroIfNull(AverageLCFirst.June),
                    July = ZeroIfNull(AverageFFSFirst.July) + ZeroIfNull(AverageLCFirst.July),
                    August = ZeroIfNull(AverageFFSFirst.August) + ZeroIfNull(AverageLCFirst.August),
                    September = ZeroIfNull(AverageFFSFirst.September) + ZeroIfNull(AverageLCFirst.September),
                    October = ZeroIfNull(AverageFFSFirst.October) + ZeroIfNull(AverageLCFirst.October),
                    November = ZeroIfNull(AverageFFSFirst.November) + ZeroIfNull(AverageLCFirst.November),
                    December = ZeroIfNull(AverageFFSFirst.December) + ZeroIfNull(AverageLCFirst.December)
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }
        public OccupancyRecord VarianceFromBudget 
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = AssistedLivingActual.AverageOccupancy.January ?? Subtract(AssistedLivingActual.AverageOccupancy.January, EndingAverageOccupancy.January),
                    February = AssistedLivingActual.AverageOccupancy.February ?? Subtract(AssistedLivingActual.AverageOccupancy.February, EndingAverageOccupancy.February),
                    March = AssistedLivingActual.AverageOccupancy.March ?? Subtract(AssistedLivingActual.AverageOccupancy.March, EndingAverageOccupancy.March),
                    April = AssistedLivingActual.AverageOccupancy.April ?? Subtract(AssistedLivingActual.AverageOccupancy.April, EndingAverageOccupancy.April),
                    May = AssistedLivingActual.AverageOccupancy.May ?? Subtract(AssistedLivingActual.AverageOccupancy.May, EndingAverageOccupancy.May),
                    June = AssistedLivingActual.AverageOccupancy.June ?? Subtract(AssistedLivingActual.AverageOccupancy.June, EndingAverageOccupancy.June),
                    July = AssistedLivingActual.AverageOccupancy.July ?? Subtract(AssistedLivingActual.AverageOccupancy.July, EndingAverageOccupancy.July),
                    August = AssistedLivingActual.AverageOccupancy.August ?? Subtract(AssistedLivingActual.AverageOccupancy.August, EndingAverageOccupancy.August),
                    September = AssistedLivingActual.AverageOccupancy.September ?? Subtract(AssistedLivingActual.AverageOccupancy.September, EndingAverageOccupancy.September),
                    October = AssistedLivingActual.AverageOccupancy.October ?? Subtract(AssistedLivingActual.AverageOccupancy.October, EndingAverageOccupancy.October),
                    November = AssistedLivingActual.AverageOccupancy.November ?? Subtract(AssistedLivingActual.AverageOccupancy.November, EndingAverageOccupancy.November),
                    December = AssistedLivingActual.AverageOccupancy.December ?? Subtract(AssistedLivingActual.AverageOccupancy.December, EndingAverageOccupancy.December)
                };
                return record;
            }
        }
        public OccupancyRecord PercentOccupancy { get; set; }
    }
}
