using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IKFMemorySupportActual : OccupancyRecordsContainer
    {
        public OccupancyRecord UnitsAvailable { get; set; }
        public OccupancyRecord LicensedFor { get; set; }
        public OccupancyRecord PrivateMCFirstPerson { get; set; }
        public OccupancyRecord PrivateMCSecondPerson { get; set; }      
        public OccupancyRecord EndingAverageOccupancy
        {
            get
            {
                if (PrivateMCFirstPerson != null && PrivateMCSecondPerson != null)
                {
                    OccupancyRecord record = new OccupancyRecord
                    {
                        January = PrivateMCFirstPerson.January ?? ZeroIfNull(PrivateMCFirstPerson.January) + ZeroIfNull(PrivateMCSecondPerson.January),
                        February = PrivateMCFirstPerson.February ?? ZeroIfNull(PrivateMCFirstPerson.February) + ZeroIfNull(PrivateMCSecondPerson.February),
                        March = PrivateMCFirstPerson.March ?? ZeroIfNull(PrivateMCFirstPerson.March) + ZeroIfNull(PrivateMCSecondPerson.March),
                        April = PrivateMCFirstPerson.April ?? ZeroIfNull(PrivateMCFirstPerson.April) + ZeroIfNull(PrivateMCSecondPerson.April),
                        May = PrivateMCFirstPerson.May ?? ZeroIfNull(PrivateMCFirstPerson.May) + ZeroIfNull(PrivateMCSecondPerson.May),
                        June = PrivateMCFirstPerson.June ?? ZeroIfNull(PrivateMCFirstPerson.June) + ZeroIfNull(PrivateMCSecondPerson.June),
                        July = PrivateMCFirstPerson.July ?? ZeroIfNull(PrivateMCFirstPerson.July) + ZeroIfNull(PrivateMCSecondPerson.July),
                        August = PrivateMCFirstPerson.August ?? ZeroIfNull(PrivateMCFirstPerson.August) + ZeroIfNull(PrivateMCSecondPerson.August),
                        September = PrivateMCFirstPerson.September ?? ZeroIfNull(PrivateMCFirstPerson.September) + ZeroIfNull(PrivateMCSecondPerson.September),
                        October = PrivateMCFirstPerson.October ?? ZeroIfNull(PrivateMCFirstPerson.October) + ZeroIfNull(PrivateMCSecondPerson.October),
                        November = PrivateMCFirstPerson.November ?? ZeroIfNull(PrivateMCFirstPerson.November) + ZeroIfNull(PrivateMCSecondPerson.November),
                        December = PrivateMCFirstPerson.December ?? ZeroIfNull(PrivateMCFirstPerson.December) + ZeroIfNull(PrivateMCSecondPerson.December)
                    };
                    record.TotalOrAverage = record.CalculateAverageValue();
                    return record;
                }
                return new OccupancyRecord();
            }
        }
        public OccupancyRecord PercentAverageUnitOccupancy
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

        public OccupancyRecord AverageUnoccupiedUnits
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
                if (PrivateMCFirstPerson != null && PrivateMCSecondPerson != null)
                {
                    OccupancyRecord record = new OccupancyRecord
                    {
                        January = EndingAverageOccupancy.January ?? ZeroIfNull(PrivateMCFirstPerson.January) + ZeroIfNull(PrivateMCSecondPerson.January),
                        February = EndingAverageOccupancy.February ?? ZeroIfNull(PrivateMCFirstPerson.February) + ZeroIfNull(PrivateMCSecondPerson.February),
                        March = EndingAverageOccupancy.March ?? ZeroIfNull(PrivateMCFirstPerson.March) + ZeroIfNull(PrivateMCSecondPerson.March),
                        April = EndingAverageOccupancy.April ?? ZeroIfNull(PrivateMCFirstPerson.April) + ZeroIfNull(PrivateMCSecondPerson.April),
                        May = EndingAverageOccupancy.May ?? ZeroIfNull(PrivateMCFirstPerson.May) + ZeroIfNull(PrivateMCSecondPerson.May),
                        June = EndingAverageOccupancy.June ?? ZeroIfNull(PrivateMCFirstPerson.June) + ZeroIfNull(PrivateMCSecondPerson.June),
                        July = EndingAverageOccupancy.July ?? ZeroIfNull(PrivateMCFirstPerson.July) + ZeroIfNull(PrivateMCSecondPerson.July),
                        August = EndingAverageOccupancy.August ?? ZeroIfNull(PrivateMCFirstPerson.August) + ZeroIfNull(PrivateMCSecondPerson.August),
                        September = EndingAverageOccupancy.September ?? ZeroIfNull(PrivateMCFirstPerson.September) + ZeroIfNull(PrivateMCSecondPerson.September),
                        October = EndingAverageOccupancy.October ?? ZeroIfNull(PrivateMCFirstPerson.October) + ZeroIfNull(PrivateMCSecondPerson.October),
                        November = EndingAverageOccupancy.November ?? ZeroIfNull(PrivateMCFirstPerson.November) + ZeroIfNull(PrivateMCSecondPerson.November),
                        December = EndingAverageOccupancy.December ?? ZeroIfNull(PrivateMCFirstPerson.December) + ZeroIfNull(PrivateMCSecondPerson.December)
                    };
                    record.TotalOrAverage = record.CalculateAverageValue();
                }
                return new OccupancyRecord();
            }
        }
        public OccupancyRecord PercentLicensedOccupancy
        {
            get
            {
                if (EndingAveragePersonOccupancy != null && LicensedFor != null)
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
                return new OccupancyRecord();
            }
        }

    }
}
