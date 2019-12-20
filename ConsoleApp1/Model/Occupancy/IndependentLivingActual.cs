using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IndependentLivingActual
    {
        public OccupancyRecord UnitsAvailable { get; set; }
        public OccupancyRecord BeginningOccupancy { get; set; }
        public OccupancyRecord MoveIns { get; set; }
        public OccupancyRecord MoveOuts { get; set; }
        public OccupancyRecord Transfers { get; set; }
        //public OccupancyRecord EndingOccupancy { get; set; }
        public OccupancyRecord EndingOccupancy
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = BeginningOccupancy.January + MoveIns.January + MoveOuts.January + Transfers.January,
                    February = BeginningOccupancy.February + MoveIns.February + MoveOuts.February + Transfers.February,
                    March = BeginningOccupancy.March + MoveIns.March + MoveOuts.March + Transfers.March,
                    April = BeginningOccupancy.April + MoveIns.April + MoveOuts.April + Transfers.April,
                    May = BeginningOccupancy.May + MoveIns.May + MoveOuts.May + Transfers.May,
                    June = BeginningOccupancy.June + MoveIns.June + MoveOuts.June + Transfers.June,
                    July = BeginningOccupancy.July + MoveIns.July + MoveOuts.July + Transfers.July,
                    August = BeginningOccupancy.August + MoveIns.August + MoveOuts.August + Transfers.August,
                    September = BeginningOccupancy.September + MoveIns.September + MoveOuts.September + Transfers.September,
                    October = BeginningOccupancy.October + MoveIns.October + MoveOuts.October + Transfers.October,
                    November = BeginningOccupancy.November + MoveIns.November + MoveOuts.November + Transfers.November,
                    December = BeginningOccupancy.December + MoveIns.December + MoveOuts.December + Transfers.December
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
                    January = UnitsAvailable.January > 0 ? (float)Math.Round(EndingOccupancy.January / UnitsAvailable.January, 0) : 0,
                    February = UnitsAvailable.February > 0 ? (float)Math.Round(EndingOccupancy.February / UnitsAvailable.February, 0) : 0,
                    March = UnitsAvailable.March > 0 ? (float)Math.Round(EndingOccupancy.March / UnitsAvailable.March, 0) : 0,
                    April = UnitsAvailable.April > 0 ? (float)Math.Round(EndingOccupancy.April / UnitsAvailable.April, 0) : 0,
                    May = UnitsAvailable.May > 0 ? (float)Math.Round(EndingOccupancy.May / UnitsAvailable.May, 0) : 0,
                    June = UnitsAvailable.June > 0 ? (float)Math.Round(EndingOccupancy.June / UnitsAvailable.June, 0) : 0,
                    July = UnitsAvailable.July > 0 ? (float)Math.Round(EndingOccupancy.July / UnitsAvailable.July, 0) : 0,
                    August = UnitsAvailable.August > 0 ? (float)Math.Round(EndingOccupancy.August / UnitsAvailable.August, 0) : 0,
                    September = UnitsAvailable.September > 0 ? (float)Math.Round(EndingOccupancy.September / UnitsAvailable.September, 0) : 0,
                    October = UnitsAvailable.October > 0 ? (float)Math.Round(EndingOccupancy.October / UnitsAvailable.October, 0) : 0,
                    November = UnitsAvailable.November > 0 ? (float)Math.Round(EndingOccupancy.November / UnitsAvailable.November, 0) : 0,
                    December = UnitsAvailable.December > 0 ? (float)Math.Round(EndingOccupancy.December / UnitsAvailable.December, 0) : 0
                };
                record.TotalOrAverage = UnitsAvailable.TotalOrAverage > 0 ? (float)Math.Round(EndingOccupancy.TotalOrAverage / UnitsAvailable.TotalOrAverage, 0) : 0;
                return record;

            }
        }

        public OccupancyRecord UnoccupiedUnits
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = UnitsAvailable.January - EndingOccupancy.January,
                    February = UnitsAvailable.February - EndingOccupancy.February,
                    March = UnitsAvailable.March - EndingOccupancy.March,
                    April = UnitsAvailable.April - EndingOccupancy.April,
                    May = UnitsAvailable.May - EndingOccupancy.May,
                    June = UnitsAvailable.June - EndingOccupancy.June,
                    July = UnitsAvailable.July - EndingOccupancy.July,
                    August = UnitsAvailable.August - EndingOccupancy.August,
                    September = UnitsAvailable.September - EndingOccupancy.September,
                    October = UnitsAvailable.October - EndingOccupancy.October,
                    November = UnitsAvailable.November - EndingOccupancy.November,
                    December = UnitsAvailable.December - EndingOccupancy.December
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }
    }
}
