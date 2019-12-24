using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IKFMemorySupportActual : OccupancyRecordsContainer
    {
        private OccupancyRecord _endingAverageOccupancy;
        private OccupancyRecord _percentAverageUnitOccupancy;
        private OccupancyRecord _averageUnoccupiedUnits;
        private OccupancyRecord _endingAveragePersonOccupancy;
        private OccupancyRecord _percentLicensedOccupancy;

        public OccupancyRecord UnitsAvailable { get; set; }
        public static OccupancyRecord LicensedFor
        {
            get
            {
                return new OccupancyRecord
                {
                    January = 46,
                    February = 46,
                    March = 46,
                    April = 46,
                    May = 46,
                    June = 46,
                    July = 46,
                    August = 46,
                    September = 46,
                    October = 46,
                    November = 46,
                    December = 46,
                    TotalOrAverage = 46
                };
            }
        }
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
                }
                return _endingAverageOccupancy;
            }
        }
        public OccupancyRecord PercentAverageUnitOccupancy
        {
            get
            {
                if (_percentAverageUnitOccupancy == null)
                {
                    if (EndingAverageOccupancy != null && UnitsAvailable != null)
                    {
                        _percentAverageUnitOccupancy = new OccupancyRecord
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
                return _percentAverageUnitOccupancy;
            }
        }

        public OccupancyRecord AverageUnoccupiedUnits
        {
            get
            {
                if (_averageUnoccupiedUnits == null)
                {
                    if (EndingAverageOccupancy != null && UnitsAvailable != null)
                    {
                        _averageUnoccupiedUnits = new OccupancyRecord
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
                        _averageUnoccupiedUnits.TotalOrAverage = _averageUnoccupiedUnits.CalculateAverageValue();
                    }
                    else
                    {
                        _averageUnoccupiedUnits = new OccupancyRecord();
                    }
                }
                return _averageUnoccupiedUnits;
            }
        }

        public OccupancyRecord EndingAveragePersonOccupancy
        {
            get
            {
                if (_endingAveragePersonOccupancy == null)
                {
                    if (PrivateMCFirstPerson != null && PrivateMCSecondPerson != null)
                    {
                        _endingAveragePersonOccupancy = new OccupancyRecord
                        {
                            January = EndingAverageOccupancy.January.HasValue ? ZeroIfNull(PrivateMCFirstPerson.January) + ZeroIfNull(PrivateMCSecondPerson.January) : (float?)null,
                            February = EndingAverageOccupancy.February.HasValue ? ZeroIfNull(PrivateMCFirstPerson.February) + ZeroIfNull(PrivateMCSecondPerson.February) : (float?)null,
                            March = EndingAverageOccupancy.March.HasValue ? ZeroIfNull(PrivateMCFirstPerson.March) + ZeroIfNull(PrivateMCSecondPerson.March) : (float?)null,
                            April = EndingAverageOccupancy.April.HasValue ? ZeroIfNull(PrivateMCFirstPerson.April) + ZeroIfNull(PrivateMCSecondPerson.April) : (float?)null,
                            May = EndingAverageOccupancy.May.HasValue ? ZeroIfNull(PrivateMCFirstPerson.May) + ZeroIfNull(PrivateMCSecondPerson.May) : (float?)null,
                            June = EndingAverageOccupancy.June.HasValue ? ZeroIfNull(PrivateMCFirstPerson.June) + ZeroIfNull(PrivateMCSecondPerson.June) : (float?)null,
                            July = EndingAverageOccupancy.July.HasValue ? ZeroIfNull(PrivateMCFirstPerson.July) + ZeroIfNull(PrivateMCSecondPerson.July) : (float?)null,
                            August = EndingAverageOccupancy.August.HasValue ? ZeroIfNull(PrivateMCFirstPerson.August) + ZeroIfNull(PrivateMCSecondPerson.August) : (float?)null,
                            September = EndingAverageOccupancy.September.HasValue ? ZeroIfNull(PrivateMCFirstPerson.September) + ZeroIfNull(PrivateMCSecondPerson.September) : (float?)null,
                            October = EndingAverageOccupancy.October.HasValue ? ZeroIfNull(PrivateMCFirstPerson.October) + ZeroIfNull(PrivateMCSecondPerson.October) : (float?)null,
                            November = EndingAverageOccupancy.November.HasValue ? ZeroIfNull(PrivateMCFirstPerson.November) + ZeroIfNull(PrivateMCSecondPerson.November) : (float?)null,
                            December = EndingAverageOccupancy.December.HasValue ? ZeroIfNull(PrivateMCFirstPerson.December) + ZeroIfNull(PrivateMCSecondPerson.December) : (float?)null
                        };
                        _endingAveragePersonOccupancy.TotalOrAverage = _endingAveragePersonOccupancy.CalculateAverageValue();
                    }
                    else
                    {
                        _endingAveragePersonOccupancy = new OccupancyRecord();
                    }
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
                    else
                    {
                        _percentLicensedOccupancy = new OccupancyRecord();
                    }
                }
                return _percentLicensedOccupancy;
            }
        }

    }
}
