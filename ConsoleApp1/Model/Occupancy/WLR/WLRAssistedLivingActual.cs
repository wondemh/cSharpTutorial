using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class WLRAssistedLivingActual : OccupancyRecordsContainer
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
                        January = ZeroIfNull(AverageFFS.January) + ZeroIfNull(AverageLC.January),
                        February = ZeroIfNull(AverageFFS.February) + ZeroIfNull(AverageLC.February),
                        March = ZeroIfNull(AverageFFS.March) + ZeroIfNull(AverageLC.March),
                        April = ZeroIfNull(AverageFFS.April) + ZeroIfNull(AverageLC.April),
                        May = ZeroIfNull(AverageFFS.May) + ZeroIfNull(AverageLC.May),
                        June = ZeroIfNull(AverageFFS.June) + ZeroIfNull(AverageLC.June),
                        July = ZeroIfNull(AverageFFS.July) + ZeroIfNull(AverageLC.July),
                        August = ZeroIfNull(AverageFFS.August) + ZeroIfNull(AverageLC.August),
                        September = ZeroIfNull(AverageFFS.September) + ZeroIfNull(AverageLC.September),
                        October = ZeroIfNull(AverageFFS.October) + ZeroIfNull(AverageLC.October),
                        November = ZeroIfNull(AverageFFS.November) + ZeroIfNull(AverageLC.November),
                        December = ZeroIfNull(AverageFFS.December) + ZeroIfNull(AverageLC.December)
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
                OccupancyRecord record = new OccupancyRecord
                {
                    January = AverageOccupancy.January ?? Divide(AverageOccupancy.January, UnitsAvailable.January),
                    February = AverageOccupancy.February ?? Divide(AverageOccupancy.February, UnitsAvailable.February),
                    March = AverageOccupancy.March ?? Divide(AverageOccupancy.March, UnitsAvailable.March),
                    April = AverageOccupancy.April ?? Divide(AverageOccupancy.April, UnitsAvailable.April),
                    May = AverageOccupancy.May ?? Divide(AverageOccupancy.May, UnitsAvailable.May),
                    June = AverageOccupancy.June ?? Divide(AverageOccupancy.June, UnitsAvailable.June),
                    July = AverageOccupancy.July ?? Divide(AverageOccupancy.July, UnitsAvailable.July),
                    August = AverageOccupancy.August ?? Divide(AverageOccupancy.August, UnitsAvailable.August),
                    September = AverageOccupancy.September ?? Divide(AverageOccupancy.September, UnitsAvailable.September),
                    October = AverageOccupancy.October ?? Divide(AverageOccupancy.October, UnitsAvailable.October),
                    November = AverageOccupancy.November ?? Divide(AverageOccupancy.November, UnitsAvailable.November),
                    December = AverageOccupancy.December ?? Divide(AverageOccupancy.December, UnitsAvailable.December),
                    TotalOrAverage = Divide(AverageOccupancy.TotalOrAverage, UnitsAvailable.TotalOrAverage)
                };
                return record;
            }
        }

        public OccupancyRecord UnoccupiedUnits
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = AverageOccupancy.January ?? Subtract(UnitsAvailable.January, AverageOccupancy.January),
                    February = AverageOccupancy.February ?? Subtract(UnitsAvailable.February, AverageOccupancy.February),
                    March = AverageOccupancy.March ?? Subtract(UnitsAvailable.March, AverageOccupancy.March),
                    April = AverageOccupancy.April ?? Subtract(UnitsAvailable.April, AverageOccupancy.April),
                    May = AverageOccupancy.May ?? Subtract(UnitsAvailable.May, AverageOccupancy.May),
                    June = AverageOccupancy.June ?? Subtract(UnitsAvailable.June, AverageOccupancy.June),
                    July = AverageOccupancy.July ?? Subtract(UnitsAvailable.July, AverageOccupancy.July),
                    August = AverageOccupancy.August ?? Subtract(UnitsAvailable.August, AverageOccupancy.August),
                    September = AverageOccupancy.September ?? Subtract(UnitsAvailable.September, AverageOccupancy.September),
                    October = AverageOccupancy.October ?? Subtract(UnitsAvailable.October, AverageOccupancy.October),
                    November = AverageOccupancy.November ?? Subtract(UnitsAvailable.November, AverageOccupancy.November),
                    December = AverageOccupancy.December ?? Subtract(UnitsAvailable.December, AverageOccupancy.December)
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }
    }
}
