using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IRCMemorySupportActual : OccupancyRecordsContainer
    {
        private OccupancyRecord _endingAverageOccupancy;
        private OccupancyRecord _percentUnitOccupancy;
        private OccupancyRecord _unoccupiedUnits;
        private OccupancyRecord _endingAveragePersonOccupancy;
        private OccupancyRecord _percentLicensedOccupancy;

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
        public OccupancyRecord PercentUnitOccupancy
        {
            get
            {
                if (_percentUnitOccupancy == null)
                {
                    if (EndingAverageOccupancy != null && UnitsAvailable != null)
                    {
                        _percentUnitOccupancy = new OccupancyRecord
                        {
                            January = (float)Math.Round(Divide(EndingAverageOccupancy.January, UnitsAvailable.January), 0),
                            February = (float)Math.Round(Divide(EndingAverageOccupancy.February, UnitsAvailable.February), 0),
                            March = (float)Math.Round(Divide(EndingAverageOccupancy.March, UnitsAvailable.March), 0),
                            April = (float)Math.Round(Divide(EndingAverageOccupancy.April, UnitsAvailable.April), 0),
                            May = (float)Math.Round(Divide(EndingAverageOccupancy.May, UnitsAvailable.May), 0),
                            June = (float)Math.Round(Divide(EndingAverageOccupancy.June, UnitsAvailable.June), 0),
                            July = (float)Math.Round(Divide(EndingAverageOccupancy.July, UnitsAvailable.July), 0),
                            August = (float)Math.Round(Divide(EndingAverageOccupancy.August, UnitsAvailable.August), 0),
                            September = (float)Math.Round(Divide(EndingAverageOccupancy.September, UnitsAvailable.September), 0),
                            October = (float)Math.Round(Divide(EndingAverageOccupancy.October, UnitsAvailable.October), 0),
                            November = (float)Math.Round(Divide(EndingAverageOccupancy.November, UnitsAvailable.November), 0),
                            December = (float)Math.Round(Divide(EndingAverageOccupancy.December, UnitsAvailable.December), 0),
                            TotalOrAverage = (float)Math.Round(Divide(EndingAverageOccupancy.TotalOrAverage, UnitsAvailable.TotalOrAverage), 0)
                        };
                    }
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
                    if (EndingAverageOccupancy != null && UnitsAvailable != null)
                    {
                        _unoccupiedUnits = new OccupancyRecord
                        {
                            January = ZeroIfNull(UnitsAvailable.January) - ZeroIfNull(EndingAverageOccupancy.January),
                            February = ZeroIfNull(UnitsAvailable.February) - ZeroIfNull(EndingAverageOccupancy.February),
                            March = ZeroIfNull(UnitsAvailable.March) - ZeroIfNull(EndingAverageOccupancy.March),
                            April = ZeroIfNull(UnitsAvailable.April) - ZeroIfNull(EndingAverageOccupancy.April),
                            May = ZeroIfNull(UnitsAvailable.May) - ZeroIfNull(EndingAverageOccupancy.May),
                            June = ZeroIfNull(UnitsAvailable.June) - ZeroIfNull(EndingAverageOccupancy.June),
                            July = ZeroIfNull(UnitsAvailable.July) - ZeroIfNull(EndingAverageOccupancy.July),
                            August = ZeroIfNull(UnitsAvailable.August) - ZeroIfNull(EndingAverageOccupancy.August),
                            September = ZeroIfNull(UnitsAvailable.September) - ZeroIfNull(EndingAverageOccupancy.September),
                            October = ZeroIfNull(UnitsAvailable.October) - ZeroIfNull(EndingAverageOccupancy.October),
                            November = ZeroIfNull(UnitsAvailable.November) - ZeroIfNull(EndingAverageOccupancy.November),
                            December = ZeroIfNull(UnitsAvailable.December) - ZeroIfNull(EndingAverageOccupancy.December)
                        };
                        _unoccupiedUnits.TotalOrAverage = _unoccupiedUnits.CalculateAverageValue();
                    }
                    else
                    {
                        _unoccupiedUnits = new OccupancyRecord();
                    }
                }
                return _unoccupiedUnits;
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
                        January = EndingAverageOccupancy.January.HasValue ? ZeroIfNull(AverageMSFFSFirst.January) + ZeroIfNull(AverageMSFFSSecond.January) + ZeroIfNull(AverageMSLCFirst.January) + ZeroIfNull(AverageMSLCSecond.January) : (float?)null,
                        February = EndingAverageOccupancy.February.HasValue ? ZeroIfNull(AverageMSFFSFirst.February) + ZeroIfNull(AverageMSFFSSecond.February) + ZeroIfNull(AverageMSLCFirst.February) + ZeroIfNull(AverageMSLCSecond.February) : (float?)null,
                        March = EndingAverageOccupancy.March.HasValue ? ZeroIfNull(AverageMSFFSFirst.March) + ZeroIfNull(AverageMSFFSSecond.March) + ZeroIfNull(AverageMSLCFirst.March) + ZeroIfNull(AverageMSLCSecond.March) : (float?)null,
                        April = EndingAverageOccupancy.April.HasValue ? ZeroIfNull(AverageMSFFSFirst.April) + ZeroIfNull(AverageMSFFSSecond.April) + ZeroIfNull(AverageMSLCFirst.April) + ZeroIfNull(AverageMSLCSecond.April) : (float?)null,
                        May = EndingAverageOccupancy.May.HasValue ? ZeroIfNull(AverageMSFFSFirst.May) + ZeroIfNull(AverageMSFFSSecond.May) + ZeroIfNull(AverageMSLCFirst.May) + ZeroIfNull(AverageMSLCSecond.May) : (float?)null,
                        June = EndingAverageOccupancy.June.HasValue ? ZeroIfNull(AverageMSFFSFirst.June) + ZeroIfNull(AverageMSFFSSecond.June) + ZeroIfNull(AverageMSLCFirst.June) + ZeroIfNull(AverageMSLCSecond.June) : (float?)null,
                        July = EndingAverageOccupancy.July.HasValue ? ZeroIfNull(AverageMSFFSFirst.July) + ZeroIfNull(AverageMSFFSSecond.July) + ZeroIfNull(AverageMSLCFirst.July) + ZeroIfNull(AverageMSLCSecond.July) : (float?)null,
                        August = EndingAverageOccupancy.August.HasValue ? ZeroIfNull(AverageMSFFSFirst.August) + ZeroIfNull(AverageMSFFSSecond.August) + ZeroIfNull(AverageMSLCFirst.August) + ZeroIfNull(AverageMSLCSecond.August) : (float?)null,
                        September = EndingAverageOccupancy.September.HasValue ? ZeroIfNull(AverageMSFFSFirst.September) + ZeroIfNull(AverageMSFFSSecond.September) + ZeroIfNull(AverageMSLCFirst.September) + ZeroIfNull(AverageMSLCSecond.September) : (float?)null,
                        October = EndingAverageOccupancy.October.HasValue ? ZeroIfNull(AverageMSFFSFirst.October) + ZeroIfNull(AverageMSFFSSecond.October) + ZeroIfNull(AverageMSLCFirst.October) + ZeroIfNull(AverageMSLCSecond.October) : (float?)null,
                        November = EndingAverageOccupancy.November.HasValue ? ZeroIfNull(AverageMSFFSFirst.November) + ZeroIfNull(AverageMSFFSSecond.November) + ZeroIfNull(AverageMSLCFirst.November) + ZeroIfNull(AverageMSLCSecond.November) : (float?)null,
                        December = EndingAverageOccupancy.December.HasValue ? ZeroIfNull(AverageMSFFSFirst.December) + ZeroIfNull(AverageMSFFSSecond.December) + ZeroIfNull(AverageMSLCFirst.December) + ZeroIfNull(AverageMSLCSecond.December) : (float?)null
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
                    _percentLicensedOccupancy = new OccupancyRecord
                    {
                        January = (float)Math.Round(Divide(EndingAveragePersonOccupancy.January, LicensedFor.January), 0),
                        February = (float)Math.Round(Divide(EndingAverageOccupancy.February, LicensedFor.February), 0),
                        March = (float)Math.Round(Divide(EndingAverageOccupancy.March, LicensedFor.March), 0),
                        April = (float)Math.Round(Divide(EndingAverageOccupancy.April, LicensedFor.April), 0),
                        May = (float)Math.Round(Divide(EndingAverageOccupancy.May, LicensedFor.May), 0),
                        June = (float)Math.Round(Divide(EndingAverageOccupancy.June, LicensedFor.June), 0),
                        July = (float)Math.Round(Divide(EndingAverageOccupancy.July, LicensedFor.July), 0),
                        August = (float)Math.Round(Divide(EndingAverageOccupancy.August, LicensedFor.August), 0),
                        September = (float)Math.Round(Divide(EndingAverageOccupancy.September, LicensedFor.September), 0),
                        October = (float)Math.Round(Divide(EndingAverageOccupancy.October, LicensedFor.October), 0),
                        November = (float)Math.Round(Divide(EndingAverageOccupancy.November, LicensedFor.November), 0),
                        December = (float)Math.Round(Divide(EndingAverageOccupancy.December, LicensedFor.December), 0),
                        TotalOrAverage = (float)Math.Round(Divide(EndingAveragePersonOccupancy.TotalOrAverage, LicensedFor.TotalOrAverage), 0)
                    };
                }
                return _percentLicensedOccupancy;
            }
        }

    }
}
