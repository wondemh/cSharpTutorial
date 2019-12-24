using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IRCAssistedLivingActual : OccupancyRecordsContainer
    {
        private OccupancyRecord _percentLicensedOccupancy;
        private OccupancyRecord _endingAveragePersonOccupancy;
        private OccupancyRecord _percentUnitOccupancy;
        private OccupancyRecord _endingAverageOccupancy;

        public OccupancyRecord UnitsAvailable { get; set; }
        public static OccupancyRecord LicensedFor
        {
            get
            {
                return new OccupancyRecord
                {
                    January = 27,
                    February = 27,
                    March = 27,
                    April = 27,
                    May = 27,
                    June = 27,
                    July = 27,
                    August = 27,
                    September = 27,
                    October = 27,
                    November = 27,
                    December = 27,
                    TotalOrAverage = 27
                };
            }
        }
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
                        January = AverageFFSFirst.January.HasValue ? ZeroIfNull(AverageFFSFirst.January) + ZeroIfNull(AverageLCFirst.January) : (float?)null,
                        February = AverageFFSFirst.February.HasValue ? ZeroIfNull(AverageFFSFirst.February) + ZeroIfNull(AverageLCFirst.February) : (float?)null,
                        March = AverageFFSFirst.March.HasValue ? ZeroIfNull(AverageFFSFirst.March) + ZeroIfNull(AverageLCFirst.March) : (float?)null,
                        April = AverageFFSFirst.April.HasValue ? ZeroIfNull(AverageFFSFirst.April) + ZeroIfNull(AverageLCFirst.April) : (float?)null,
                        May = AverageFFSFirst.May.HasValue ? ZeroIfNull(AverageFFSFirst.May) + ZeroIfNull(AverageLCFirst.May) : (float?)null,
                        June = AverageFFSFirst.June.HasValue ? ZeroIfNull(AverageFFSFirst.June) + ZeroIfNull(AverageLCFirst.June) : (float?)null,
                        July = AverageFFSFirst.July.HasValue ? ZeroIfNull(AverageFFSFirst.July) + ZeroIfNull(AverageLCFirst.July) : (float?)null,
                        August = AverageFFSFirst.August.HasValue ? ZeroIfNull(AverageFFSFirst.August) + ZeroIfNull(AverageLCFirst.August) : (float?)null,
                        September = AverageFFSFirst.September.HasValue ? ZeroIfNull(AverageFFSFirst.September) + ZeroIfNull(AverageLCFirst.September) : (float?)null,
                        October = AverageFFSFirst.October.HasValue ? ZeroIfNull(AverageFFSFirst.October) + ZeroIfNull(AverageLCFirst.October) : (float?)null,
                        November = AverageFFSFirst.November.HasValue ? ZeroIfNull(AverageFFSFirst.November) + ZeroIfNull(AverageLCFirst.November) : (float?)null,
                        December = AverageFFSFirst.December.HasValue ? ZeroIfNull(AverageFFSFirst.December) + ZeroIfNull(AverageLCFirst.December) : (float?)null
                    };
                    _endingAverageOccupancy.TotalOrAverage = _endingAverageOccupancy.CalculateAverageValue();
                }
                return _endingAverageOccupancy;
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
                        January = EndingAverageOccupancy.January.HasValue ? Divide(EndingAverageOccupancy.January, UnitsAvailable.January) : (float?)null,
                        February = EndingAverageOccupancy.February.HasValue ? Divide(EndingAverageOccupancy.February, UnitsAvailable.February) : (float?)null,
                        March = EndingAverageOccupancy.March.HasValue ? Divide(EndingAverageOccupancy.March, UnitsAvailable.March) : (float?)null,
                        April = EndingAverageOccupancy.April.HasValue ? Divide(EndingAverageOccupancy.April, UnitsAvailable.April) : (float?)null,
                        May = EndingAverageOccupancy.May.HasValue ? Divide(EndingAverageOccupancy.May, UnitsAvailable.May) : (float?)null,
                        June = EndingAverageOccupancy.June.HasValue ? Divide(EndingAverageOccupancy.June, UnitsAvailable.June) : (float?)null,
                        July = EndingAverageOccupancy.July.HasValue ? Divide(EndingAverageOccupancy.July, UnitsAvailable.July) : (float?)null,
                        August = EndingAverageOccupancy.August.HasValue ? Divide(EndingAverageOccupancy.August, UnitsAvailable.August) : (float?)null,
                        September = EndingAverageOccupancy.September.HasValue ? Divide(EndingAverageOccupancy.September, UnitsAvailable.September) : (float?)null,
                        October = EndingAverageOccupancy.October.HasValue ? Divide(EndingAverageOccupancy.October, UnitsAvailable.October) : (float?)null,
                        November = EndingAverageOccupancy.November.HasValue ? Divide(EndingAverageOccupancy.November, UnitsAvailable.November) : (float?)null,
                        December = EndingAverageOccupancy.December.HasValue ? Divide(EndingAverageOccupancy.December, UnitsAvailable.December) : (float?)null,
                        TotalOrAverage = Divide(EndingAverageOccupancy.TotalOrAverage, UnitsAvailable.TotalOrAverage)
                    };
                }
                return _percentUnitOccupancy;
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
                        January = EndingAverageOccupancy.January.HasValue ? ZeroIfNull(AverageFFSFirst.January) + ZeroIfNull(AverageFFSSecond.January) + ZeroIfNull(AverageLCFirst.January) + ZeroIfNull(AverageLCSecond.January) : (float?)null,
                        February = EndingAverageOccupancy.February.HasValue ? ZeroIfNull(AverageFFSFirst.February) + ZeroIfNull(AverageFFSSecond.February) + ZeroIfNull(AverageLCFirst.February) + ZeroIfNull(AverageLCSecond.February) : (float?)null,
                        March = EndingAverageOccupancy.March.HasValue ? ZeroIfNull(AverageFFSFirst.March) + ZeroIfNull(AverageFFSSecond.March) + ZeroIfNull(AverageLCFirst.March) + ZeroIfNull(AverageLCSecond.March) : (float?)null,
                        April = EndingAverageOccupancy.April.HasValue ? AverageFFSFirst.April + AverageFFSSecond.April + AverageLCFirst.April + AverageLCSecond.April : (float?)null,
                        May = EndingAverageOccupancy.May.HasValue ? ZeroIfNull(AverageFFSFirst.May) + ZeroIfNull(AverageFFSSecond.May) + ZeroIfNull(AverageLCFirst.May) + ZeroIfNull(AverageLCSecond.May) : (float?)null,
                        June = EndingAverageOccupancy.June.HasValue ? ZeroIfNull(AverageFFSFirst.June) + ZeroIfNull(AverageFFSSecond.June) + ZeroIfNull(AverageLCFirst.June) + ZeroIfNull(AverageLCSecond.June) : (float?)null,
                        July = EndingAverageOccupancy.July.HasValue ? ZeroIfNull(AverageFFSFirst.July) + ZeroIfNull(AverageFFSSecond.July) + ZeroIfNull(AverageLCFirst.July) + ZeroIfNull(AverageLCSecond.July) : (float?)null,
                        August = EndingAverageOccupancy.August.HasValue ? ZeroIfNull(AverageFFSFirst.August) + ZeroIfNull(AverageFFSSecond.August) + ZeroIfNull(AverageLCFirst.August) + ZeroIfNull(AverageLCSecond.August) : (float?)null,
                        September = EndingAverageOccupancy.September.HasValue ? ZeroIfNull(AverageFFSFirst.September) + ZeroIfNull(AverageFFSSecond.September) + ZeroIfNull(AverageLCFirst.September) + ZeroIfNull(AverageLCSecond.September) : (float?)null,
                        October = EndingAverageOccupancy.October.HasValue ? ZeroIfNull(AverageFFSFirst.October) + ZeroIfNull(AverageFFSSecond.October) + ZeroIfNull(AverageLCFirst.October) + ZeroIfNull(AverageLCSecond.October) : (float?)null,
                        November = EndingAverageOccupancy.November.HasValue ? ZeroIfNull(AverageFFSFirst.November) + ZeroIfNull(AverageFFSSecond.November) + ZeroIfNull(AverageLCFirst.November) + ZeroIfNull(AverageLCSecond.November) : (float?)null,
                        December = EndingAverageOccupancy.December.HasValue ? ZeroIfNull(AverageFFSFirst.December) + ZeroIfNull(AverageFFSSecond.December) + ZeroIfNull(AverageLCFirst.December) + ZeroIfNull(AverageLCSecond.December) : (float?)null
                    };
                    _endingAveragePersonOccupancy.TotalOrAverage = _endingAveragePersonOccupancy.CalculateAverageValue();
                }
                return _endingAveragePersonOccupancy;
            }
        }
        public OccupancyRecord PercentLicensedOccupancy
        {
            get
            {
                if (_percentLicensedOccupancy == null)
                {
                    if (EndingAveragePersonOccupancy != null && LicensedFor != null)
                    {
                        _percentLicensedOccupancy  = new OccupancyRecord
                        {
                            January = EndingAveragePersonOccupancy.January.HasValue ? (float)Math.Round(Divide(EndingAveragePersonOccupancy.January, LicensedFor.January), 0) : (float?)null,
                            February = EndingAveragePersonOccupancy.February.HasValue ? (float)Math.Round(Divide(EndingAveragePersonOccupancy.February, LicensedFor.February), 0) : (float?)null,
                            March = EndingAveragePersonOccupancy.March.HasValue ? (float)Math.Round(Divide(EndingAveragePersonOccupancy.March, LicensedFor.March), 0) : (float?)null,
                            April = EndingAveragePersonOccupancy.April.HasValue ? (float)Math.Round(Divide(EndingAveragePersonOccupancy.April, LicensedFor.April), 0) : (float?)null,
                            May = EndingAveragePersonOccupancy.May.HasValue ? (float)Math.Round(Divide(EndingAveragePersonOccupancy.May, LicensedFor.May), 0) : (float?)null,
                            June = EndingAveragePersonOccupancy.June.HasValue ? (float)Math.Round(Divide(EndingAveragePersonOccupancy.June, LicensedFor.June), 0) : (float?)null,
                            July = EndingAveragePersonOccupancy.July.HasValue ? (float)Math.Round(Divide(EndingAveragePersonOccupancy.July, LicensedFor.July), 0) : (float?)null,
                            August = EndingAveragePersonOccupancy.August.HasValue ? (float)Math.Round(Divide(EndingAveragePersonOccupancy.August, LicensedFor.August), 0) : (float?)null,
                            September = EndingAveragePersonOccupancy.September.HasValue ? (float)Math.Round(Divide(EndingAveragePersonOccupancy.September, LicensedFor.September), 0) : (float?)null,
                            October = EndingAveragePersonOccupancy.October.HasValue ? (float)Math.Round(Divide(EndingAveragePersonOccupancy.October, LicensedFor.October), 0) : (float?)null,
                            November = EndingAveragePersonOccupancy.November.HasValue ? (float)Math.Round(Divide(EndingAveragePersonOccupancy.November, LicensedFor.November), 0) : (float?)null,
                            December = EndingAveragePersonOccupancy.December.HasValue ? (float)Math.Round(Divide(EndingAveragePersonOccupancy.December, LicensedFor.December), 0) : (float?)null,
                            TotalOrAverage = (float)Math.Round(Divide(EndingAveragePersonOccupancy.TotalOrAverage, LicensedFor.TotalOrAverage), 0)
                        };
                    } else
                    {
                        _percentLicensedOccupancy = new OccupancyRecord(true);
                    }
                }
                return _percentLicensedOccupancy;
            }
        }
    }
}
