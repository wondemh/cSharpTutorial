using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class WLRApartmentsActual : OccupancyRecordsContainer
    {
        private OccupancyRecord _endingOccupancy;
        private OccupancyRecord _unoccupiedUnits;
        private OccupancyRecord _percentOccupancy;

        public OccupancyRecord UnitsAvailable { get; set; }
        public OccupancyRecord BeginningOccupancy { get; set; }
        public OccupancyRecord MoveIns { get; set; }
        public OccupancyRecord MoveOuts { get; set; }
        public OccupancyRecord TransferFromCottage { get; set; }
        public OccupancyRecord TransferToCottage { get; set; }
        public OccupancyRecord TransferToALHC { get; set; }
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
                    ? ZeroIfNull(BeginningOccupancy.January) + ZeroIfNull(MoveIns.January) + ZeroIfNull(MoveOuts.January) + ZeroIfNull(TransferFromCottage.January) + ZeroIfNull(TransferToCottage.January) + ZeroIfNull(TransferToALHC.January)
                    : (float?)null,
                February = (reportMonth >= 2)
                    ? ZeroIfNull(BeginningOccupancy.February) + ZeroIfNull(MoveIns.February) + ZeroIfNull(MoveOuts.February) + ZeroIfNull(TransferFromCottage.February) + ZeroIfNull(TransferToCottage.February) + ZeroIfNull(TransferToALHC.February)
                    : (float?)null,
                March = (reportMonth >= 3)
                    ? ZeroIfNull(BeginningOccupancy.March) + ZeroIfNull(MoveIns.March) + ZeroIfNull(MoveOuts.March) + ZeroIfNull(TransferFromCottage.March) + ZeroIfNull(TransferToCottage.March) + ZeroIfNull(TransferToALHC.March)
                    : (float?)null,
                April = (reportMonth >= 4)
                    ? ZeroIfNull(BeginningOccupancy.April) + ZeroIfNull(MoveIns.April) + ZeroIfNull(MoveOuts.April) + ZeroIfNull(TransferFromCottage.April) + ZeroIfNull(TransferToCottage.April) + ZeroIfNull(TransferToALHC.April)
                    : (float?)null,
                May = (reportMonth >= 5)
                    ? ZeroIfNull(BeginningOccupancy.May) + ZeroIfNull(MoveIns.May) + ZeroIfNull(MoveOuts.May) + ZeroIfNull(TransferFromCottage.May) + ZeroIfNull(TransferToCottage.May) + ZeroIfNull(TransferToALHC.May)
                    : (float?)null,
                June = (reportMonth >= 6)
                    ? ZeroIfNull(BeginningOccupancy.June) + ZeroIfNull(MoveIns.June) + ZeroIfNull(MoveOuts.June) + ZeroIfNull(TransferFromCottage.June) + ZeroIfNull(TransferToCottage.June) + ZeroIfNull(TransferToALHC.June)
                    : (float?)null,
                July = (reportMonth >= 7)
                    ? ZeroIfNull(BeginningOccupancy.July) + ZeroIfNull(MoveIns.July) + ZeroIfNull(MoveOuts.July) + ZeroIfNull(TransferFromCottage.July) + ZeroIfNull(TransferToCottage.July) + ZeroIfNull(TransferToALHC.July)
                    : (float?)null,
                August = (reportMonth >= 8)
                    ? ZeroIfNull(BeginningOccupancy.August) + ZeroIfNull(MoveIns.August) + ZeroIfNull(MoveOuts.August) + ZeroIfNull(TransferFromCottage.August) + ZeroIfNull(TransferToCottage.August) + ZeroIfNull(TransferToALHC.August)
                    : (float?)null,
                September = (reportMonth >= 9)
                    ? ZeroIfNull(BeginningOccupancy.September) + ZeroIfNull(MoveIns.September) + ZeroIfNull(MoveOuts.September) + ZeroIfNull(TransferFromCottage.September) + ZeroIfNull(TransferToCottage.September) + ZeroIfNull(TransferToALHC.September)
                    : (float?)null,
                October = (reportMonth >= 10)
                    ? ZeroIfNull(BeginningOccupancy.October) + ZeroIfNull(MoveIns.October) + ZeroIfNull(MoveOuts.October) + ZeroIfNull(TransferFromCottage.October) + ZeroIfNull(TransferToCottage.October) + ZeroIfNull(TransferToALHC.October)
                    : (float?)null,
                November = (reportMonth >= 11)
                    ? ZeroIfNull(BeginningOccupancy.November) + ZeroIfNull(MoveIns.November) + ZeroIfNull(MoveOuts.November) + ZeroIfNull(TransferFromCottage.November) + ZeroIfNull(TransferToCottage.November) + ZeroIfNull(TransferToALHC.November)
                    : (float?)null,
                December = (reportMonth >= 12)
                    ? ZeroIfNull(BeginningOccupancy.December) + ZeroIfNull(MoveIns.December) + ZeroIfNull(MoveOuts.December) + ZeroIfNull(TransferFromCottage.December) + ZeroIfNull(TransferToCottage.December) + ZeroIfNull(TransferToALHC.December)
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
                            TotalOrAverage = EndingOccupancy.TotalOrAverage.HasValue ? (float)Math.Round(Divide(EndingOccupancy.TotalOrAverage, UnitsAvailable.TotalOrAverage), 0) : (float?)null
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
                    ? ZeroIfNull(UnitsAvailable.January) - ZeroIfNull(EndingOccupancy.January)
                    : (float?)null,
                February = (reportMonth >= 2)
                    ? ZeroIfNull(UnitsAvailable.February) - ZeroIfNull(EndingOccupancy.February)
                    : (float?)null,
                March = (reportMonth >= 3)
                    ? ZeroIfNull(UnitsAvailable.March) - ZeroIfNull(EndingOccupancy.March)
                    : (float?)null,
                April = (reportMonth >= 4)
                    ? ZeroIfNull(UnitsAvailable.April) - ZeroIfNull(EndingOccupancy.April)
                    : (float?)null,
                May = (reportMonth >= 5)
                    ? ZeroIfNull(UnitsAvailable.May) - ZeroIfNull(EndingOccupancy.May)
                    : (float?)null,
                June = (reportMonth >= 6)
                    ? ZeroIfNull(UnitsAvailable.June) - ZeroIfNull(EndingOccupancy.June)
                    : (float?)null,
                July = (reportMonth >= 7)
                    ? ZeroIfNull(UnitsAvailable.July) - ZeroIfNull(EndingOccupancy.July)
                    : (float?)null,
                August = (reportMonth >= 8)
                    ? ZeroIfNull(UnitsAvailable.August) - ZeroIfNull(EndingOccupancy.August)
                    : (float?)null,
                September = (reportMonth >= 9)
                    ? ZeroIfNull(UnitsAvailable.September) - ZeroIfNull(EndingOccupancy.September)
                    : (float?)null,
                October = (reportMonth >= 10)
                    ? ZeroIfNull(UnitsAvailable.October) - ZeroIfNull(EndingOccupancy.October)
                    : (float?)null,
                November = (reportMonth >= 11)
                    ? ZeroIfNull(UnitsAvailable.November) - ZeroIfNull(EndingOccupancy.November)
                    : (float?)null,
                December = (reportMonth >= 12)
                    ? ZeroIfNull(UnitsAvailable.December) - ZeroIfNull(EndingOccupancy.December)
                    : (float?)null
            };
            _unoccupiedUnits.TotalOrAverage = _unoccupiedUnits.CalculateAverageValue();
        }



    }
}
