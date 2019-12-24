using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IKFMemorySupportBudget : OccupancyRecordsContainer
    {
        private OccupancyRecord _endingAverageOccupancy;
        private OccupancyRecord _endingAverageOccupancyVarianceFromBudget;
        private OccupancyRecord _endingAveragePersonOccupancy;
        private OccupancyRecord _endingAvgPersonOccupancyVarianceFromBudget;

        public IKFMemorySupportActual MemorySupportActual { get; set; }
        public OccupancyRecord PrivateMCFirstPerson { get; set; }
        public OccupancyRecord PrivateMCSecondPerson { get; set; }
        public OccupancyRecord EndingAverageOccupancy 
        {
            get
            {
                if (_endingAverageOccupancy == null)
                {
                    if (PrivateMCFirstPerson != null && PrivateMCSecondPerson != null)
                    {
                        _endingAverageOccupancy = new OccupancyRecord
                        {
                            January = PrivateMCFirstPerson.January.HasValue ? ZeroIfNull(PrivateMCFirstPerson.January) + ZeroIfNull(PrivateMCSecondPerson.January) : (float?)null,
                            February = PrivateMCFirstPerson.February.HasValue ? ZeroIfNull(PrivateMCFirstPerson.February) + ZeroIfNull(PrivateMCSecondPerson.February) : (float?)null,
                            March = PrivateMCFirstPerson.March.HasValue ? ZeroIfNull(PrivateMCFirstPerson.March) + ZeroIfNull(PrivateMCSecondPerson.March) : (float?)null,
                            April = PrivateMCFirstPerson.April.HasValue ? ZeroIfNull(PrivateMCFirstPerson.April) + ZeroIfNull(PrivateMCSecondPerson.April) : (float?)null,
                            May = PrivateMCFirstPerson.May.HasValue ? ZeroIfNull(PrivateMCFirstPerson.May) + ZeroIfNull(PrivateMCSecondPerson.May) : (float?)null,
                            June = PrivateMCFirstPerson.June.HasValue ? ZeroIfNull(PrivateMCFirstPerson.June) + ZeroIfNull(PrivateMCSecondPerson.June) : (float?)null,
                            July = PrivateMCFirstPerson.July.HasValue ? ZeroIfNull(PrivateMCFirstPerson.July) + ZeroIfNull(PrivateMCSecondPerson.July) : (float?)null,
                            August = PrivateMCFirstPerson.August.HasValue ? ZeroIfNull(PrivateMCFirstPerson.August) + ZeroIfNull(PrivateMCSecondPerson.August) : (float?)null,
                            September = PrivateMCFirstPerson.September.HasValue ? ZeroIfNull(PrivateMCFirstPerson.September) + ZeroIfNull(PrivateMCSecondPerson.September) : (float?)null,
                            October = PrivateMCFirstPerson.October.HasValue ? ZeroIfNull(PrivateMCFirstPerson.October) + ZeroIfNull(PrivateMCSecondPerson.October) : (float?)null,
                            November = PrivateMCFirstPerson.November.HasValue ? ZeroIfNull(PrivateMCFirstPerson.November) + ZeroIfNull(PrivateMCSecondPerson.November) : (float?)null,
                            December = PrivateMCFirstPerson.December.HasValue ? ZeroIfNull(PrivateMCFirstPerson.December) + ZeroIfNull(PrivateMCSecondPerson.December) : (float?)null
                        };
                        _endingAverageOccupancy.TotalOrAverage = _endingAverageOccupancy.CalculateAverageValue();
                    }
                    else
                    {
                        _endingAverageOccupancy = new OccupancyRecord();
                    }
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
                        January = ZeroIfNull(PrivateMCFirstPerson.January) + ZeroIfNull(PrivateMCSecondPerson.January),
                        February = ZeroIfNull(PrivateMCFirstPerson.February) + ZeroIfNull(PrivateMCSecondPerson.February),
                        March = ZeroIfNull(PrivateMCFirstPerson.March) + ZeroIfNull(PrivateMCSecondPerson.March),
                        April = ZeroIfNull(PrivateMCFirstPerson.April) + ZeroIfNull(PrivateMCSecondPerson.April),
                        May = ZeroIfNull(PrivateMCFirstPerson.May) + ZeroIfNull(PrivateMCSecondPerson.May),
                        June = ZeroIfNull(PrivateMCFirstPerson.June) + ZeroIfNull(PrivateMCSecondPerson.June),
                        July = ZeroIfNull(PrivateMCFirstPerson.July) + ZeroIfNull(PrivateMCSecondPerson.July),
                        August = ZeroIfNull(PrivateMCFirstPerson.August) + ZeroIfNull(PrivateMCSecondPerson.August),
                        September = ZeroIfNull(PrivateMCFirstPerson.September) + ZeroIfNull(PrivateMCSecondPerson.September),
                        October = ZeroIfNull(PrivateMCFirstPerson.October) + ZeroIfNull(PrivateMCSecondPerson.October),
                        November = ZeroIfNull(PrivateMCFirstPerson.November) + ZeroIfNull(PrivateMCSecondPerson.November),
                        December = ZeroIfNull(PrivateMCFirstPerson.December) + ZeroIfNull(PrivateMCSecondPerson.December)
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
                }
                return _endingAvgPersonOccupancyVarianceFromBudget;
            }
        }

    }
}
