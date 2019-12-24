using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class WLRAssistedLivingBudget : OccupancyRecordsContainer
    {
        private OccupancyRecord _endingAverageOccupancy;
        private OccupancyRecord _varianceFromBudget;

        public WLRAssistedLivingActual AssistedLivingActual { get; set; }
        public OccupancyRecord AverageFFSFirst { get; set; }
        public OccupancyRecord AverageLCFirst { get; set; }
        public OccupancyRecord EndingAverageOccupancy 
        {
            get
            {
                if (_endingAverageOccupancy == null)
                {
                    _endingAverageOccupancy = new OccupancyRecord
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
                    _endingAverageOccupancy.TotalOrAverage = _endingAverageOccupancy.CalculateAverageValue();
                }
                return _endingAverageOccupancy;
            }
        }
        public OccupancyRecord VarianceFromBudget 
        {
            get
            {
                if (_varianceFromBudget == null)
                {
                    _varianceFromBudget = new OccupancyRecord
                    {
                        January = AssistedLivingActual.AverageOccupancy.January.HasValue ? Subtract(AssistedLivingActual.AverageOccupancy.January, EndingAverageOccupancy.January) : (float?)null,
                        February = AssistedLivingActual.AverageOccupancy.February.HasValue ? Subtract(AssistedLivingActual.AverageOccupancy.February, EndingAverageOccupancy.February) : (float?)null,
                        March = AssistedLivingActual.AverageOccupancy.March.HasValue ? Subtract(AssistedLivingActual.AverageOccupancy.March, EndingAverageOccupancy.March) : (float?)null,
                        April = AssistedLivingActual.AverageOccupancy.April.HasValue ? Subtract(AssistedLivingActual.AverageOccupancy.April, EndingAverageOccupancy.April) : (float?)null,
                        May = AssistedLivingActual.AverageOccupancy.May.HasValue ? Subtract(AssistedLivingActual.AverageOccupancy.May, EndingAverageOccupancy.May) : (float?)null,
                        June = AssistedLivingActual.AverageOccupancy.June.HasValue ? Subtract(AssistedLivingActual.AverageOccupancy.June, EndingAverageOccupancy.June) : (float?)null,
                        July = AssistedLivingActual.AverageOccupancy.July.HasValue ? Subtract(AssistedLivingActual.AverageOccupancy.July, EndingAverageOccupancy.July) : (float?)null,
                        August = AssistedLivingActual.AverageOccupancy.August.HasValue ? Subtract(AssistedLivingActual.AverageOccupancy.August, EndingAverageOccupancy.August) : (float?)null,
                        September = AssistedLivingActual.AverageOccupancy.September.HasValue ? Subtract(AssistedLivingActual.AverageOccupancy.September, EndingAverageOccupancy.September) : (float?)null,
                        October = AssistedLivingActual.AverageOccupancy.October.HasValue ? Subtract(AssistedLivingActual.AverageOccupancy.October, EndingAverageOccupancy.October) : (float?)null,
                        November = AssistedLivingActual.AverageOccupancy.November.HasValue ? Subtract(AssistedLivingActual.AverageOccupancy.November, EndingAverageOccupancy.November) : (float?)null,
                        December = AssistedLivingActual.AverageOccupancy.December.HasValue ? Subtract(AssistedLivingActual.AverageOccupancy.December, EndingAverageOccupancy.December) : (float?)null
                    };
                }
                return _varianceFromBudget;
            }
        }
        public OccupancyRecord PercentOccupancy { get; set; }
    }
}
