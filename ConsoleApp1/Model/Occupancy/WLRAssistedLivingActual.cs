using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class WLRAssistedLivingActual
    {
        public OccupancyRecord UnitsAvailable { get; set; }
        public OccupancyRecord AverageFFS { get; set; }
        public OccupancyRecord AverageLC { get; set; }
        public OccupancyRecord AverageOccupancy
        {
            get
            {
                if (AverageFFS != null && AverageLC != null)
                {
                    OccupancyRecord record = new OccupancyRecord
                    {
                        January = AverageFFS.January + AverageLC.January,
                        February = AverageFFS.February + AverageLC.February,
                        March = AverageFFS.March + AverageLC.March,
                        April = AverageFFS.April + AverageLC.April,
                        May = AverageFFS.May + AverageLC.May,
                        June = AverageFFS.June + AverageLC.June,
                        July = AverageFFS.July + AverageLC.July,
                        August = AverageFFS.August + AverageLC.August,
                        September = AverageFFS.September + AverageLC.September,
                        October = AverageFFS.October + AverageLC.October,
                        November = AverageFFS.November + AverageLC.November,
                        December = AverageFFS.December + AverageLC.December
                    };
                    record.TotalOrAverage = record.CalculateAverageValue();
                    return record;
                }
                return new OccupancyRecord();
            }
        }

        public OccupancyRecord PercentUnitOccupancy
        {
            get
            {
                if (UnitsAvailable != null && AverageOccupancy != null)
                {
                    OccupancyRecord record = new OccupancyRecord
                    {
                        January = UnitsAvailable.January > 0 ? (float)Math.Round(AverageOccupancy.January / UnitsAvailable.January, 0) : 0,
                        February = UnitsAvailable.February > 0 ? (float)Math.Round(AverageOccupancy.February / UnitsAvailable.February, 0) : 0,
                        March = UnitsAvailable.March > 0 ? (float)Math.Round(AverageOccupancy.March / UnitsAvailable.March, 0) : 0,
                        April = UnitsAvailable.April > 0 ? (float)Math.Round(AverageOccupancy.April / UnitsAvailable.April, 0) : 0,
                        May = UnitsAvailable.May > 0 ? (float)Math.Round(AverageOccupancy.May / UnitsAvailable.May, 0) : 0,
                        June = UnitsAvailable.June > 0 ? (float)Math.Round(AverageOccupancy.June / UnitsAvailable.June, 0) : 0,
                        July = UnitsAvailable.July > 0 ? (float)Math.Round(AverageOccupancy.July / UnitsAvailable.July, 0) : 0,
                        August = UnitsAvailable.August > 0 ? (float)Math.Round(AverageOccupancy.August / UnitsAvailable.August, 0) : 0,
                        September = UnitsAvailable.September > 0 ? (float)Math.Round(AverageOccupancy.September / UnitsAvailable.September, 0) : 0,
                        October = UnitsAvailable.October > 0 ? (float)Math.Round(AverageOccupancy.October / UnitsAvailable.October, 0) : 0,
                        November = UnitsAvailable.November > 0 ? (float)Math.Round(AverageOccupancy.November / UnitsAvailable.November, 0) : 0,
                        December = UnitsAvailable.December > 0 ? (float)Math.Round(AverageOccupancy.December / UnitsAvailable.December, 0) : 0
                    };
                    record.TotalOrAverage = UnitsAvailable.TotalOrAverage > 0 ? (float)Math.Round(AverageOccupancy.TotalOrAverage / UnitsAvailable.TotalOrAverage, 0) : 0;
                    return record;
                }
                return new OccupancyRecord();
            }
        }

        public OccupancyRecord UnoccupiedUnits
        {
            get
            {
                if (UnitsAvailable != null && AverageOccupancy != null)
                {
                    OccupancyRecord record = new OccupancyRecord
                    {
                        January = UnitsAvailable.January - AverageOccupancy.January,
                        February = UnitsAvailable.February - AverageOccupancy.February,
                        March = UnitsAvailable.March - AverageOccupancy.March,
                        April = UnitsAvailable.April - AverageOccupancy.April,
                        May = UnitsAvailable.May - AverageOccupancy.May,
                        June = UnitsAvailable.June - AverageOccupancy.June,
                        July = UnitsAvailable.July - AverageOccupancy.July,
                        August = UnitsAvailable.August - AverageOccupancy.August,
                        September = UnitsAvailable.September - AverageOccupancy.September,
                        October = UnitsAvailable.October - AverageOccupancy.October,
                        November = UnitsAvailable.November - AverageOccupancy.November,
                        December = UnitsAvailable.December - AverageOccupancy.December
                    };
                    record.TotalOrAverage = record.CalculateAverageValue();
                    return record;
                }
                return new OccupancyRecord();
            }
        }
    }
}
