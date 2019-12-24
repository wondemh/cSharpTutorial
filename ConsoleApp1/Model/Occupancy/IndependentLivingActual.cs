using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IndependentLivingActual : OccupancyRecordsContainer
    {
        private OccupancyRecord _endingOccupancy;
        private OccupancyRecord _unoccupiedUnits;
        private OccupancyRecord _percentOccupancy;

        public OccupancyRecord UnitsAvailable { get; set; }
        public OccupancyRecord BeginningOccupancy { get; set; }
        public OccupancyRecord MoveIns { get; set; }
        public OccupancyRecord MoveOuts { get; set; }
        public OccupancyRecord Transfers { get; set; }
        public OccupancyRecord EndingOccupancy
        {
            get
            {
                return _endingOccupancy;
            }
        }
        public void SetEndingOccupancy(int reportMonth)
        {
            _endingOccupancy = new OccupancyRecord
            {
                January = (reportMonth >= 1)
                    ? ZeroIfNull(BeginningOccupancy.January) + ZeroIfNull(MoveIns.January) + ZeroIfNull(MoveOuts.January) + ZeroIfNull(Transfers.January)
                    : (float?)null,
                February = (reportMonth >= 2)
                    ? ZeroIfNull(BeginningOccupancy.February) + ZeroIfNull(MoveIns.February) + ZeroIfNull(MoveOuts.February) + ZeroIfNull(Transfers.February)
                    : (float?)null,
                March = (reportMonth >= 3)
                    ? ZeroIfNull(BeginningOccupancy.March) + ZeroIfNull(MoveIns.March) + ZeroIfNull(MoveOuts.March) + ZeroIfNull(Transfers.March)
                    : (float?)null,
                April = (reportMonth >= 4)
                    ? ZeroIfNull(BeginningOccupancy.April) + ZeroIfNull(MoveIns.April) + ZeroIfNull(MoveOuts.April) + ZeroIfNull(Transfers.April)
                    : (float?)null,
                May = (reportMonth >= 5)
                    ? ZeroIfNull(BeginningOccupancy.May) + ZeroIfNull(MoveIns.May) + ZeroIfNull(MoveOuts.May) + ZeroIfNull(Transfers.May)
                    : (float?)null,
                June = (reportMonth >= 6)
                    ? ZeroIfNull(BeginningOccupancy.June) + ZeroIfNull(MoveIns.June) + ZeroIfNull(MoveOuts.June) + ZeroIfNull(Transfers.June)
                    : (float?)null,
                July = (reportMonth >= 7)
                    ? ZeroIfNull(BeginningOccupancy.July) + ZeroIfNull(MoveIns.July) + ZeroIfNull(MoveOuts.July) + ZeroIfNull(Transfers.July)
                    : (float?)null,
                August = (reportMonth >= 8)
                    ? ZeroIfNull(BeginningOccupancy.August) + ZeroIfNull(MoveIns.August) + ZeroIfNull(MoveOuts.August) + ZeroIfNull(Transfers.August)
                    : (float?)null,
                September = (reportMonth >= 9)
                    ? ZeroIfNull(BeginningOccupancy.September) + ZeroIfNull(MoveIns.September) + ZeroIfNull(MoveOuts.September) + ZeroIfNull(Transfers.September)
                    : (float?)null,
                October = (reportMonth >= 10)
                    ? ZeroIfNull(BeginningOccupancy.October) + ZeroIfNull(MoveIns.October) + ZeroIfNull(MoveOuts.October) + ZeroIfNull(Transfers.October)
                    : (float?)null,
                November = (reportMonth >= 11)
                    ? ZeroIfNull(BeginningOccupancy.November) + ZeroIfNull(MoveIns.November) + ZeroIfNull(MoveOuts.November) + ZeroIfNull(Transfers.November)
                    : (float?)null,
                December = (reportMonth >= 12)
                    ? ZeroIfNull(BeginningOccupancy.December) + ZeroIfNull(MoveIns.December) + ZeroIfNull(MoveOuts.December) + ZeroIfNull(Transfers.December)
                    : (float?)null
            };
            _endingOccupancy.TotalOrAverage = _endingOccupancy.CalculateAverageValue();
        }

        public OccupancyRecord PercentOccupancy
        {
            get
            {
                if (_percentOccupancy == null)
                {
                    if (EndingOccupancy != null)
                    {
                        _percentOccupancy = new OccupancyRecord
                        {
                            January = EndingOccupancy.January.HasValue ? (float)Math.Round(Divide(EndingOccupancy.January, UnitsAvailable.January), 0) : (float?)null,
                            February = EndingOccupancy.February.HasValue ? (float)Math.Round(Divide(EndingOccupancy.February, UnitsAvailable.February), 0) : (float?)null,
                            March = EndingOccupancy.March.HasValue ? (float)Math.Round(Divide(EndingOccupancy.March, UnitsAvailable.March), 0) : (float?)null,
                            April = EndingOccupancy.April.HasValue ? (float)Math.Round(Divide(EndingOccupancy.April, UnitsAvailable.April), 0) : (float?)null,
                            May = EndingOccupancy.May.HasValue ? (float)Math.Round(Divide(EndingOccupancy.May, UnitsAvailable.May), 0) : (float?)null,
                            June = EndingOccupancy.June.HasValue ? (float)Math.Round(Divide(EndingOccupancy.June, UnitsAvailable.June), 0) : (float?)null,
                            July = EndingOccupancy.July.HasValue ? (float)Math.Round(Divide(EndingOccupancy.July, UnitsAvailable.July), 0) : (float?)null,
                            August = EndingOccupancy.August.HasValue ? (float)Math.Round(Divide(EndingOccupancy.August, UnitsAvailable.August), 0) : (float?)null,
                            September = EndingOccupancy.September.HasValue ? (float)Math.Round(Divide(EndingOccupancy.September, UnitsAvailable.September), 0) : (float?)null,
                            October = EndingOccupancy.October.HasValue ? (float)Math.Round(Divide(EndingOccupancy.October, UnitsAvailable.October), 0) : (float?)null,
                            November = EndingOccupancy.November.HasValue ? (float)Math.Round(Divide(EndingOccupancy.November, UnitsAvailable.November), 0) : (float?)null,
                            December = EndingOccupancy.December.HasValue ? (float)Math.Round(Divide(EndingOccupancy.December, UnitsAvailable.December), 0) : (float?)null,
                            TotalOrAverage = (float)Math.Round(Divide(EndingOccupancy.TotalOrAverage, UnitsAvailable.TotalOrAverage), 0)
                        };
                    }
                    else
                    {
                        _percentOccupancy = new OccupancyRecord();
                    }
                }
                return _percentOccupancy;
            }
        }

        public OccupancyRecord UnoccupiedUnits
        {
            get
            {
                return _unoccupiedUnits;
            }
        }
        public void SetUnoccupiedUnits(int reportMonth)
        {
            _unoccupiedUnits = new OccupancyRecord
            {
                January = (reportMonth >= 1)
                    ? Subtract(UnitsAvailable.January, EndingOccupancy.January)
                    : (float?)null,
                February = (reportMonth >= 2)
                    ? Subtract(UnitsAvailable.February, EndingOccupancy.February)
                    : (float?)null,
                March = (reportMonth >= 3)
                    ? Subtract(UnitsAvailable.March, EndingOccupancy.March)
                    : (float?)null,
                April = (reportMonth >= 4)
                    ? Subtract(UnitsAvailable.April, EndingOccupancy.April)
                    : (float?)null,
                May = (reportMonth >= 5)
                    ? Subtract(UnitsAvailable.May, EndingOccupancy.May)
                    : (float?)null,
                June = (reportMonth >= 6)
                    ? Subtract(UnitsAvailable.June, EndingOccupancy.June)
                    : (float?)null,
                July = (reportMonth >= 7)
                    ? Subtract(UnitsAvailable.July, EndingOccupancy.July)
                    : (float?)null,
                August = (reportMonth >= 8)
                    ? Subtract(UnitsAvailable.August, EndingOccupancy.August)
                    : (float?)null,
                September = (reportMonth >= 9)
                    ? Subtract(UnitsAvailable.September, EndingOccupancy.September)
                    : (float?)null,
                October = (reportMonth >= 10)
                    ? Subtract(UnitsAvailable.October, EndingOccupancy.October)
                    : (float?)null,
                November = (reportMonth >= 11)
                    ? Subtract(UnitsAvailable.November, EndingOccupancy.November)
                    : (float?)null,
                December = (reportMonth >= 12)
                    ? Subtract(UnitsAvailable.December, EndingOccupancy.December)
                    : (float?)null
            };
            _unoccupiedUnits.TotalOrAverage = _unoccupiedUnits.CalculateAverageValue();
        }
    }
}

