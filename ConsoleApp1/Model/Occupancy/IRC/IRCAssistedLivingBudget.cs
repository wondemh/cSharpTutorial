using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IRCAssistedLivingBudget : OccupancyRecordsContainer
    {
        private OccupancyRecord _endingAverageOccupancy;
        private OccupancyRecord _endingAveragePersonOccupancyVarianceFromBudget;
        private OccupancyRecord _endingAveragePersonOccupancy;
        private OccupancyRecord _endingAverageOccupancyVarianceFromBudget;

        public IRCAssistedLivingActual AssistedLivingActual { get; set; }
        public OccupancyRecord AverageFFSFirst { get; set; }
        public OccupancyRecord AverageFFSSecond { get; set; }
        public OccupancyRecord AverageLCFirst { get; set; }
        public OccupancyRecord AverageLCSecond { get; set; }
        public OccupancyRecord EndingAverageOccupancy
        {
            get
            {
                if (_endingAverageOccupancy == null)
                {
                    _endingAverageOccupancy = new OccupancyRecord
                    {
                        January = ZeroIfNull(AverageFFSFirst.January) + ZeroIfNull(AverageLCFirst.January),
                        February = ZeroIfNull(AverageFFSFirst.February) + ZeroIfNull(AverageFFSSecond.February) + ZeroIfNull(AverageLCFirst.February),
                        March = ZeroIfNull(AverageFFSFirst.March) + ZeroIfNull(AverageFFSSecond.March) + ZeroIfNull(AverageLCFirst.March),
                        April = ZeroIfNull(AverageFFSFirst.April) + ZeroIfNull(AverageFFSSecond.April) + ZeroIfNull(AverageLCFirst.April),
                        May = ZeroIfNull(AverageFFSFirst.May) + ZeroIfNull(AverageFFSSecond.May) + ZeroIfNull(AverageLCFirst.May),
                        June = ZeroIfNull(AverageFFSFirst.June) + ZeroIfNull(AverageFFSSecond.June) + ZeroIfNull(AverageLCFirst.June),
                        July = ZeroIfNull(AverageFFSFirst.July) + ZeroIfNull(AverageFFSSecond.July) + ZeroIfNull(AverageLCFirst.July),
                        August = ZeroIfNull(AverageFFSFirst.August) + ZeroIfNull(AverageFFSSecond.August) + ZeroIfNull(AverageLCFirst.August),
                        September = ZeroIfNull(AverageFFSFirst.September) + ZeroIfNull(AverageFFSSecond.September) + ZeroIfNull(AverageLCFirst.September),
                        October = ZeroIfNull(AverageFFSFirst.October) + ZeroIfNull(AverageFFSSecond.October) + ZeroIfNull(AverageLCFirst.October),
                        November = ZeroIfNull(AverageFFSFirst.November) + ZeroIfNull(AverageFFSSecond.November) + ZeroIfNull(AverageLCFirst.November),
                        December = ZeroIfNull(AverageFFSFirst.December) + ZeroIfNull(AverageFFSSecond.December) + ZeroIfNull(AverageLCFirst.December)
                    };
                    _endingAverageOccupancy.TotalOrAverage = _endingAverageOccupancy.CalculateAverageValue();
                }
                return _endingAverageOccupancy;
            }
        }
        public OccupancyRecord EndingAverageOccupancyVarianceFromBudget
        {
            get
            {
                if (_endingAverageOccupancyVarianceFromBudget == null)
                {
                    _endingAverageOccupancyVarianceFromBudget = new OccupancyRecord
                    {
                        January = AssistedLivingActual.EndingAverageOccupancy.January.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.January) - ZeroIfNull(EndingAverageOccupancy.January) : (float?)null,
                        February = AssistedLivingActual.EndingAverageOccupancy.February.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.February) - ZeroIfNull(EndingAverageOccupancy.February) : (float?)null,
                        March = AssistedLivingActual.EndingAverageOccupancy.March.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.March) - ZeroIfNull(EndingAverageOccupancy.March) : (float?)null,
                        April = AssistedLivingActual.EndingAverageOccupancy.April.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.April) - ZeroIfNull(EndingAverageOccupancy.April) : (float?)null,
                        May = AssistedLivingActual.EndingAverageOccupancy.May.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.May) - ZeroIfNull(EndingAverageOccupancy.May) : (float?)null,
                        June = AssistedLivingActual.EndingAverageOccupancy.June.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.June) - ZeroIfNull(EndingAverageOccupancy.June) : (float?)null,
                        July = AssistedLivingActual.EndingAverageOccupancy.July.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.July) - ZeroIfNull(EndingAverageOccupancy.July) : (float?)null,
                        August = AssistedLivingActual.EndingAverageOccupancy.August.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.August) - ZeroIfNull(EndingAverageOccupancy.August) : (float?)null,
                        September = AssistedLivingActual.EndingAverageOccupancy.September.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.September) - ZeroIfNull(EndingAverageOccupancy.September) : (float?)null,
                        October = AssistedLivingActual.EndingAverageOccupancy.October.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.October) - ZeroIfNull(EndingAverageOccupancy.October) : (float?)null,
                        November = AssistedLivingActual.EndingAverageOccupancy.November.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.November) - ZeroIfNull(EndingAverageOccupancy.November) : (float?)null,
                        December = AssistedLivingActual.EndingAverageOccupancy.December.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.December) - ZeroIfNull(EndingAverageOccupancy.December) : (float?)null
                    };
                }
                return _endingAverageOccupancyVarianceFromBudget;
            }
        }
        public OccupancyRecord EndingAveragePersonOccupancy
        {
            get
            {
                if (_endingAveragePersonOccupancy == null)
                {
                    _endingAveragePersonOccupancy = new OccupancyRecord
                    {
                        January = ZeroIfNull(AverageFFSFirst.January) + ZeroIfNull(AverageFFSSecond.January) + ZeroIfNull(AverageLCFirst.January) + ZeroIfNull(AverageLCSecond.January),
                        February = ZeroIfNull(AverageFFSFirst.February) + ZeroIfNull(AverageFFSSecond.February) + ZeroIfNull(AverageLCFirst.February) + ZeroIfNull(AverageLCSecond.February),
                        March = ZeroIfNull(AverageFFSFirst.March) + ZeroIfNull(AverageFFSSecond.March) + ZeroIfNull(AverageLCFirst.March) + ZeroIfNull(AverageLCSecond.March),
                        April = ZeroIfNull(AverageFFSFirst.April) + ZeroIfNull(AverageFFSSecond.April) + ZeroIfNull(AverageLCFirst.April) + ZeroIfNull(AverageLCSecond.April),
                        May = ZeroIfNull(AverageFFSFirst.May) + ZeroIfNull(AverageFFSSecond.May) + ZeroIfNull(AverageLCFirst.May) + ZeroIfNull(AverageLCSecond.May),
                        June = ZeroIfNull(AverageFFSFirst.June) + ZeroIfNull(AverageFFSSecond.June) + ZeroIfNull(AverageLCFirst.June) + ZeroIfNull(AverageLCSecond.June),
                        July = ZeroIfNull(AverageFFSFirst.July) + ZeroIfNull(AverageFFSSecond.July) + ZeroIfNull(AverageLCFirst.July) + ZeroIfNull(AverageLCSecond.July),
                        August = ZeroIfNull(AverageFFSFirst.August) + ZeroIfNull(AverageFFSSecond.August) + ZeroIfNull(AverageLCFirst.August) + ZeroIfNull(AverageLCSecond.August),
                        September = ZeroIfNull(AverageFFSFirst.September) + ZeroIfNull(AverageFFSSecond.September) + ZeroIfNull(AverageLCFirst.September) + ZeroIfNull(AverageLCSecond.September),
                        October = ZeroIfNull(AverageFFSFirst.October) + ZeroIfNull(AverageFFSSecond.October) + ZeroIfNull(AverageLCFirst.October) + ZeroIfNull(AverageLCSecond.October),
                        November = ZeroIfNull(AverageFFSFirst.November) + ZeroIfNull(AverageFFSSecond.November) + ZeroIfNull(AverageLCFirst.November) + ZeroIfNull(AverageLCSecond.November),
                        December = ZeroIfNull(AverageFFSFirst.December) + ZeroIfNull(AverageFFSSecond.December) + ZeroIfNull(AverageLCFirst.December) + ZeroIfNull(AverageLCSecond.December)
                    };
                    _endingAveragePersonOccupancy.TotalOrAverage = _endingAveragePersonOccupancy.CalculateAverageValue();
                }
                return _endingAveragePersonOccupancy;
            }
        }
        public OccupancyRecord EndingAveragePersonOccupancyVarianceFromBudget 
        {
            get
            {
                if (_endingAveragePersonOccupancyVarianceFromBudget == null)
                {
                    _endingAveragePersonOccupancyVarianceFromBudget = new OccupancyRecord
                    {
                        January = AssistedLivingActual.EndingAveragePersonOccupancy.January.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.January - ZeroIfNull(EndingAveragePersonOccupancy.January) : (float?)null,
                        February = AssistedLivingActual.EndingAveragePersonOccupancy.February.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.February - ZeroIfNull(EndingAveragePersonOccupancy.February) : (float?)null,
                        March = AssistedLivingActual.EndingAveragePersonOccupancy.March.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.March - ZeroIfNull(EndingAveragePersonOccupancy.March) : (float?)null,
                        April = AssistedLivingActual.EndingAveragePersonOccupancy.April.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.April - ZeroIfNull(EndingAveragePersonOccupancy.April) : (float?)null,
                        May = AssistedLivingActual.EndingAveragePersonOccupancy.May.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.May - ZeroIfNull(EndingAveragePersonOccupancy.May) : (float?)null,
                        June = AssistedLivingActual.EndingAveragePersonOccupancy.June.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.June - ZeroIfNull(EndingAveragePersonOccupancy.June) : (float?)null,
                        July = AssistedLivingActual.EndingAveragePersonOccupancy.July.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.July - ZeroIfNull(EndingAveragePersonOccupancy.July) : (float?)null,
                        August = AssistedLivingActual.EndingAveragePersonOccupancy.August.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.August - ZeroIfNull(EndingAveragePersonOccupancy.August) : (float?)null,
                        September = AssistedLivingActual.EndingAveragePersonOccupancy.September.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.September - ZeroIfNull(EndingAveragePersonOccupancy.September) : (float?)null,
                        October = AssistedLivingActual.EndingAveragePersonOccupancy.October.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.October - ZeroIfNull(EndingAveragePersonOccupancy.October) : (float?)null,
                        November = AssistedLivingActual.EndingAveragePersonOccupancy.November.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.November - ZeroIfNull(EndingAveragePersonOccupancy.November) : (float?)null,
                        December = AssistedLivingActual.EndingAveragePersonOccupancy.December.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.December - ZeroIfNull(EndingAveragePersonOccupancy.December) : (float?)null
                    };
                    _endingAveragePersonOccupancyVarianceFromBudget.TotalOrAverage = _endingAveragePersonOccupancyVarianceFromBudget.CalculateAverageValue();
                }
                return _endingAveragePersonOccupancyVarianceFromBudget;
            }
        }

    }
}
