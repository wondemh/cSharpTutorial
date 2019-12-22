using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IKFAssistedLivingActual : OccupancyRecordsContainer
    {
        public OccupancyRecord UnitsAvailable { get; set; }
        public OccupancyRecord LicensedFor
        {
            get
            {
                return new OccupancyRecord
                {
                    January = 46,
                    February = 46,
                    March = 46,
                    April = 46,
                    May = 46,
                    June = 46,
                    July = 46,
                    August = 46,
                    September = 46,
                    October = 46,
                    November = 46,
                    December = 46,
                    TotalOrAverage = 46
                };
            }
        }
        public OccupancyRecord AverageLevelOne { get; set; }
        public OccupancyRecord AverageLevelTwo { get; set; }
        public OccupancyRecord AverageLevelThree { get; set; }
        public OccupancyRecord AverageSecondPerson { get; set; }

        public OccupancyRecord EndingAverageOccupancy
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = AverageLevelOne.January ?? AverageLevelOne.January + AverageLevelTwo.January + AverageLevelThree.January,
                    February = AverageLevelOne.February ?? AverageLevelOne.February + AverageLevelTwo.February + AverageLevelThree.February,
                    March = AverageLevelOne.March ?? AverageLevelOne.March + AverageLevelTwo.March + AverageLevelThree.March,
                    April = AverageLevelOne.April ?? AverageLevelOne.April + AverageLevelTwo.April + AverageLevelThree.April,
                    May = AverageLevelOne.May ?? AverageLevelOne.May + AverageLevelTwo.May + AverageLevelThree.May,
                    June = AverageLevelOne.June ?? AverageLevelOne.June + AverageLevelTwo.June + AverageLevelThree.June,
                    July = AverageLevelOne.July ?? AverageLevelOne.July + AverageLevelTwo.July + AverageLevelThree.July,
                    August = AverageLevelOne.August ?? AverageLevelOne.August + AverageLevelTwo.August + AverageLevelThree.August,
                    September = AverageLevelOne.September ?? AverageLevelOne.September + AverageLevelTwo.September + AverageLevelThree.September,
                    October = AverageLevelOne.October ?? AverageLevelOne.October + AverageLevelTwo.October + AverageLevelThree.October,
                    November = AverageLevelOne.November ?? AverageLevelOne.November + AverageLevelTwo.November + AverageLevelThree.November,
                    December = AverageLevelOne.December ?? AverageLevelOne.December + AverageLevelTwo.December + AverageLevelThree.December
                };
                return record;
            }
        }
        public OccupancyRecord PercentAverageUnitOccupancy 
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
                    December = EndingAverageOccupancy.December ?? Divide(EndingAverageOccupancy.December, UnitsAvailable.December)
                };
                return record;
            }
        }

        public OccupancyRecord AverageUnoccupiedUnits
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = EndingAverageOccupancy.January ?? Subtract(UnitsAvailable.January, EndingAverageOccupancy.January),
                    February = EndingAverageOccupancy.February ?? Subtract(UnitsAvailable.February, EndingAverageOccupancy.February),
                    March = EndingAverageOccupancy.March ?? Subtract(UnitsAvailable.March, EndingAverageOccupancy.March),
                    April = EndingAverageOccupancy.April ?? Subtract(UnitsAvailable.April, EndingAverageOccupancy.April),
                    May = EndingAverageOccupancy.May ?? Subtract(UnitsAvailable.May, EndingAverageOccupancy.May),
                    June = EndingAverageOccupancy.June ?? Subtract(UnitsAvailable.June, EndingAverageOccupancy.June),
                    July = EndingAverageOccupancy.July ?? Subtract(UnitsAvailable.July, EndingAverageOccupancy.July),
                    August = EndingAverageOccupancy.August ?? Subtract(UnitsAvailable.August, EndingAverageOccupancy.August),
                    September = EndingAverageOccupancy.September ?? Subtract(UnitsAvailable.September, EndingAverageOccupancy.September),
                    October = EndingAverageOccupancy.October ?? Subtract(UnitsAvailable.October, EndingAverageOccupancy.October),
                    November = EndingAverageOccupancy.November ?? Subtract(UnitsAvailable.November, EndingAverageOccupancy.November),
                    December = EndingAverageOccupancy.December ?? Subtract(UnitsAvailable.December, EndingAverageOccupancy.December)
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
                    January = EndingAverageOccupancy.January ?? ZeroIfNull(AverageLevelOne.January) + ZeroIfNull(AverageLevelTwo.January) + ZeroIfNull(AverageLevelThree.January) + ZeroIfNull(AverageSecondPerson.January),
                    February = EndingAverageOccupancy.February ?? ZeroIfNull(AverageLevelOne.February) + ZeroIfNull(AverageLevelTwo.February) + ZeroIfNull(AverageLevelThree.February) + ZeroIfNull(AverageSecondPerson.February),
                    March = EndingAverageOccupancy.March ?? ZeroIfNull(AverageLevelOne.March) + ZeroIfNull(AverageLevelTwo.March) + ZeroIfNull(AverageLevelThree.March) + ZeroIfNull(AverageSecondPerson.March),
                    April = EndingAverageOccupancy.April ?? AverageLevelOne.April + AverageLevelTwo.April + AverageLevelThree.April + AverageSecondPerson.April,
                    May = EndingAverageOccupancy.May ?? ZeroIfNull(AverageLevelOne.May) + ZeroIfNull(AverageLevelTwo.May) + ZeroIfNull(AverageLevelThree.May) + ZeroIfNull(AverageSecondPerson.May),
                    June = EndingAverageOccupancy.June ?? ZeroIfNull(AverageLevelOne.June) + ZeroIfNull(AverageLevelTwo.June) + ZeroIfNull(AverageLevelThree.June) + ZeroIfNull(AverageSecondPerson.June),
                    July = EndingAverageOccupancy.July ?? ZeroIfNull(AverageLevelOne.July) + ZeroIfNull(AverageLevelTwo.July) + ZeroIfNull(AverageLevelThree.July) + ZeroIfNull(AverageSecondPerson.July),
                    August = EndingAverageOccupancy.August ?? ZeroIfNull(AverageLevelOne.August) + ZeroIfNull(AverageLevelTwo.August) + ZeroIfNull(AverageLevelThree.August) + ZeroIfNull(AverageSecondPerson.August),
                    September = EndingAverageOccupancy.September ?? ZeroIfNull(AverageLevelOne.September) + ZeroIfNull(AverageLevelTwo.September) + ZeroIfNull(AverageLevelThree.September) + ZeroIfNull(AverageSecondPerson.September),
                    October = EndingAverageOccupancy.October ?? ZeroIfNull(AverageLevelOne.October) + ZeroIfNull(AverageLevelTwo.October) + ZeroIfNull(AverageLevelThree.October) + ZeroIfNull(AverageSecondPerson.October),
                    November = EndingAverageOccupancy.November ?? ZeroIfNull(AverageLevelOne.November) + ZeroIfNull(AverageLevelTwo.November) + ZeroIfNull(AverageLevelThree.November) + ZeroIfNull(AverageSecondPerson.November),
                    December = EndingAverageOccupancy.December ?? ZeroIfNull(AverageLevelOne.December) + ZeroIfNull(AverageLevelTwo.December) + ZeroIfNull(AverageLevelThree.December) + ZeroIfNull(AverageSecondPerson.December)
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
                    OccupancyRecord record = new OccupancyRecord
                    {
                        January = EndingAveragePersonOccupancy.January ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.January, LicensedFor.January), 0),
                        February = EndingAveragePersonOccupancy.February ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.February, LicensedFor.February), 0),
                        March = EndingAveragePersonOccupancy.March ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.March, LicensedFor.March), 0),
                        April = EndingAveragePersonOccupancy.April ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.April, LicensedFor.April), 0),
                        May = EndingAveragePersonOccupancy.May ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.May, LicensedFor.May), 0),
                        June = EndingAveragePersonOccupancy.June ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.June, LicensedFor.June), 0),
                        July = EndingAveragePersonOccupancy.July ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.July, LicensedFor.July), 0),
                        August = EndingAveragePersonOccupancy.August ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.August, LicensedFor.August), 0),
                        September = EndingAveragePersonOccupancy.September ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.September, LicensedFor.September), 0),
                        October = EndingAveragePersonOccupancy.October ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.October, LicensedFor.October), 0),
                        November = EndingAveragePersonOccupancy.November ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.November, LicensedFor.November), 0),
                        December = EndingAveragePersonOccupancy.December ?? (float)Math.Round(Divide(EndingAveragePersonOccupancy.December, LicensedFor.December), 0),
                        TotalOrAverage = (float)Math.Round(Divide(EndingAveragePersonOccupancy.TotalOrAverage, LicensedFor.TotalOrAverage), 0)
                    };
                    return record;
                }
                return new OccupancyRecord(true);
            }
        }
    }
}
