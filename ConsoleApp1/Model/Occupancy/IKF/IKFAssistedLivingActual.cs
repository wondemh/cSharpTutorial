using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IKFAssistedLivingActual : OccupancyRecordsContainer
    {
        public OccupancyRecord UnitsAvailable { get; set; }
        public OccupancyRecord LicensedFor { get; set; }
        public OccupancyRecord AverageLevelOne { get; set; }
        public OccupancyRecord AverageLevelTwo { get; set; }
        public OccupancyRecord AverageLevelThree { get; set; }
        public OccupancyRecord AverageSecondPerson { get; set; }

        public OccupancyRecord EndingAverageOccupancy
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord();
                record.January = AverageLevelOne.January ?? AverageLevelOne.January + AverageLevelTwo.January + AverageLevelThree.January;
                record.February = AverageLevelOne.February ?? AverageLevelOne.February + AverageLevelTwo.February + AverageLevelThree.February;
                record.March = AverageLevelOne.March ?? AverageLevelOne.March + AverageLevelTwo.March + AverageLevelThree.March;
                record.April = AverageLevelOne.April ?? AverageLevelOne.April + AverageLevelTwo.April + AverageLevelThree.April;
                record.May = AverageLevelOne.May ?? AverageLevelOne.May + AverageLevelTwo.May + AverageLevelThree.May;
                record.June = AverageLevelOne.June ?? AverageLevelOne.June + AverageLevelTwo.June + AverageLevelThree.June;
                record.July = AverageLevelOne.July ?? AverageLevelOne.July + AverageLevelTwo.July + AverageLevelThree.July;
                record.August = AverageLevelOne.August ?? AverageLevelOne.August + AverageLevelTwo.August + AverageLevelThree.August;
                record.September = AverageLevelOne.September ?? AverageLevelOne.September + AverageLevelTwo.September + AverageLevelThree.September;
                record.October = AverageLevelOne.October ?? AverageLevelOne.October + AverageLevelTwo.October + AverageLevelThree.October;
                record.November = AverageLevelOne.November ?? AverageLevelOne.November + AverageLevelTwo.November + AverageLevelThree.November;
                record.December = AverageLevelOne.December ?? AverageLevelOne.December + AverageLevelTwo.December + AverageLevelThree.December;
                return record;
            }
        }
        public OccupancyRecord PercentAverageUnitOccupancy 
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord();
                record.January = EndingAverageOccupancy.January ?? Divide(EndingAverageOccupancy.January, UnitsAvailable.January);
                record.February = EndingAverageOccupancy.February ?? Divide(EndingAverageOccupancy.February, UnitsAvailable.February);
                record.March = EndingAverageOccupancy.March ?? Divide(EndingAverageOccupancy.March, UnitsAvailable.March);
                record.April = EndingAverageOccupancy.April ?? Divide(EndingAverageOccupancy.April, UnitsAvailable.April);
                record.May = EndingAverageOccupancy.May ?? Divide(EndingAverageOccupancy.May, UnitsAvailable.May);
                record.June = EndingAverageOccupancy.June ?? Divide(EndingAverageOccupancy.June, UnitsAvailable.June);
                record.July = EndingAverageOccupancy.July ?? Divide(EndingAverageOccupancy.July, UnitsAvailable.July);
                record.August = EndingAverageOccupancy.August ?? Divide(EndingAverageOccupancy.August, UnitsAvailable.August);
                record.September = EndingAverageOccupancy.September ?? Divide(EndingAverageOccupancy.September, UnitsAvailable.September);
                record.October = EndingAverageOccupancy.October ?? Divide(EndingAverageOccupancy.October, UnitsAvailable.October);
                record.November = EndingAverageOccupancy.November ?? Divide(EndingAverageOccupancy.November, UnitsAvailable.November);
                record.December = EndingAverageOccupancy.December ?? Divide(EndingAverageOccupancy.December, UnitsAvailable.December);
                return record;
            }
        }

        public OccupancyRecord AverageUnoccupiedUnits
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord();
                record.January = EndingAverageOccupancy.January ?? Subtract(UnitsAvailable.January, EndingAverageOccupancy.January);
                record.February = EndingAverageOccupancy.February ?? Subtract(UnitsAvailable.February, EndingAverageOccupancy.February);
                record.March = EndingAverageOccupancy.March ?? Subtract(UnitsAvailable.March, EndingAverageOccupancy.March);
                record.April = EndingAverageOccupancy.April ?? Subtract(UnitsAvailable.April, EndingAverageOccupancy.April);
                record.May = EndingAverageOccupancy.May ?? Subtract(UnitsAvailable.May, EndingAverageOccupancy.May);
                record.June = EndingAverageOccupancy.June ?? Subtract(UnitsAvailable.June, EndingAverageOccupancy.June);
                record.July = EndingAverageOccupancy.July ?? Subtract(UnitsAvailable.July, EndingAverageOccupancy.July);
                record.August = EndingAverageOccupancy.August ?? Subtract(UnitsAvailable.August, EndingAverageOccupancy.August);
                record.September = EndingAverageOccupancy.September ?? Subtract(UnitsAvailable.September, EndingAverageOccupancy.September);
                record.October = EndingAverageOccupancy.October ?? Subtract(UnitsAvailable.October, EndingAverageOccupancy.October);
                record.November = EndingAverageOccupancy.November ?? Subtract(UnitsAvailable.November, EndingAverageOccupancy.November);
                record.December = EndingAverageOccupancy.December ?? Subtract(UnitsAvailable.December, EndingAverageOccupancy.December);
                return record;
            }
        }


        public OccupancyRecord EndingAveragePersonOccupancy
        {
            get
            {

                OccupancyRecord record = new OccupancyRecord();
                record.January = EndingAverageOccupancy.January ?? ZeroIfNull(AverageLevelOne.January) + ZeroIfNull(AverageLevelTwo.January) + ZeroIfNull(AverageLevelThree.January) + ZeroIfNull(AverageSecondPerson.January);
                record.February = EndingAverageOccupancy.February ?? ZeroIfNull(AverageLevelOne.February) + ZeroIfNull(AverageLevelTwo.February) + ZeroIfNull(AverageLevelThree.February) + ZeroIfNull(AverageSecondPerson.February);
                record.March = EndingAverageOccupancy.March ?? ZeroIfNull(AverageLevelOne.March) + ZeroIfNull(AverageLevelTwo.March) + ZeroIfNull(AverageLevelThree.March) + ZeroIfNull(AverageSecondPerson.March);
                record.April = EndingAverageOccupancy.April ?? AverageLevelOne.April + AverageLevelTwo.April + AverageLevelThree.April + AverageSecondPerson.April;
                record.May = EndingAverageOccupancy.May ?? ZeroIfNull(AverageLevelOne.May) + ZeroIfNull(AverageLevelTwo.May) + ZeroIfNull(AverageLevelThree.May) + ZeroIfNull(AverageSecondPerson.May);
                record.June = EndingAverageOccupancy.June ?? ZeroIfNull(AverageLevelOne.June) + ZeroIfNull(AverageLevelTwo.June) + ZeroIfNull(AverageLevelThree.June) + ZeroIfNull(AverageSecondPerson.June);
                record.July = EndingAverageOccupancy.July ?? ZeroIfNull(AverageLevelOne.July) + ZeroIfNull(AverageLevelTwo.July) + ZeroIfNull(AverageLevelThree.July) + ZeroIfNull(AverageSecondPerson.July);
                record.August = EndingAverageOccupancy.August ?? ZeroIfNull(AverageLevelOne.August) + ZeroIfNull(AverageLevelTwo.August) + ZeroIfNull(AverageLevelThree.August) + ZeroIfNull(AverageSecondPerson.August);
                record.September = EndingAverageOccupancy.September ?? ZeroIfNull(AverageLevelOne.September) + ZeroIfNull(AverageLevelTwo.September) + ZeroIfNull(AverageLevelThree.September) + ZeroIfNull(AverageSecondPerson.September);
                record.October = EndingAverageOccupancy.October ?? ZeroIfNull(AverageLevelOne.October) + ZeroIfNull(AverageLevelTwo.October) + ZeroIfNull(AverageLevelThree.October) + ZeroIfNull(AverageSecondPerson.October);
                record.November = EndingAverageOccupancy.November ?? ZeroIfNull(AverageLevelOne.November) + ZeroIfNull(AverageLevelTwo.November) + ZeroIfNull(AverageLevelThree.November) + ZeroIfNull(AverageSecondPerson.November);
                record.December = EndingAverageOccupancy.December ?? ZeroIfNull(AverageLevelOne.December) + ZeroIfNull(AverageLevelTwo.December) + ZeroIfNull(AverageLevelThree.December) + ZeroIfNull(AverageSecondPerson.December);
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }

        //= IF(F36 <> "", +F36 / F28, "")
        //If Ending Average Peraton Occupancy ? Ending Average Person Occupancy / LicensedFor
        public OccupancyRecord PercentLicensedOccupancy
        {
            get
            {
                if (EndingAveragePersonOccupancy != null && LicensedFor != null)
                {
                    OccupancyRecord record = new OccupancyRecord();
                    record.January = EndingAveragePersonOccupancy.January ??  (float)Math.Round(Divide(EndingAveragePersonOccupancy.January, LicensedFor.January), 0);
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
