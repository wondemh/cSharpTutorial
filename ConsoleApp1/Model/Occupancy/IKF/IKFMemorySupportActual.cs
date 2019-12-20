using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IKFMemorySupportActual
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
                        January = PrivateMCFirstPerson.January + PrivateMCSecondPerson.January,
                        February = PrivateMCFirstPerson.February + PrivateMCSecondPerson.February,
                        March = PrivateMCFirstPerson.March + PrivateMCSecondPerson.March,
                        April = PrivateMCFirstPerson.April + PrivateMCSecondPerson.April,
                        May = PrivateMCFirstPerson.May + PrivateMCSecondPerson.May,
                        June = PrivateMCFirstPerson.June + PrivateMCSecondPerson.June,
                        July = PrivateMCFirstPerson.July + PrivateMCSecondPerson.July,
                        August = PrivateMCFirstPerson.August + PrivateMCSecondPerson.August,
                        September = PrivateMCFirstPerson.September + PrivateMCSecondPerson.September,
                        October = PrivateMCFirstPerson.October + PrivateMCSecondPerson.October,
                        November = PrivateMCFirstPerson.November + PrivateMCSecondPerson.November,
                        December = PrivateMCFirstPerson.December + PrivateMCSecondPerson.December
                    };
                    record.TotalOrAverage = record.CalculateAverageValue();
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
                        January = UnitsAvailable.January > 0 ? (float)Math.Round(EndingAverageOccupancy.January / UnitsAvailable.January, 0) : 0,
                        February = UnitsAvailable.February > 0 ? (float)Math.Round(EndingAverageOccupancy.February / UnitsAvailable.February, 0) : 0,
                        March = UnitsAvailable.March > 0 ? (float)Math.Round(EndingAverageOccupancy.March / UnitsAvailable.March, 0) : 0,
                        April = UnitsAvailable.April > 0 ? (float)Math.Round(EndingAverageOccupancy.April / UnitsAvailable.April, 0) : 0,
                        May = UnitsAvailable.May > 0 ? (float)Math.Round(EndingAverageOccupancy.May / UnitsAvailable.May, 0) : 0,
                        June = UnitsAvailable.June > 0 ? (float)Math.Round(EndingAverageOccupancy.June / UnitsAvailable.June, 0) : 0,
                        July = UnitsAvailable.July > 0 ? (float)Math.Round(EndingAverageOccupancy.July / UnitsAvailable.July, 0) : 0,
                        August = UnitsAvailable.August > 0 ? (float)Math.Round(EndingAverageOccupancy.August / UnitsAvailable.August, 0) : 0,
                        September = UnitsAvailable.September > 0 ? (float)Math.Round(EndingAverageOccupancy.September / UnitsAvailable.September, 0) : 0,
                        October = UnitsAvailable.October > 0 ? (float)Math.Round(EndingAverageOccupancy.October / UnitsAvailable.October, 0) : 0,
                        November = UnitsAvailable.November > 0 ? (float)Math.Round(EndingAverageOccupancy.November / UnitsAvailable.November, 0) : 0,
                        December = UnitsAvailable.December > 0 ? (float)Math.Round(EndingAverageOccupancy.December / UnitsAvailable.December, 0) : 0,
                        TotalOrAverage = UnitsAvailable.TotalOrAverage > 0 ? (float)Math.Round(EndingAverageOccupancy.TotalOrAverage / UnitsAvailable.TotalOrAverage, 0) : 0
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
                        January = UnitsAvailable.January - EndingAverageOccupancy.January,
                        February = UnitsAvailable.February - EndingAverageOccupancy.February,
                        March = UnitsAvailable.March - EndingAverageOccupancy.March,
                        April = UnitsAvailable.April - EndingAverageOccupancy.April,
                        May = UnitsAvailable.May - EndingAverageOccupancy.May,
                        June = UnitsAvailable.June - EndingAverageOccupancy.June,
                        July = UnitsAvailable.July - EndingAverageOccupancy.July,
                        August = UnitsAvailable.August - EndingAverageOccupancy.August,
                        September = UnitsAvailable.September - EndingAverageOccupancy.September,
                        October = UnitsAvailable.October - EndingAverageOccupancy.October,
                        November = UnitsAvailable.November - EndingAverageOccupancy.November,
                        December = UnitsAvailable.December - EndingAverageOccupancy.December
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
                        January = PrivateMCFirstPerson.January + PrivateMCSecondPerson.January,
                        February = PrivateMCFirstPerson.February + PrivateMCSecondPerson.February,
                        March = PrivateMCFirstPerson.March + PrivateMCSecondPerson.March,
                        April = PrivateMCFirstPerson.April + PrivateMCSecondPerson.April,
                        May = PrivateMCFirstPerson.May + PrivateMCSecondPerson.May,
                        June = PrivateMCFirstPerson.June + PrivateMCSecondPerson.June,
                        July = PrivateMCFirstPerson.July + PrivateMCSecondPerson.July,
                        August = PrivateMCFirstPerson.August + PrivateMCSecondPerson.August,
                        September = PrivateMCFirstPerson.September + PrivateMCSecondPerson.September,
                        October = PrivateMCFirstPerson.October + PrivateMCSecondPerson.October,
                        November = PrivateMCFirstPerson.November + PrivateMCSecondPerson.November,
                        December = PrivateMCFirstPerson.December + PrivateMCSecondPerson.December
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
                        January = LicensedFor.January > 0 ? (float)Math.Round(EndingAverageOccupancy.January / LicensedFor.January, 0) : 0,
                        February = LicensedFor.February > 0 ? (float)Math.Round(EndingAverageOccupancy.February / LicensedFor.February, 0) : 0,
                        March = LicensedFor.March > 0 ? (float)Math.Round(EndingAverageOccupancy.March / LicensedFor.March, 0) : 0,
                        April = LicensedFor.April > 0 ? (float)Math.Round(EndingAverageOccupancy.April / LicensedFor.April, 0) : 0,
                        May = LicensedFor.May > 0 ? (float)Math.Round(EndingAverageOccupancy.May / LicensedFor.May, 0) : 0,
                        June = LicensedFor.June > 0 ? (float)Math.Round(EndingAverageOccupancy.June / LicensedFor.June, 0) : 0,
                        July = LicensedFor.July > 0 ? (float)Math.Round(EndingAverageOccupancy.July / LicensedFor.July, 0) : 0,
                        August = LicensedFor.August > 0 ? (float)Math.Round(EndingAverageOccupancy.August / LicensedFor.August, 0) : 0,
                        September = LicensedFor.September > 0 ? (float)Math.Round(EndingAverageOccupancy.September / LicensedFor.September, 0) : 0,
                        October = LicensedFor.October > 0 ? (float)Math.Round(EndingAverageOccupancy.October / LicensedFor.October, 0) : 0,
                        November = LicensedFor.November > 0 ? (float)Math.Round(EndingAverageOccupancy.November / LicensedFor.November, 0) : 0,
                        December = LicensedFor.December > 0 ? (float)Math.Round(EndingAverageOccupancy.December / LicensedFor.December, 0) : 0,
                        TotalOrAverage = LicensedFor.TotalOrAverage > 0 ? (float)Math.Round(EndingAveragePersonOccupancy.TotalOrAverage / LicensedFor.TotalOrAverage, 0) : 0
                    };
                }
                return new OccupancyRecord();
            }
        }

    }
}
