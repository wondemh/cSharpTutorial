using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IKFAssistedLivingBudget : OccupancyRecordsContainer
    {
        public IKFAssistedLivingActual AssistedLivingActual { get;  set; }
        public OccupancyRecord AverageLevelOne { get; set; }
        public OccupancyRecord AverageLevelTwo { get; set; }
        public OccupancyRecord AverageLevelThree { get; set; }
        public OccupancyRecord AverageSecondPerson { get; set; }
        public OccupancyRecord EndingAverageOccupancy 
        {
            get
            {

                OccupancyRecord record = new OccupancyRecord();
                record.January = ZeroIfNull(AverageLevelOne.January) + ZeroIfNull(AverageLevelTwo.January) + ZeroIfNull(AverageLevelTwo.January);
                record.February = ZeroIfNull(AverageLevelOne.February) + ZeroIfNull(AverageLevelTwo.February) + ZeroIfNull(AverageLevelTwo.February);
                record.March = ZeroIfNull(AverageLevelOne.March) + ZeroIfNull(AverageLevelTwo.March) + ZeroIfNull(AverageLevelTwo.March);
                record.April = ZeroIfNull(AverageLevelOne.April) + ZeroIfNull(AverageLevelTwo.April) + ZeroIfNull(AverageLevelTwo.April);
                record.May = ZeroIfNull(AverageLevelOne.May) + ZeroIfNull(AverageLevelTwo.May) + ZeroIfNull(AverageLevelTwo.May);
                record.June = ZeroIfNull(AverageLevelOne.June) + ZeroIfNull(AverageLevelTwo.June) + ZeroIfNull(AverageLevelTwo.June);
                record.July = ZeroIfNull(AverageLevelOne.July) + ZeroIfNull(AverageLevelTwo.July) + ZeroIfNull(AverageLevelTwo.July);
                record.August = ZeroIfNull(AverageLevelOne.August) + ZeroIfNull(AverageLevelTwo.August) + ZeroIfNull(AverageLevelTwo.August);
                record.September = ZeroIfNull(AverageLevelOne.September) + ZeroIfNull(AverageLevelTwo.September) + ZeroIfNull(AverageLevelTwo.September);
                record.October = ZeroIfNull(AverageLevelOne.October) + ZeroIfNull(AverageLevelTwo.October) + ZeroIfNull(AverageLevelTwo.October);
                record.November = ZeroIfNull(AverageLevelOne.November) + ZeroIfNull(AverageLevelTwo.November) + ZeroIfNull(AverageLevelTwo.November);
                record.December = ZeroIfNull(AverageLevelOne.December) + ZeroIfNull(AverageLevelTwo.December) + ZeroIfNull(AverageLevelTwo.December);
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }

        public OccupancyRecord EndingAverageOccupancyVarianceFromBudget 
        { 
            get 
            {
                OccupancyRecord record = new OccupancyRecord();
                record.January = AssistedLivingActual.EndingAverageOccupancy.January ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.January) - ZeroIfNull(EndingAverageOccupancy.January);
                record.February = AssistedLivingActual.EndingAverageOccupancy.February ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.February) - ZeroIfNull(EndingAverageOccupancy.February);
                record.March = AssistedLivingActual.EndingAverageOccupancy.March ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.March) - ZeroIfNull(EndingAverageOccupancy.March);
                record.April = AssistedLivingActual.EndingAverageOccupancy.April ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.April) - ZeroIfNull(EndingAverageOccupancy.April);
                record.May = AssistedLivingActual.EndingAverageOccupancy.May ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.May) - ZeroIfNull(EndingAverageOccupancy.May);
                record.June = AssistedLivingActual.EndingAverageOccupancy.June ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.June) - ZeroIfNull(EndingAverageOccupancy.June);
                record.July = AssistedLivingActual.EndingAverageOccupancy.July ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.July) - ZeroIfNull(EndingAverageOccupancy.July);
                record.August = AssistedLivingActual.EndingAverageOccupancy.August ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.August) - ZeroIfNull(EndingAverageOccupancy.August);
                record.September = AssistedLivingActual.EndingAverageOccupancy.September ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.September) - ZeroIfNull(EndingAverageOccupancy.September);
                record.October = AssistedLivingActual.EndingAverageOccupancy.October ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.October) - ZeroIfNull(EndingAverageOccupancy.October);
                record.November = AssistedLivingActual.EndingAverageOccupancy.November ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.November) - ZeroIfNull(EndingAverageOccupancy.November);
                record.December = AssistedLivingActual.EndingAverageOccupancy.December ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.December) - ZeroIfNull(EndingAverageOccupancy.December);
                return record;
            } 
        }
        public OccupancyRecord EndingAveragePersonOccupancy
        {
            get
            {

                OccupancyRecord record = new OccupancyRecord();
                record.January = ZeroIfNull(AverageLevelOne.January) + ZeroIfNull(AverageLevelTwo.January) + ZeroIfNull(AverageLevelTwo.January) + ZeroIfNull(AverageSecondPerson.January);
                record.February = ZeroIfNull(AverageLevelOne.February) + ZeroIfNull(AverageLevelTwo.February) + ZeroIfNull(AverageLevelTwo.February) + ZeroIfNull(AverageSecondPerson.February);
                record.March = ZeroIfNull(AverageLevelOne.March) + ZeroIfNull(AverageLevelTwo.March) + ZeroIfNull(AverageLevelTwo.March) + ZeroIfNull(AverageSecondPerson.March);
                record.April = ZeroIfNull(AverageLevelOne.April) + ZeroIfNull(AverageLevelTwo.April) + ZeroIfNull(AverageLevelTwo.April) + ZeroIfNull(AverageSecondPerson.April);
                record.May = ZeroIfNull(AverageLevelOne.May) + ZeroIfNull(AverageLevelTwo.May) + ZeroIfNull(AverageLevelTwo.May) + ZeroIfNull(AverageSecondPerson.May);
                record.June = ZeroIfNull(AverageLevelOne.June) + ZeroIfNull(AverageLevelTwo.June) + ZeroIfNull(AverageLevelTwo.June) + ZeroIfNull(AverageSecondPerson.June);
                record.July = ZeroIfNull(AverageLevelOne.July) + ZeroIfNull(AverageLevelTwo.July) + ZeroIfNull(AverageLevelTwo.July) + ZeroIfNull(AverageSecondPerson.July);
                record.August = ZeroIfNull(AverageLevelOne.August) + ZeroIfNull(AverageLevelTwo.August) + ZeroIfNull(AverageLevelTwo.August) + ZeroIfNull(AverageSecondPerson.August);
                record.September = ZeroIfNull(AverageLevelOne.September) + ZeroIfNull(AverageLevelTwo.September) + ZeroIfNull(AverageLevelTwo.September) + ZeroIfNull(AverageSecondPerson.September);
                record.October = ZeroIfNull(AverageLevelOne.October) + ZeroIfNull(AverageLevelTwo.October) + ZeroIfNull(AverageLevelTwo.October) + ZeroIfNull(AverageSecondPerson.October);
                record.November = ZeroIfNull(AverageLevelOne.November) + ZeroIfNull(AverageLevelTwo.November) + ZeroIfNull(AverageLevelTwo.November) + ZeroIfNull(AverageSecondPerson.November);
                record.December = ZeroIfNull(AverageLevelOne.December) + ZeroIfNull(AverageLevelTwo.December) + ZeroIfNull(AverageLevelTwo.December) + ZeroIfNull(AverageSecondPerson.December);
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }

        //record.January = Actual.EndingAveragePersonOccupancy.January ?? Actual.EndingAveragePersonOccupancy.January - ZeroIfNull(EndingAveragePersonOccupancy);
        public OccupancyRecord EndingAveragePersonOccupancyVarianceFromBudget
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord();
                record.January = AssistedLivingActual.EndingAveragePersonOccupancy.January ?? AssistedLivingActual.EndingAveragePersonOccupancy.January - ZeroIfNull(EndingAveragePersonOccupancy.January);
                record.February = AssistedLivingActual.EndingAveragePersonOccupancy.February ?? AssistedLivingActual.EndingAveragePersonOccupancy.February - ZeroIfNull(EndingAveragePersonOccupancy.February);
                record.March = AssistedLivingActual.EndingAveragePersonOccupancy.March ?? AssistedLivingActual.EndingAveragePersonOccupancy.March - ZeroIfNull(EndingAveragePersonOccupancy.March);
                record.April = AssistedLivingActual.EndingAveragePersonOccupancy.April ?? AssistedLivingActual.EndingAveragePersonOccupancy.April - ZeroIfNull(EndingAveragePersonOccupancy.April);
                record.May = AssistedLivingActual.EndingAveragePersonOccupancy.May ?? AssistedLivingActual.EndingAveragePersonOccupancy.May - ZeroIfNull(EndingAveragePersonOccupancy.May);
                record.June = AssistedLivingActual.EndingAveragePersonOccupancy.June ?? AssistedLivingActual.EndingAveragePersonOccupancy.June - ZeroIfNull(EndingAveragePersonOccupancy.June);
                record.July = AssistedLivingActual.EndingAveragePersonOccupancy.July ?? AssistedLivingActual.EndingAveragePersonOccupancy.July - ZeroIfNull(EndingAveragePersonOccupancy.July);
                record.August = AssistedLivingActual.EndingAveragePersonOccupancy.August ?? AssistedLivingActual.EndingAveragePersonOccupancy.August - ZeroIfNull(EndingAveragePersonOccupancy.August);
                record.September = AssistedLivingActual.EndingAveragePersonOccupancy.September ?? AssistedLivingActual.EndingAveragePersonOccupancy.September - ZeroIfNull(EndingAveragePersonOccupancy.September);
                record.October = AssistedLivingActual.EndingAveragePersonOccupancy.October ?? AssistedLivingActual.EndingAveragePersonOccupancy.October - ZeroIfNull(EndingAveragePersonOccupancy.October);
                record.November = AssistedLivingActual.EndingAveragePersonOccupancy.November ?? AssistedLivingActual.EndingAveragePersonOccupancy.November - ZeroIfNull(EndingAveragePersonOccupancy.November);
                record.December = AssistedLivingActual.EndingAveragePersonOccupancy.December ?? AssistedLivingActual.EndingAveragePersonOccupancy.December - ZeroIfNull(EndingAveragePersonOccupancy.December);
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }
    }
}
