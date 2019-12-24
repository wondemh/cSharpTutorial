using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IKFAssistedLivingActual : OccupancyRecordsContainer
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
        public OccupancyRecord AverageLevelOne { get; set; }
        public OccupancyRecord AverageLevelTwo { get; set; }
        public OccupancyRecord AverageLevelThree { get; set; }
        public OccupancyRecord AverageSecondPerson { get; set; }

        public OccupancyRecord EndingAverageOccupancy
        {
            get
            {
                if (_endingAverageOccupancy == null)
                {
                    _endingAverageOccupancy = new OccupancyRecord
                    {
                        January = AverageLevelOne.January.HasValue ? AverageLevelOne.January + AverageLevelTwo.January + AverageLevelThree.January : (float?)null,
                        February = AverageLevelOne.February.HasValue ? AverageLevelOne.February + AverageLevelTwo.February + AverageLevelThree.February : (float?)null,
                        March = AverageLevelOne.March.HasValue ? AverageLevelOne.March + AverageLevelTwo.March + AverageLevelThree.March : (float?)null,
                        April = AverageLevelOne.April.HasValue ? AverageLevelOne.April + AverageLevelTwo.April + AverageLevelThree.April : (float?)null,
                        May = AverageLevelOne.May.HasValue ? AverageLevelOne.May + AverageLevelTwo.May + AverageLevelThree.May : (float?)null,
                        June = AverageLevelOne.June.HasValue ? AverageLevelOne.June + AverageLevelTwo.June + AverageLevelThree.June : (float?)null,
                        July = AverageLevelOne.July.HasValue ? AverageLevelOne.July + AverageLevelTwo.July + AverageLevelThree.July : (float?)null,
                        August = AverageLevelOne.August.HasValue ? AverageLevelOne.August + AverageLevelTwo.August + AverageLevelThree.August : (float?)null,
                        September = AverageLevelOne.September.HasValue ? AverageLevelOne.September + AverageLevelTwo.September + AverageLevelThree.September : (float?)null,
                        October = AverageLevelOne.October.HasValue ? AverageLevelOne.October + AverageLevelTwo.October + AverageLevelThree.October : (float?)null,
                        November = AverageLevelOne.November.HasValue ? AverageLevelOne.November + AverageLevelTwo.November + AverageLevelThree.November : (float?)null,
                        December = AverageLevelOne.December.HasValue ? AverageLevelOne.December + AverageLevelTwo.December + AverageLevelThree.December : (float?)null
                    };
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
                    _percentAverageUnitOccupancy = new OccupancyRecord
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
                        December = EndingAverageOccupancy.December.HasValue ? Divide(EndingAverageOccupancy.December, UnitsAvailable.December) : (float?)null
                    };
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
                    _averageUnoccupiedUnits = new OccupancyRecord
                    {
                        January = EndingAverageOccupancy.January.HasValue ? Subtract(UnitsAvailable.January, EndingAverageOccupancy.January) : (float?)null,
                        February = EndingAverageOccupancy.February.HasValue ? Subtract(UnitsAvailable.February, EndingAverageOccupancy.February) : (float?)null,
                        March = EndingAverageOccupancy.March.HasValue ? Subtract(UnitsAvailable.March, EndingAverageOccupancy.March) : (float?)null,
                        April = EndingAverageOccupancy.April.HasValue ? Subtract(UnitsAvailable.April, EndingAverageOccupancy.April) : (float?)null,
                        May = EndingAverageOccupancy.May.HasValue ? Subtract(UnitsAvailable.May, EndingAverageOccupancy.May) : (float?)null,
                        June = EndingAverageOccupancy.June.HasValue ? Subtract(UnitsAvailable.June, EndingAverageOccupancy.June) : (float?)null,
                        July = EndingAverageOccupancy.July.HasValue ? Subtract(UnitsAvailable.July, EndingAverageOccupancy.July) : (float?)null,
                        August = EndingAverageOccupancy.August.HasValue ? Subtract(UnitsAvailable.August, EndingAverageOccupancy.August) : (float?)null,
                        September = EndingAverageOccupancy.September.HasValue ? Subtract(UnitsAvailable.September, EndingAverageOccupancy.September) : (float?)null,
                        October = EndingAverageOccupancy.October.HasValue ? Subtract(UnitsAvailable.October, EndingAverageOccupancy.October) : (float?)null,
                        November = EndingAverageOccupancy.November.HasValue ? Subtract(UnitsAvailable.November, EndingAverageOccupancy.November) : (float?)null,
                        December = EndingAverageOccupancy.December.HasValue ? Subtract(UnitsAvailable.December, EndingAverageOccupancy.December) : (float?)null
                    };
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
                    _endingAveragePersonOccupancy = new OccupancyRecord
                    {
                        January = EndingAverageOccupancy.January.HasValue ? ZeroIfNull(AverageLevelOne.January) + ZeroIfNull(AverageLevelTwo.January) + ZeroIfNull(AverageLevelThree.January) + ZeroIfNull(AverageSecondPerson.January) : (float?)null,
                        February = EndingAverageOccupancy.February.HasValue ? ZeroIfNull(AverageLevelOne.February) + ZeroIfNull(AverageLevelTwo.February) + ZeroIfNull(AverageLevelThree.February) + ZeroIfNull(AverageSecondPerson.February) : (float?)null,
                        March = EndingAverageOccupancy.March.HasValue ? ZeroIfNull(AverageLevelOne.March) + ZeroIfNull(AverageLevelTwo.March) + ZeroIfNull(AverageLevelThree.March) + ZeroIfNull(AverageSecondPerson.March) : (float?)null,
                        April = EndingAverageOccupancy.April.HasValue ? AverageLevelOne.April + AverageLevelTwo.April + AverageLevelThree.April + AverageSecondPerson.April : (float?)null,
                        May = EndingAverageOccupancy.May.HasValue ? ZeroIfNull(AverageLevelOne.May) + ZeroIfNull(AverageLevelTwo.May) + ZeroIfNull(AverageLevelThree.May) + ZeroIfNull(AverageSecondPerson.May) : (float?)null,
                        June = EndingAverageOccupancy.June.HasValue ? ZeroIfNull(AverageLevelOne.June) + ZeroIfNull(AverageLevelTwo.June) + ZeroIfNull(AverageLevelThree.June) + ZeroIfNull(AverageSecondPerson.June) : (float?)null,
                        July = EndingAverageOccupancy.July.HasValue ? ZeroIfNull(AverageLevelOne.July) + ZeroIfNull(AverageLevelTwo.July) + ZeroIfNull(AverageLevelThree.July) + ZeroIfNull(AverageSecondPerson.July) : (float?)null,
                        August = EndingAverageOccupancy.August.HasValue ? ZeroIfNull(AverageLevelOne.August) + ZeroIfNull(AverageLevelTwo.August) + ZeroIfNull(AverageLevelThree.August) + ZeroIfNull(AverageSecondPerson.August) : (float?)null,
                        September = EndingAverageOccupancy.September.HasValue ? ZeroIfNull(AverageLevelOne.September) + ZeroIfNull(AverageLevelTwo.September) + ZeroIfNull(AverageLevelThree.September) + ZeroIfNull(AverageSecondPerson.September) : (float?)null,
                        October = EndingAverageOccupancy.October.HasValue ? ZeroIfNull(AverageLevelOne.October) + ZeroIfNull(AverageLevelTwo.October) + ZeroIfNull(AverageLevelThree.October) + ZeroIfNull(AverageSecondPerson.October) : (float?)null,
                        November = EndingAverageOccupancy.November.HasValue ? ZeroIfNull(AverageLevelOne.November) + ZeroIfNull(AverageLevelTwo.November) + ZeroIfNull(AverageLevelThree.November) + ZeroIfNull(AverageSecondPerson.November) : (float?)null,
                        December = EndingAverageOccupancy.December.HasValue ? ZeroIfNull(AverageLevelOne.December) + ZeroIfNull(AverageLevelTwo.December) + ZeroIfNull(AverageLevelThree.December) + ZeroIfNull(AverageSecondPerson.December) : (float?)null
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
                        _percentLicensedOccupancy = new OccupancyRecord
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
                        return _percentLicensedOccupancy;
                    }
                    else
                    {
                        _percentLicensedOccupancy = new OccupancyRecord(true);
                    }
                }
                return _percentLicensedOccupancy;
            }
        }
    }
}
