using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IndependentLivingBudget : OccupancyRecordsContainer
    {
        private OccupancyRecord _varianceFromBudget;

        //TODO: CHANGE THIS TO OccupancyRecord ActualUnitsAvailable and fetch it once in constructor of section builder and set it in actual and budget
        public IndependentLivingActual ILActual { get; set; }
        public OccupancyRecord BeginningOccupancy { get; set; }
        public OccupancyRecord MoveIns { get; set; }
        public OccupancyRecord MoveOuts { get; set; }
        public OccupancyRecord EndingOccupancy 
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
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
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }
        public OccupancyRecord PercentOccupancy
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = EndingOccupancy.January ?? (float)Math.Round(Divide(EndingOccupancy.January, ILActual.UnitsAvailable.January), 0),
                    February = EndingOccupancy.February ?? (float)Math.Round(Divide(EndingOccupancy.February, ILActual.UnitsAvailable.February), 0),
                    March = EndingOccupancy.March ?? (float)Math.Round(Divide(EndingOccupancy.March, ILActual.UnitsAvailable.March), 0),
                    April = EndingOccupancy.April ?? (float)Math.Round(Divide(EndingOccupancy.April, ILActual.UnitsAvailable.April), 0),
                    May = EndingOccupancy.May ?? (float)Math.Round(Divide(EndingOccupancy.May, ILActual.UnitsAvailable.May), 0),
                    June = EndingOccupancy.June ?? (float)Math.Round(Divide(EndingOccupancy.June, ILActual.UnitsAvailable.June), 0),
                    July = EndingOccupancy.July ?? (float)Math.Round(Divide(EndingOccupancy.July, ILActual.UnitsAvailable.July), 0),
                    August = EndingOccupancy.August ?? (float)Math.Round(Divide(EndingOccupancy.August, ILActual.UnitsAvailable.August), 0),
                    September = EndingOccupancy.September ?? (float)Math.Round(Divide(EndingOccupancy.September, ILActual.UnitsAvailable.September), 0),
                    October = EndingOccupancy.October ?? (float)Math.Round(Divide(EndingOccupancy.October, ILActual.UnitsAvailable.October), 0),
                    November = EndingOccupancy.November ?? (float)Math.Round(Divide(EndingOccupancy.November, ILActual.UnitsAvailable.November), 0),
                    December = EndingOccupancy.December ?? (float)Math.Round(Divide(EndingOccupancy.December, ILActual.UnitsAvailable.December), 0),
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
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
                    ? Subtract(ILActual.EndingOccupancy.January, EndingOccupancy.January)
                    : (float?)null,
                February = (reportMonth >= 2)
                    ? Subtract(ILActual.EndingOccupancy.February, EndingOccupancy.February)
                    : (float?)null,
                March = (reportMonth >= 3)
                    ? Subtract(ILActual.EndingOccupancy.March, EndingOccupancy.March)
                    : (float?)null,
                April = (reportMonth >= 4)
                    ? Subtract(ILActual.EndingOccupancy.April, EndingOccupancy.April)
                    : (float?)null,
                May = (reportMonth >= 5)
                    ? Subtract(ILActual.EndingOccupancy.May, EndingOccupancy.May)
                    : (float?)null,
                June = (reportMonth >= 6)
                    ? Subtract(ILActual.EndingOccupancy.June, EndingOccupancy.June)
                    : (float?)null,
                July = (reportMonth >= 7)
                    ? Subtract(ILActual.EndingOccupancy.July, EndingOccupancy.July)
                    : (float?)null,
                August = (reportMonth >= 8)
                    ? Subtract(ILActual.EndingOccupancy.August, EndingOccupancy.August)
                    : (float?)null,
                September = (reportMonth >= 9)
                    ? Subtract(ILActual.EndingOccupancy.September, EndingOccupancy.September)
                    : (float?)null,
                October = (reportMonth >= 10)
                    ? Subtract(ILActual.EndingOccupancy.October, EndingOccupancy.October)
                    : (float?)null,
                November = (reportMonth >= 11)
                    ? Subtract(ILActual.EndingOccupancy.November, EndingOccupancy.November)
                    : (float?)null,
                December = (reportMonth >= 12)
                    ? Subtract(ILActual.EndingOccupancy.December, EndingOccupancy.December)
                    : (float?)null
            };
        }
    }
}
