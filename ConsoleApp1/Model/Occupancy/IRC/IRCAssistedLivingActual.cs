using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IRCAssistedLivingActual
    {
        public OccupancyRecord UnitsAvailable { get; set; }
        public OccupancyRecord LicensedFor { get; set; }
        public OccupancyRecord AverageLevelOne { get; set; }
        public OccupancyRecord AverageLevelTwo { get; set; }
        public OccupancyRecord AverageLevelThree { get; set; }
        public OccupancyRecord AverageSecondPerson { get; set; }
        public OccupancyRecord EndingAverageOccupancy { get; set; }
        public OccupancyRecord PercentAverageUnitOccupancy { get; set; }
        public OccupancyRecord AverageUnoccupiedUnits { get; set; }
        public OccupancyRecord EndingAveragePersonOccupancy
        {
            get
            {

                OccupancyRecord record = new OccupancyRecord
                {
                    January = AverageLevelOne.January + AverageLevelTwo.January + AverageLevelThree.January + AverageSecondPerson.January,
                    February = EndingAverageOccupancy.February > 0
                        ? AverageLevelOne.February + AverageLevelTwo.February + AverageLevelThree.February + AverageSecondPerson.February
                        : 0,
                    March = EndingAverageOccupancy.March > 0
                        ? AverageLevelOne.March + AverageLevelTwo.March + AverageLevelThree.March + AverageSecondPerson.March
                        : 0,
                    April = EndingAverageOccupancy.April > 0
                        ? AverageLevelOne.April + AverageLevelTwo.April + AverageLevelThree.April + AverageSecondPerson.April
                        : 0,
                    May = EndingAverageOccupancy.May > 0
                        ? AverageLevelOne.May + AverageLevelTwo.May + AverageLevelThree.May + AverageSecondPerson.May
                        : 0,
                    June = EndingAverageOccupancy.June > 0
                        ? AverageLevelOne.June + AverageLevelTwo.June + AverageLevelThree.June + AverageSecondPerson.June
                        : 0,
                    July = EndingAverageOccupancy.July > 0
                        ? AverageLevelOne.July + AverageLevelTwo.July + AverageLevelThree.July + AverageSecondPerson.July
                        : 0,
                    August = EndingAverageOccupancy.August > 0
                        ? AverageLevelOne.August + AverageLevelTwo.August + AverageLevelThree.August + AverageSecondPerson.August
                        : 0,
                    September = EndingAverageOccupancy.September > 0
                        ? AverageLevelOne.September + AverageLevelTwo.September + AverageLevelThree.September + AverageSecondPerson.September
                        : 0,
                    October = EndingAverageOccupancy.October > 0
                        ? AverageLevelOne.October + AverageLevelTwo.October + AverageLevelThree.October + AverageSecondPerson.October
                        : 0,
                    November = EndingAverageOccupancy.November > 0
                        ? AverageLevelOne.November + AverageLevelTwo.November + AverageLevelThree.November + AverageSecondPerson.November
                        : 0,
                    December = EndingAverageOccupancy.December > 0
                        ? AverageLevelOne.December + AverageLevelTwo.December + AverageLevelThree.December + AverageSecondPerson.December
                        : 0,
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
                        January = LicensedFor.January > 0 ? (float)Math.Round(EndingAveragePersonOccupancy.January / LicensedFor.January, 0) : 0,
                        February = LicensedFor.February > 0 ? (float)Math.Round(EndingAveragePersonOccupancy.February / LicensedFor.February, 0) : 0,
                        March = LicensedFor.March > 0 ? (float)Math.Round(EndingAveragePersonOccupancy.March / LicensedFor.March, 0) : 0,
                        April = LicensedFor.April > 0 ? (float)Math.Round(EndingAveragePersonOccupancy.April / LicensedFor.April, 0) : 0,
                        May = LicensedFor.May > 0 ? (float)Math.Round(EndingAveragePersonOccupancy.May / LicensedFor.May, 0) : 0,
                        June = LicensedFor.June > 0 ? (float)Math.Round(EndingAveragePersonOccupancy.June / LicensedFor.June, 0) : 0,
                        July = LicensedFor.July > 0 ? (float)Math.Round(EndingAveragePersonOccupancy.July / LicensedFor.July, 0) : 0,
                        August = LicensedFor.August > 0 ? (float)Math.Round(EndingAveragePersonOccupancy.August / LicensedFor.August, 0) : 0,
                        September = LicensedFor.September > 0 ? (float)Math.Round(EndingAveragePersonOccupancy.September / LicensedFor.September, 0) : 0,
                        October = LicensedFor.October > 0 ? (float)Math.Round(EndingAveragePersonOccupancy.October / LicensedFor.October, 0) : 0,
                        November = LicensedFor.November > 0 ? (float)Math.Round(EndingAveragePersonOccupancy.November / LicensedFor.November, 0) : 0,
                        December = LicensedFor.December > 0 ? (float)Math.Round(EndingAveragePersonOccupancy.December / LicensedFor.December, 0) : 0
                    };
                    record.TotalOrAverage = UnitsAvailable.TotalOrAverage > 0 ? (float)Math.Round(EndingAveragePersonOccupancy.TotalOrAverage / LicensedFor.TotalOrAverage, 0) : 0;
                    return record;
                }
                return new OccupancyRecord();
            }
        }
    }
}
