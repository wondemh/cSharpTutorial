using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IRCMemorySupportActual : OccupancyRecordsContainer
    {
        public OccupancyRecord UnitsAvailable { get; set; }
        public OccupancyRecord LicensedFor { get; set; }
        public OccupancyRecord PrivateMSFFSFirst { get; set; }
        public OccupancyRecord PrivateMSFFSSecond { get; set; }
        public OccupancyRecord PrivateMSLCFirst { get; set; }
        public OccupancyRecord PrivateMSLCSecond { get; set; }
        public OccupancyRecord EndingAverageOccupancy
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = ZeroIfNull(PrivateMSFFSFirst.January) + ZeroIfNull(PrivateMSFFSSecond.January) + ZeroIfNull(PrivateMSLCFirst.January) + ZeroIfNull(PrivateMSLCSecond.January),
                    February = ZeroIfNull(PrivateMSFFSFirst.February) + ZeroIfNull(PrivateMSFFSSecond.February) + ZeroIfNull(PrivateMSLCFirst.February) + ZeroIfNull(PrivateMSLCSecond.February),
                    March = ZeroIfNull(PrivateMSFFSFirst.March) + ZeroIfNull(PrivateMSFFSSecond.March) + ZeroIfNull(PrivateMSLCFirst.March) + ZeroIfNull(PrivateMSLCSecond.March),
                    April = ZeroIfNull(PrivateMSFFSFirst.April) + ZeroIfNull(PrivateMSFFSSecond.April) + ZeroIfNull(PrivateMSLCFirst.April) + ZeroIfNull(PrivateMSLCSecond.April),
                    May = ZeroIfNull(PrivateMSFFSFirst.May) + ZeroIfNull(PrivateMSFFSSecond.May) + ZeroIfNull(PrivateMSLCFirst.May) + ZeroIfNull(PrivateMSLCSecond.May),
                    June = ZeroIfNull(PrivateMSFFSFirst.June) + ZeroIfNull(PrivateMSFFSSecond.June) + ZeroIfNull(PrivateMSLCFirst.June) + ZeroIfNull(PrivateMSLCSecond.June),
                    July = ZeroIfNull(PrivateMSFFSFirst.July) + ZeroIfNull(PrivateMSFFSSecond.July) + ZeroIfNull(PrivateMSLCFirst.July) + ZeroIfNull(PrivateMSLCSecond.July),
                    August = ZeroIfNull(PrivateMSFFSFirst.August) + ZeroIfNull(PrivateMSFFSSecond.August) + ZeroIfNull(PrivateMSLCFirst.August) + ZeroIfNull(PrivateMSLCSecond.August),
                    September = ZeroIfNull(PrivateMSFFSFirst.September) + ZeroIfNull(PrivateMSFFSSecond.September) + ZeroIfNull(PrivateMSLCFirst.September) + ZeroIfNull(PrivateMSLCSecond.September),
                    October = ZeroIfNull(PrivateMSFFSFirst.October) + ZeroIfNull(PrivateMSFFSSecond.October) + ZeroIfNull(PrivateMSLCFirst.October) + ZeroIfNull(PrivateMSLCSecond.October),
                    November = ZeroIfNull(PrivateMSFFSFirst.November) + ZeroIfNull(PrivateMSFFSSecond.November) + ZeroIfNull(PrivateMSLCFirst.November) + ZeroIfNull(PrivateMSLCSecond.November),
                    December = ZeroIfNull(PrivateMSFFSFirst.December) + ZeroIfNull(PrivateMSFFSSecond.December) + ZeroIfNull(PrivateMSLCFirst.December) + ZeroIfNull(PrivateMSLCSecond.December)
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }
        public OccupancyRecord PercentUnitOccupancy
        {
            get
            {
                if (EndingAverageOccupancy != null && UnitsAvailable != null)
                {
                    return new OccupancyRecord
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
                return null;
            }
        }

        public OccupancyRecord UnoccupiedUnits
        {
            get
            {
                if (EndingAverageOccupancy != null && UnitsAvailable != null)
                {
                    OccupancyRecord record = new OccupancyRecord
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
                    record.TotalOrAverage = record.CalculateAverageValue();
                }
                return new OccupancyRecord();
            }
        }

        public OccupancyRecord EndingAveragePersonOccupancy
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = EndingAverageOccupancy.January ?? ZeroIfNull(PrivateMSFFSFirst.January) + ZeroIfNull(PrivateMSFFSSecond.January) + ZeroIfNull(PrivateMSLCFirst.January) + ZeroIfNull(PrivateMSLCSecond.January),
                    February = EndingAverageOccupancy.February ?? ZeroIfNull(PrivateMSFFSFirst.February) + ZeroIfNull(PrivateMSFFSSecond.February) + ZeroIfNull(PrivateMSLCFirst.February) + ZeroIfNull(PrivateMSLCSecond.February),
                    March = EndingAverageOccupancy.March ?? ZeroIfNull(PrivateMSFFSFirst.March) + ZeroIfNull(PrivateMSFFSSecond.March) + ZeroIfNull(PrivateMSLCFirst.March) + ZeroIfNull(PrivateMSLCSecond.March),
                    April = EndingAverageOccupancy.April ?? ZeroIfNull(PrivateMSFFSFirst.April) + ZeroIfNull(PrivateMSFFSSecond.April) + ZeroIfNull(PrivateMSLCFirst.April) + ZeroIfNull(PrivateMSLCSecond.April),
                    May = EndingAverageOccupancy.May ?? ZeroIfNull(PrivateMSFFSFirst.May) + ZeroIfNull(PrivateMSFFSSecond.May) + ZeroIfNull(PrivateMSLCFirst.May) + ZeroIfNull(PrivateMSLCSecond.May),
                    June = EndingAverageOccupancy.June ?? ZeroIfNull(PrivateMSFFSFirst.June) + ZeroIfNull(PrivateMSFFSSecond.June) + ZeroIfNull(PrivateMSLCFirst.June) + ZeroIfNull(PrivateMSLCSecond.June),
                    July = EndingAverageOccupancy.July ?? ZeroIfNull(PrivateMSFFSFirst.July) + ZeroIfNull(PrivateMSFFSSecond.July) + ZeroIfNull(PrivateMSLCFirst.July) + ZeroIfNull(PrivateMSLCSecond.July),
                    August = EndingAverageOccupancy.August ?? ZeroIfNull(PrivateMSFFSFirst.August) + ZeroIfNull(PrivateMSFFSSecond.August) + ZeroIfNull(PrivateMSLCFirst.August) + ZeroIfNull(PrivateMSLCSecond.August),
                    September = EndingAverageOccupancy.September ?? ZeroIfNull(PrivateMSFFSFirst.September) + ZeroIfNull(PrivateMSFFSSecond.September) + ZeroIfNull(PrivateMSLCFirst.September) + ZeroIfNull(PrivateMSLCSecond.September),
                    October = EndingAverageOccupancy.October ?? ZeroIfNull(PrivateMSFFSFirst.October) + ZeroIfNull(PrivateMSFFSSecond.October) + ZeroIfNull(PrivateMSLCFirst.October) + ZeroIfNull(PrivateMSLCSecond.October),
                    November = EndingAverageOccupancy.November ?? ZeroIfNull(PrivateMSFFSFirst.November) + ZeroIfNull(PrivateMSFFSSecond.November) + ZeroIfNull(PrivateMSLCFirst.November) + ZeroIfNull(PrivateMSLCSecond.November),
                    December = EndingAverageOccupancy.December ?? ZeroIfNull(PrivateMSFFSFirst.December) + ZeroIfNull(PrivateMSFFSSecond.December) + ZeroIfNull(PrivateMSLCFirst.December) + ZeroIfNull(PrivateMSLCSecond.December)
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return new OccupancyRecord();
            }
        }

        public OccupancyRecord PercentLicensedOccupancy
        {
            get
            {
                return new OccupancyRecord
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
        }

    }
}
