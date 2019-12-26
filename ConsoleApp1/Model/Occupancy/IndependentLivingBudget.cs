using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IndependentLivingBudget : OccupancyRecordsContainer
    {
        private OccupancyRecord _varianceFromBudget;
        private OccupancyRecord _endingOccupancy;
        private OccupancyRecord _percentOccupancy;

        //TODO: CHANGE THIS TO OccupancyRecord ActualUnitsAvailable and fetch it once in constructor of section builder and set it in actual and budget
        public IndependentLivingActual IndependentLivingActual { get; set; }
        public OccupancyRecord BeginningOccupancy { get; set; }
        public OccupancyRecord MoveIns { get; set; }
        public OccupancyRecord MoveOuts { get; set; }
        public OccupancyRecord EndingOccupancy 
        {
            get
            {
                if (_endingOccupancy == null)
                {
                    _endingOccupancy = new OccupancyRecord
                    {
                        January = ZeroIfNull(BeginningOccupancy.January) + ZeroIfNull(MoveIns.January) + ZeroIfNull(MoveOuts.January),
                        February = ZeroIfNull(BeginningOccupancy.February) + ZeroIfNull(MoveIns.February) + ZeroIfNull(MoveOuts.February),
                        March = ZeroIfNull(BeginningOccupancy.March) + ZeroIfNull(MoveIns.March) + ZeroIfNull(MoveOuts.March),
                        April = ZeroIfNull(BeginningOccupancy.April) + ZeroIfNull(MoveIns.April) + ZeroIfNull(MoveOuts.April),
                        May = ZeroIfNull(BeginningOccupancy.May) + ZeroIfNull(MoveIns.May) + ZeroIfNull(MoveOuts.May),
                        June = ZeroIfNull(BeginningOccupancy.June) + ZeroIfNull(MoveIns.June) + ZeroIfNull(MoveOuts.June),
                        July = ZeroIfNull(BeginningOccupancy.July) + ZeroIfNull(MoveIns.July) + ZeroIfNull(MoveOuts.July),
                        August = ZeroIfNull(BeginningOccupancy.August) + ZeroIfNull(MoveIns.August) + ZeroIfNull(MoveOuts.August),
                        September = ZeroIfNull(BeginningOccupancy.September) + ZeroIfNull(MoveIns.September) + ZeroIfNull(MoveOuts.September),
                        October = ZeroIfNull(BeginningOccupancy.October) + ZeroIfNull(MoveIns.October) + ZeroIfNull(MoveOuts.October),
                        November = ZeroIfNull(BeginningOccupancy.November) + ZeroIfNull(MoveIns.November) + ZeroIfNull(MoveOuts.November),
                        December = ZeroIfNull(BeginningOccupancy.December) + ZeroIfNull(MoveIns.December) + ZeroIfNull(MoveOuts.December)
                    };
                    _endingOccupancy.TotalOrAverage = _endingOccupancy.CalculateAverageValue();
                }
                return _endingOccupancy;
            }
        }
        public OccupancyRecord PercentOccupancy
        {
            get
            {
                if (_percentOccupancy == null)
                {
                    _percentOccupancy = new OccupancyRecord
                    {
                        January = EndingOccupancy.January.HasValue ? (float)Math.Round(Percent(EndingOccupancy.January, IndependentLivingActual.UnitsAvailable.January), 0) : (float?)null,
                        February = EndingOccupancy.February.HasValue ? (float)Math.Round(Percent(EndingOccupancy.February, IndependentLivingActual.UnitsAvailable.February), 0) : (float?)null,
                        March = EndingOccupancy.March.HasValue ? (float)Math.Round(Percent(EndingOccupancy.March, IndependentLivingActual.UnitsAvailable.March), 0) : (float?)null,
                        April = EndingOccupancy.April.HasValue ? (float)Math.Round(Percent(EndingOccupancy.April, IndependentLivingActual.UnitsAvailable.April), 0) : (float?)null,
                        May = EndingOccupancy.May.HasValue ? (float)Math.Round(Percent(EndingOccupancy.May, IndependentLivingActual.UnitsAvailable.May), 0) : (float?)null,
                        June = EndingOccupancy.June.HasValue ? (float)Math.Round(Percent(EndingOccupancy.June, IndependentLivingActual.UnitsAvailable.June), 0) : (float?)null,
                        July = EndingOccupancy.July.HasValue ? (float)Math.Round(Percent(EndingOccupancy.July, IndependentLivingActual.UnitsAvailable.July), 0) : (float?)null,
                        August = EndingOccupancy.August.HasValue ? (float)Math.Round(Percent(EndingOccupancy.August, IndependentLivingActual.UnitsAvailable.August), 0) : (float?)null,
                        September = EndingOccupancy.September.HasValue ? (float)Math.Round(Percent(EndingOccupancy.September, IndependentLivingActual.UnitsAvailable.September), 0) : (float?)null,
                        October = EndingOccupancy.October.HasValue ? (float)Math.Round(Percent(EndingOccupancy.October, IndependentLivingActual.UnitsAvailable.October), 0) : (float?)null,
                        November = EndingOccupancy.November.HasValue ? (float)Math.Round(Percent(EndingOccupancy.November, IndependentLivingActual.UnitsAvailable.November), 0) : (float?)null,
                        December = EndingOccupancy.December.HasValue ? (float)Math.Round(Percent(EndingOccupancy.December, IndependentLivingActual.UnitsAvailable.December), 0) : (float?)null,
                    };
                    _percentOccupancy.TotalOrAverage = _percentOccupancy.CalculateAverageValue();
                }
                return _percentOccupancy;
            }
        }
        public OccupancyRecord VarianceFromBudget
        {
            get
            {
                return _varianceFromBudget;
            }
        }
        public void SetVarianceFromBudget(int reportMonth)
        {
            _varianceFromBudget = new OccupancyRecord
            {
                January = (reportMonth >= 1)
                    ? Subtract(IndependentLivingActual.EndingOccupancy.January, EndingOccupancy.January)
                    : (float?)null,
                February = (reportMonth >= 2)
                    ? Subtract(IndependentLivingActual.EndingOccupancy.February, EndingOccupancy.February)
                    : (float?)null,
                March = (reportMonth >= 3)
                    ? Subtract(IndependentLivingActual.EndingOccupancy.March, EndingOccupancy.March)
                    : (float?)null,
                April = (reportMonth >= 4)
                    ? Subtract(IndependentLivingActual.EndingOccupancy.April, EndingOccupancy.April)
                    : (float?)null,
                May = (reportMonth >= 5)
                    ? Subtract(IndependentLivingActual.EndingOccupancy.May, EndingOccupancy.May)
                    : (float?)null,
                June = (reportMonth >= 6)
                    ? Subtract(IndependentLivingActual.EndingOccupancy.June, EndingOccupancy.June)
                    : (float?)null,
                July = (reportMonth >= 7)
                    ? Subtract(IndependentLivingActual.EndingOccupancy.July, EndingOccupancy.July)
                    : (float?)null,
                August = (reportMonth >= 8)
                    ? Subtract(IndependentLivingActual.EndingOccupancy.August, EndingOccupancy.August)
                    : (float?)null,
                September = (reportMonth >= 9)
                    ? Subtract(IndependentLivingActual.EndingOccupancy.September, EndingOccupancy.September)
                    : (float?)null,
                October = (reportMonth >= 10)
                    ? Subtract(IndependentLivingActual.EndingOccupancy.October, EndingOccupancy.October)
                    : (float?)null,
                November = (reportMonth >= 11)
                    ? Subtract(IndependentLivingActual.EndingOccupancy.November, EndingOccupancy.November)
                    : (float?)null,
                December = (reportMonth >= 12)
                    ? Subtract(IndependentLivingActual.EndingOccupancy.December, EndingOccupancy.December)
                    : (float?)null
            };
        }
    }
}
