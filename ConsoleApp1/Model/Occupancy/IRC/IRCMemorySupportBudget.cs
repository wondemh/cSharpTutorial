using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IRCMemorySupportBudget : OccupancyRecordsContainer
    {
        private OccupancyRecord _endingAverageOccupancy;
        private OccupancyRecord _endingAverageOccupancyVarianceFromBudget;
        private OccupancyRecord _endingAveragePersonOccupancy;
        private OccupancyRecord _endingAvgPersonOccupancyVarianceFromBudget;

        public IRCMemorySupportActual MemorySupportActual { get; set; }
        public OccupancyRecord AverageMSFFSFirst { get; set; }
        public OccupancyRecord AverageMSFFSSecond { get; set; }
        public OccupancyRecord AverageMSLCFirst { get; set; }
        public OccupancyRecord AverageMSLCSecond { get; set; }
        public OccupancyRecord EndingAverageOccupancy
        {
            get
            {
                if (_endingAverageOccupancy == null)
                {
                    _endingAverageOccupancy = new OccupancyRecord
                    {
                        January = ZeroIfNull(AverageMSFFSFirst.January) + ZeroIfNull(AverageMSFFSSecond.January) + ZeroIfNull(AverageMSLCFirst.January) + ZeroIfNull(AverageMSLCSecond.January),
                        February = ZeroIfNull(AverageMSFFSFirst.February) + ZeroIfNull(AverageMSFFSSecond.February) + ZeroIfNull(AverageMSLCFirst.February) + ZeroIfNull(AverageMSLCSecond.February),
                        March = ZeroIfNull(AverageMSFFSFirst.March) + ZeroIfNull(AverageMSFFSSecond.March) + ZeroIfNull(AverageMSLCFirst.March) + ZeroIfNull(AverageMSLCSecond.March),
                        April = ZeroIfNull(AverageMSFFSFirst.April) + ZeroIfNull(AverageMSFFSSecond.April) + ZeroIfNull(AverageMSLCFirst.April) + ZeroIfNull(AverageMSLCSecond.April),
                        May = ZeroIfNull(AverageMSFFSFirst.May) + ZeroIfNull(AverageMSFFSSecond.May) + ZeroIfNull(AverageMSLCFirst.May) + ZeroIfNull(AverageMSLCSecond.May),
                        June = ZeroIfNull(AverageMSFFSFirst.June) + ZeroIfNull(AverageMSFFSSecond.June) + ZeroIfNull(AverageMSLCFirst.June) + ZeroIfNull(AverageMSLCSecond.June),
                        July = ZeroIfNull(AverageMSFFSFirst.July) + ZeroIfNull(AverageMSFFSSecond.July) + ZeroIfNull(AverageMSLCFirst.July) + ZeroIfNull(AverageMSLCSecond.July),
                        August = ZeroIfNull(AverageMSFFSFirst.August) + ZeroIfNull(AverageMSFFSSecond.August) + ZeroIfNull(AverageMSLCFirst.August) + ZeroIfNull(AverageMSLCSecond.August),
                        September = ZeroIfNull(AverageMSFFSFirst.September) + ZeroIfNull(AverageMSFFSSecond.September) + ZeroIfNull(AverageMSLCFirst.September) + ZeroIfNull(AverageMSLCSecond.September),
                        October = ZeroIfNull(AverageMSFFSFirst.October) + ZeroIfNull(AverageMSFFSSecond.October) + ZeroIfNull(AverageMSLCFirst.October) + ZeroIfNull(AverageMSLCSecond.October),
                        November = ZeroIfNull(AverageMSFFSFirst.November) + ZeroIfNull(AverageMSFFSSecond.November) + ZeroIfNull(AverageMSLCFirst.November) + ZeroIfNull(AverageMSLCSecond.November),
                        December = ZeroIfNull(AverageMSFFSFirst.December) + ZeroIfNull(AverageMSFFSSecond.December) + ZeroIfNull(AverageMSLCFirst.December) + ZeroIfNull(AverageMSLCSecond.December)
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
                        January = MemorySupportActual.EndingAverageOccupancy.January.HasValue ? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.January) - ZeroIfNull(EndingAverageOccupancy.January) : (float?)null,
                        February = MemorySupportActual.EndingAverageOccupancy.February.HasValue ? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.February) - ZeroIfNull(EndingAverageOccupancy.February) : (float?)null,
                        March = MemorySupportActual.EndingAverageOccupancy.March.HasValue ? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.March) - ZeroIfNull(EndingAverageOccupancy.March) : (float?)null,
                        April = MemorySupportActual.EndingAverageOccupancy.April.HasValue ? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.April) - ZeroIfNull(EndingAverageOccupancy.April) : (float?)null,
                        May = MemorySupportActual.EndingAverageOccupancy.May.HasValue ? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.May) - ZeroIfNull(EndingAverageOccupancy.May) : (float?)null,
                        June = MemorySupportActual.EndingAverageOccupancy.June.HasValue ? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.June) - ZeroIfNull(EndingAverageOccupancy.June) : (float?)null,
                        July = MemorySupportActual.EndingAverageOccupancy.July.HasValue ? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.July) - ZeroIfNull(EndingAverageOccupancy.July) : (float?)null,
                        August = MemorySupportActual.EndingAverageOccupancy.August.HasValue ? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.August) - ZeroIfNull(EndingAverageOccupancy.August) : (float?)null,
                        September = MemorySupportActual.EndingAverageOccupancy.September.HasValue ? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.September) - ZeroIfNull(EndingAverageOccupancy.September) : (float?)null,
                        October = MemorySupportActual.EndingAverageOccupancy.October.HasValue ? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.October) - ZeroIfNull(EndingAverageOccupancy.October) : (float?)null,
                        November = MemorySupportActual.EndingAverageOccupancy.November.HasValue ? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.November) - ZeroIfNull(EndingAverageOccupancy.November) : (float?)null,
                        December = MemorySupportActual.EndingAverageOccupancy.December.HasValue ? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.December) - ZeroIfNull(EndingAverageOccupancy.December) : (float?)null
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
                        January = ZeroIfNull(AverageMSFFSFirst.January) + ZeroIfNull(AverageMSFFSSecond.January) + ZeroIfNull(AverageMSLCFirst.January) + ZeroIfNull(AverageMSLCSecond.January),
                        February = ZeroIfNull(AverageMSFFSFirst.February) + ZeroIfNull(AverageMSFFSSecond.February) + ZeroIfNull(AverageMSLCFirst.February) + ZeroIfNull(AverageMSLCSecond.February),
                        March = ZeroIfNull(AverageMSFFSFirst.March) + ZeroIfNull(AverageMSFFSSecond.March) + ZeroIfNull(AverageMSLCFirst.March) + ZeroIfNull(AverageMSLCSecond.March),
                        April = ZeroIfNull(AverageMSFFSFirst.April) + ZeroIfNull(AverageMSFFSSecond.April) + ZeroIfNull(AverageMSLCFirst.April) + ZeroIfNull(AverageMSLCSecond.April),
                        May = ZeroIfNull(AverageMSFFSFirst.May) + ZeroIfNull(AverageMSFFSSecond.May) + ZeroIfNull(AverageMSLCFirst.May) + ZeroIfNull(AverageMSLCSecond.May),
                        June = ZeroIfNull(AverageMSFFSFirst.June) + ZeroIfNull(AverageMSFFSSecond.June) + ZeroIfNull(AverageMSLCFirst.June) + ZeroIfNull(AverageMSLCSecond.June),
                        July = ZeroIfNull(AverageMSFFSFirst.July) + ZeroIfNull(AverageMSFFSSecond.July) + ZeroIfNull(AverageMSLCFirst.July) + ZeroIfNull(AverageMSLCSecond.July),
                        August = ZeroIfNull(AverageMSFFSFirst.August) + ZeroIfNull(AverageMSFFSSecond.August) + ZeroIfNull(AverageMSLCFirst.August) + ZeroIfNull(AverageMSLCSecond.August),
                        September = ZeroIfNull(AverageMSFFSFirst.September) + ZeroIfNull(AverageMSFFSSecond.September) + ZeroIfNull(AverageMSLCFirst.September) + ZeroIfNull(AverageMSLCSecond.September),
                        October = ZeroIfNull(AverageMSFFSFirst.October) + ZeroIfNull(AverageMSFFSSecond.October) + ZeroIfNull(AverageMSLCFirst.October) + ZeroIfNull(AverageMSLCSecond.October),
                        November = ZeroIfNull(AverageMSFFSFirst.November) + ZeroIfNull(AverageMSFFSSecond.November) + ZeroIfNull(AverageMSLCFirst.November) + ZeroIfNull(AverageMSLCSecond.November),
                        December = ZeroIfNull(AverageMSFFSFirst.December) + ZeroIfNull(AverageMSFFSSecond.December) + ZeroIfNull(AverageMSLCFirst.December) + ZeroIfNull(AverageMSLCSecond.December)
                    };
                    _endingAveragePersonOccupancy.TotalOrAverage = _endingAveragePersonOccupancy.CalculateAverageValue();
                }
                return _endingAveragePersonOccupancy;
            }
        }
        public OccupancyRecord EndingAvgPersonOccupancyVarianceFromBudget
        {
            get
            {
                if (_endingAvgPersonOccupancyVarianceFromBudget == null)
                {
                    _endingAvgPersonOccupancyVarianceFromBudget = new OccupancyRecord
                    {
                        January = MemorySupportActual.EndingAveragePersonOccupancy.January.HasValue ? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.January) - ZeroIfNull(EndingAveragePersonOccupancy.January) : (float?)null,
                        February = MemorySupportActual.EndingAveragePersonOccupancy.February.HasValue ? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.February) - ZeroIfNull(EndingAveragePersonOccupancy.February) : (float?)null,
                        March = MemorySupportActual.EndingAveragePersonOccupancy.March.HasValue ? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.March) - ZeroIfNull(EndingAveragePersonOccupancy.March) : (float?)null,
                        April = MemorySupportActual.EndingAveragePersonOccupancy.April.HasValue ? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.April) - ZeroIfNull(EndingAveragePersonOccupancy.April) : (float?)null,
                        May = MemorySupportActual.EndingAveragePersonOccupancy.May.HasValue ? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.May) - ZeroIfNull(EndingAveragePersonOccupancy.May) : (float?)null,
                        June = MemorySupportActual.EndingAveragePersonOccupancy.June.HasValue ? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.June) - ZeroIfNull(EndingAveragePersonOccupancy.June) : (float?)null,
                        July = MemorySupportActual.EndingAveragePersonOccupancy.July.HasValue ? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.July) - ZeroIfNull(EndingAveragePersonOccupancy.July) : (float?)null,
                        August = MemorySupportActual.EndingAveragePersonOccupancy.August.HasValue ? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.August) - ZeroIfNull(EndingAveragePersonOccupancy.August) : (float?)null,
                        September = MemorySupportActual.EndingAveragePersonOccupancy.September.HasValue ? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.September) - ZeroIfNull(EndingAveragePersonOccupancy.September) : (float?)null,
                        October = MemorySupportActual.EndingAveragePersonOccupancy.October.HasValue ? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.October) - ZeroIfNull(EndingAveragePersonOccupancy.October) : (float?)null,
                        November = MemorySupportActual.EndingAveragePersonOccupancy.November.HasValue ? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.November) - ZeroIfNull(EndingAveragePersonOccupancy.November) : (float?)null,
                        December = MemorySupportActual.EndingAveragePersonOccupancy.December.HasValue ? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.December) - ZeroIfNull(EndingAveragePersonOccupancy.December) : (float?)null
                    };
                    _endingAvgPersonOccupancyVarianceFromBudget.TotalOrAverage = _endingAvgPersonOccupancyVarianceFromBudget.CalculateAverageValue();
                }
                return _endingAvgPersonOccupancyVarianceFromBudget;
            }
        }

    }
}
