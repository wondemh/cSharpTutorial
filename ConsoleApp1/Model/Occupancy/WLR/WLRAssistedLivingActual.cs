using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class WLRAssistedLivingActual : OccupancyRecordsContainer
    {
        private OccupancyRecord _averageOccupancy;
        private OccupancyRecord _percentUnitOccupancy;
        private OccupancyRecord _unoccupiedUnits;

        public OccupancyRecord UnitsAvailable { get; set; }
        public OccupancyRecord AverageFFS { get; set; }
        public OccupancyRecord AverageLC { get; set; }
        public OccupancyRecord AverageOccupancy
        {
            get
            {
                if (_averageOccupancy == null)
                {
                    if (AverageFFS != null && AverageLC != null)
                    {
                        _averageOccupancy = new OccupancyRecord
                        {
                            January = ZeroIfNull(AverageFFS.January) + ZeroIfNull(AverageLC.January),
                            February = ZeroIfNull(AverageFFS.February) + ZeroIfNull(AverageLC.February),
                            March = ZeroIfNull(AverageFFS.March) + ZeroIfNull(AverageLC.March),
                            April = ZeroIfNull(AverageFFS.April) + ZeroIfNull(AverageLC.April),
                            May = ZeroIfNull(AverageFFS.May) + ZeroIfNull(AverageLC.May),
                            June = ZeroIfNull(AverageFFS.June) + ZeroIfNull(AverageLC.June),
                            July = ZeroIfNull(AverageFFS.July) + ZeroIfNull(AverageLC.July),
                            August = ZeroIfNull(AverageFFS.August) + ZeroIfNull(AverageLC.August),
                            September = ZeroIfNull(AverageFFS.September) + ZeroIfNull(AverageLC.September),
                            October = ZeroIfNull(AverageFFS.October) + ZeroIfNull(AverageLC.October),
                            November = ZeroIfNull(AverageFFS.November) + ZeroIfNull(AverageLC.November),
                            December = ZeroIfNull(AverageFFS.December) + ZeroIfNull(AverageLC.December)
                        };
                        _averageOccupancy.TotalOrAverage = _averageOccupancy.CalculateAverageValue();
                        
                    }
                    else
                    {
                        _averageOccupancy = new OccupancyRecord();
                    }
                }
                return _averageOccupancy;
            }
        }

        public OccupancyRecord PercentUnitOccupancy
        {
            get
            {
                if (_percentUnitOccupancy == null)
                {
                    _percentUnitOccupancy = new OccupancyRecord
                    {
                        January = AverageOccupancy.January.HasValue ? Divide(AverageOccupancy.January, UnitsAvailable.January) : (float?)null,
                        February = AverageOccupancy.February.HasValue ? Divide(AverageOccupancy.February, UnitsAvailable.February) : (float?)null,
                        March = AverageOccupancy.March.HasValue ? Divide(AverageOccupancy.March, UnitsAvailable.March) : (float?)null,
                        April = AverageOccupancy.April.HasValue ? Divide(AverageOccupancy.April, UnitsAvailable.April) : (float?)null,
                        May = AverageOccupancy.May.HasValue ? Divide(AverageOccupancy.May, UnitsAvailable.May) : (float?)null,
                        June = AverageOccupancy.June.HasValue ? Divide(AverageOccupancy.June, UnitsAvailable.June) : (float?)null,
                        July = AverageOccupancy.July.HasValue ? Divide(AverageOccupancy.July, UnitsAvailable.July) : (float?)null,
                        August = AverageOccupancy.August.HasValue ? Divide(AverageOccupancy.August, UnitsAvailable.August) : (float?)null,
                        September = AverageOccupancy.September.HasValue ? Divide(AverageOccupancy.September, UnitsAvailable.September) : (float?)null,
                        October = AverageOccupancy.October.HasValue ? Divide(AverageOccupancy.October, UnitsAvailable.October) : (float?)null,
                        November = AverageOccupancy.November.HasValue ? Divide(AverageOccupancy.November, UnitsAvailable.November) : (float?)null,
                        December = AverageOccupancy.December.HasValue ? Divide(AverageOccupancy.December, UnitsAvailable.December) : (float?)null,
                        TotalOrAverage = Divide(AverageOccupancy.TotalOrAverage, UnitsAvailable.TotalOrAverage)
                    };
                }
                return _percentUnitOccupancy;
            }
        }

        public OccupancyRecord UnoccupiedUnits
        {
            get
            {
                if (_unoccupiedUnits == null)
                {
                    _unoccupiedUnits = new OccupancyRecord
                    {
                        January = AverageOccupancy.January.HasValue ? Subtract(UnitsAvailable.January, AverageOccupancy.January) : (float?)null,
                        February = AverageOccupancy.February.HasValue ? Subtract(UnitsAvailable.February, AverageOccupancy.February) : (float?)null,
                        March = AverageOccupancy.March.HasValue ? Subtract(UnitsAvailable.March, AverageOccupancy.March) : (float?)null,
                        April = AverageOccupancy.April.HasValue ? Subtract(UnitsAvailable.April, AverageOccupancy.April) : (float?)null,
                        May = AverageOccupancy.May.HasValue ? Subtract(UnitsAvailable.May, AverageOccupancy.May) : (float?)null,
                        June = AverageOccupancy.June.HasValue ? Subtract(UnitsAvailable.June, AverageOccupancy.June) : (float?)null,
                        July = AverageOccupancy.July.HasValue ? Subtract(UnitsAvailable.July, AverageOccupancy.July) : (float?)null,
                        August = AverageOccupancy.August.HasValue ? Subtract(UnitsAvailable.August, AverageOccupancy.August) : (float?)null,
                        September = AverageOccupancy.September.HasValue ? Subtract(UnitsAvailable.September, AverageOccupancy.September) : (float?)null,
                        October = AverageOccupancy.October.HasValue ? Subtract(UnitsAvailable.October, AverageOccupancy.October) : (float?)null,
                        November = AverageOccupancy.November.HasValue ? Subtract(UnitsAvailable.November, AverageOccupancy.November) : (float?)null,
                        December = AverageOccupancy.December.HasValue ? Subtract(UnitsAvailable.December, AverageOccupancy.December) : (float?)null
                    };
                    _unoccupiedUnits.TotalOrAverage = _unoccupiedUnits.CalculateAverageValue();
                }
                return _unoccupiedUnits;
            }
        }
    }
}
