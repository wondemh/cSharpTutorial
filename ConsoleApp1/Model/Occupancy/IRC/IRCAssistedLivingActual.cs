using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IRCAssistedLivingActual : OccupancyRecordsContainer
    {
        public OccupancyRecord UnitsAvailable { get; set; }
        public OccupancyRecord LicensedFor { get; set; }
        public OccupancyRecord AverageFFSFirst { get; set; }
        public OccupancyRecord AverageFFSSecond { get; set; }
        public OccupancyRecord AverageLCFirst { get; set; }
        public OccupancyRecord AverageLCSecond { get; set; }
        public OccupancyRecord EndingAverageOccupancy 
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = AverageFFSFirst.January ?? ZeroIfNull(AverageFFSFirst.January) + ZeroIfNull(AverageLCFirst.January),
                    February = AverageFFSFirst.February ?? ZeroIfNull(AverageFFSFirst.February) + ZeroIfNull(AverageLCFirst.February),
                    March = AverageFFSFirst.March ?? ZeroIfNull(AverageFFSFirst.March) + ZeroIfNull(AverageLCFirst.March),
                    April = AverageFFSFirst.April ?? ZeroIfNull(AverageFFSFirst.April) + ZeroIfNull(AverageLCFirst.April),
                    May = AverageFFSFirst.May ?? ZeroIfNull(AverageFFSFirst.May) + ZeroIfNull(AverageLCFirst.May),
                    June = AverageFFSFirst.June ?? ZeroIfNull(AverageFFSFirst.June) + ZeroIfNull(AverageLCFirst.June),
                    July = AverageFFSFirst.July ?? ZeroIfNull(AverageFFSFirst.July) + ZeroIfNull(AverageLCFirst.July),
                    August = AverageFFSFirst.August ?? ZeroIfNull(AverageFFSFirst.August) + ZeroIfNull(AverageLCFirst.August),
                    September = AverageFFSFirst.September ?? ZeroIfNull(AverageFFSFirst.September) + ZeroIfNull(AverageLCFirst.September),
                    October = AverageFFSFirst.October ?? ZeroIfNull(AverageFFSFirst.October) + ZeroIfNull(AverageLCFirst.October),
                    November = AverageFFSFirst.November ?? ZeroIfNull(AverageFFSFirst.November) + ZeroIfNull(AverageLCFirst.November),
                    December = AverageFFSFirst.December ?? ZeroIfNull(AverageFFSFirst.December) + ZeroIfNull(AverageLCFirst.December)
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }
        public OccupancyRecord PercentUnitOccupancy 
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = EndingAverageOccupancy.January ?? Divide(EndingAverageOccupancy.January, UnitsAvailable.January),
                    February = EndingAverageOccupancy.February ?? Divide(EndingAverageOccupancy.February, UnitsAvailable.February),
                    March = EndingAverageOccupancy.March ?? Divide(EndingAverageOccupancy.March, UnitsAvailable.March),
                    April = EndingAverageOccupancy.April ?? Divide(EndingAverageOccupancy.April, UnitsAvailable.April),
                    May = EndingAverageOccupancy.May ?? Divide(EndingAverageOccupancy.May, UnitsAvailable.May),
                    June = EndingAverageOccupancy.June ?? Divide(EndingAverageOccupancy.June, UnitsAvailable.June),
                    July = EndingAverageOccupancy.July ?? Divide(EndingAverageOccupancy.July, UnitsAvailable.July),
                    August = EndingAverageOccupancy.August ?? Divide(EndingAverageOccupancy.August, UnitsAvailable.August),
                    September = EndingAverageOccupancy.September ?? Divide(EndingAverageOccupancy.September, UnitsAvailable.September),
                    October = EndingAverageOccupancy.October ?? Divide(EndingAverageOccupancy.October, UnitsAvailable.October),
                    November = EndingAverageOccupancy.November ?? Divide(EndingAverageOccupancy.November, UnitsAvailable.November),
                    December = EndingAverageOccupancy.December ?? Divide(EndingAverageOccupancy.December, UnitsAvailable.December),
                    TotalOrAverage = Divide(EndingAverageOccupancy.TotalOrAverage, UnitsAvailable.TotalOrAverage)
                };
                return record;
            }

        }
        public OccupancyRecord EndingAveragePersonOccupancy
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = EndingAverageOccupancy.January ?? ZeroIfNull(AverageFFSFirst.January) + ZeroIfNull(AverageFFSSecond.January) + ZeroIfNull(AverageLCFirst.January) + ZeroIfNull(AverageLCSecond.January),
                    February = EndingAverageOccupancy.February ?? ZeroIfNull(AverageFFSFirst.February) + ZeroIfNull(AverageFFSSecond.February) + ZeroIfNull(AverageLCFirst.February) + ZeroIfNull(AverageLCSecond.February),
                    March = EndingAverageOccupancy.March ?? ZeroIfNull(AverageFFSFirst.March) + ZeroIfNull(AverageFFSSecond.March) + ZeroIfNull(AverageLCFirst.March) + ZeroIfNull(AverageLCSecond.March),
                    April = EndingAverageOccupancy.April ?? AverageFFSFirst.April + AverageFFSSecond.April + AverageLCFirst.April + AverageLCSecond.April,
                    May = EndingAverageOccupancy.May ?? ZeroIfNull(AverageFFSFirst.May) + ZeroIfNull(AverageFFSSecond.May) + ZeroIfNull(AverageLCFirst.May) + ZeroIfNull(AverageLCSecond.May),
                    June = EndingAverageOccupancy.June ?? ZeroIfNull(AverageFFSFirst.June) + ZeroIfNull(AverageFFSSecond.June) + ZeroIfNull(AverageLCFirst.June) + ZeroIfNull(AverageLCSecond.June),
                    July = EndingAverageOccupancy.July ?? ZeroIfNull(AverageFFSFirst.July) + ZeroIfNull(AverageFFSSecond.July) + ZeroIfNull(AverageLCFirst.July) + ZeroIfNull(AverageLCSecond.July),
                    August = EndingAverageOccupancy.August ?? ZeroIfNull(AverageFFSFirst.August) + ZeroIfNull(AverageFFSSecond.August) + ZeroIfNull(AverageLCFirst.August) + ZeroIfNull(AverageLCSecond.August),
                    September = EndingAverageOccupancy.September ?? ZeroIfNull(AverageFFSFirst.September) + ZeroIfNull(AverageFFSSecond.September) + ZeroIfNull(AverageLCFirst.September) + ZeroIfNull(AverageLCSecond.September),
                    October = EndingAverageOccupancy.October ?? ZeroIfNull(AverageFFSFirst.October) + ZeroIfNull(AverageFFSSecond.October) + ZeroIfNull(AverageLCFirst.October) + ZeroIfNull(AverageLCSecond.October),
                    November = EndingAverageOccupancy.November ?? ZeroIfNull(AverageFFSFirst.November) + ZeroIfNull(AverageFFSSecond.November) + ZeroIfNull(AverageLCFirst.November) + ZeroIfNull(AverageLCSecond.November),
                    December = EndingAverageOccupancy.December ?? ZeroIfNull(AverageFFSFirst.December) + ZeroIfNull(AverageFFSSecond.December) + ZeroIfNull(AverageLCFirst.December) + ZeroIfNull(AverageLCSecond.December)
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }
        public OccupancyRecord PercentLicensedOccupancy
        {
            get
            {
                if (EndingAveragePersonOccupancy != null && LicensedFor != null)
                {
                    OccupancyRecord record = new OccupancyRecord();
                    record.January = EndingAveragePersonOccupancy.January ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.January, LicensedFor.January), 0);
                    record.February = EndingAveragePersonOccupancy.February ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.February, LicensedFor.February), 0);
                    record.March = EndingAveragePersonOccupancy.March ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.March, LicensedFor.March), 0);
                    record.April = EndingAveragePersonOccupancy.April ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.April, LicensedFor.April), 0);
                    record.May = EndingAveragePersonOccupancy.May ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.May, LicensedFor.May), 0);
                    record.June = EndingAveragePersonOccupancy.June ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.June, LicensedFor.June), 0);
                    record.July = EndingAveragePersonOccupancy.July ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.July, LicensedFor.July), 0);
                    record.August = EndingAveragePersonOccupancy.August ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.August, LicensedFor.August), 0);
                    record.September = EndingAveragePersonOccupancy.September ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.September, LicensedFor.September), 0);
                    record.October = EndingAveragePersonOccupancy.October ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.October, LicensedFor.October), 0);
                    record.November = EndingAveragePersonOccupancy.November ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.November, LicensedFor.November), 0);
                    record.December = EndingAveragePersonOccupancy.December ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.December, LicensedFor.December), 0);
                    record.TotalOrAverage = (float)Math.Round(Divide(EndingAveragePersonOccupancy.TotalOrAverage, LicensedFor.TotalOrAverage), 0);
                    return record;
                }
                return new OccupancyRecord(true);
            }
        }
    }
}
